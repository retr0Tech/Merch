using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using MerchApp.Models;

namespace MerchApp.Services
{
    public interface IApiService
    {
        Task<Ticket> getOneTicket(string id);
        Task<ObservableCollection<Ticket>> GetVariousTickets(string count);
    }
}
