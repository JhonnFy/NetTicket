using NetTicket.Data.RepositoriesCRUD;
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
        private readonly TicketRepository _repository;

        public TicketService(TicketRepository repository)
        {
            _repository = repository;
        }


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
