using NetTicket.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetTicket.Services.DbRules
{
    public class TicketService
    {

        public bool ValidarTitulo(Ticket t)
        {
            if (string.IsNullOrWhiteSpace(t.Titulo))
            {
                return false;
            }

            return true;
        }

    }
}
