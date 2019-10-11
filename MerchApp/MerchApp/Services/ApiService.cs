using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Threading.Tasks;
using MerchApp.Models;
using Newtonsoft.Json;

namespace MerchApp.Services
{
    public class ApiService : IApiService
    {
        public async Task<Ticket> getOneTicket(string id)
        {
            Ticket ticket = new Ticket();
            try
            {
                HttpClient http1 = new HttpClient();
                http1.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", "ai5kaXNsYToxMjM0NTY3OA==");
                var data1 = http1.GetStringAsync("https://gadintermec.jitbit.com/helpdesk/api/ticket/" + id); //primer request para obtener la fecha y el numero de ticket
                data1.Wait();
                int pFrom = (data1.Result).IndexOf("IssueDate") + "IssueDate".Length + 3;
                int pTo = pFrom + 10;

                ticket.ticketNum = id;
                ticket.Fecha = (data1.Result).Substring(pFrom, pTo - pFrom);
                //Ticket Info
                HttpClient http = new HttpClient();
                http.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", "ai5kaXNsYToxMjM0NTY3OA==");
                var data = http.GetStringAsync("https://gadintermec.jitbit.com/helpdesk/api/TicketCustomFields?id=" + id); //Segundo request para obtener el serial, modelo, Cliente y prioridad del ticket
                data.Wait();
                var list = JsonConvert.DeserializeObject<List<RootObject>>(data.Result);
                for (int i = 0; i < list.Count; i++)
                {
                    if (list[i].FieldName == "Serial")
                    {
                        ticket.Serial = list[i].Value;
                    }
                    else if (list[i].FieldName == "Modelo")
                    {
                        ticket.Modelo = list[i].Value;
                    }
                    else if (list[i].FieldName == "Cliente")
                    {
                        ticket.Cliente = list[i].Value;
                    }
                    else if (list[i].FieldName == "Prioridad")
                    {
                        ticket.Prioridad = list[i].Value;
                    }
                }
                return ticket;
            }
            catch
            {
                //Dont do anything for now
            }
            return ticket;
        }

        public async Task<ObservableCollection<Ticket>> GetVariousTickets(string count)
        {
            ObservableCollection<Ticket> tickets = new ObservableCollection<Ticket>();
            try
            {
                HttpClient http1 = new HttpClient();
                http1.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", "ai5kaXNsYToxMjM0NTY3OA==");
                var data1 = http1.GetStringAsync("https://gadintermec.jitbit.com/helpdesk/api/Tickets?Count=" + count);//primer request para obtener la fecha y el numero de ticket
                data1.Wait();
                if (data1.IsCompleted)
                {
                    var list1 = JsonConvert.DeserializeObject<List<TicketsCount>>(data1.Result);
                    
                    foreach (TicketsCount t in list1)
                    {
                        Ticket ticket = new Ticket();
                        ticket.ticketNum = (t.IssueID).ToString();
                        ticket.Fecha = (t.IssueDate).ToString().Substring(0, 9);
                        //Ticket Info
                        HttpClient http = new HttpClient();
                        http.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", "ai5kaXNsYToxMjM0NTY3OA==");
                        var data = http.GetStringAsync("https://gadintermec.jitbit.com/helpdesk/api/TicketCustomFields?id=" + t.IssueID);//Segundo request para obtener el serial, modelo, Cliente y prioridad del ticket
                        data.Wait();
                        var list = JsonConvert.DeserializeObject<List<RootObject>>(data.Result);
                        for (int i = 0; i < list.Count; i++)
                        {
                            if (list[i].FieldName == "Serial")
                            {
                                ticket.Serial = list[i].Value;
                            }
                            else if (list[i].FieldName == "Modelo")
                            {
                                ticket.Modelo = list[i].Value;
                            }
                            else if (list[i].FieldName == "Cliente")
                            {
                                ticket.Cliente = list[i].Value;
                            }
                            else if (list[i].FieldName == "Prioridad")
                            {
                                ticket.Prioridad = list[i].Value;
                            }
                        }
                        //Add to dataBase
                        tickets.Add(ticket);
                    }

                    return tickets;
                }

            }
            catch (Exception ex)
            {
                //Dont do anything for now
            }
            return tickets;
        }
    }
}
