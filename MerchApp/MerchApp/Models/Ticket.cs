using System;
namespace MerchApp.Models
{
    public class Ticket
    {
        public int Id { get; set; }
        public string ticketNum { get; set; }
        public string Cliente { get; set; }
        public string Modelo { get; set; }
        public string Serial { get; set; }
        public string Prioridad { get; set; }
        public string Fecha { get; set; }

    }
}
