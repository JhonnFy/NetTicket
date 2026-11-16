using NetTicket.Services.DbRules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
 
namespace NetTicket.Presentation.Menu
{
    public class TicketMenu
    {
        private readonly TicketService _ticketService;

        public TicketMenu(TicketService ticketService)
        {
            _ticketService = ticketService;
        }

        public int CountAllTickets() => _ticketService.CountAllTickets();





       
    }
}
