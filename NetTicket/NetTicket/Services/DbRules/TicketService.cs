using NetTicket.Data.RepositoriesCRUD;
using NetTicket.Models;
using NetTicket.Services.BusinessRules;
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

        public bool ValidarTitulo(Ticket ticket)
        {
            if (string.IsNullOrWhiteSpace(ticket.Titulo)) return false;
            return true;
        }

        public List<Ticket> ObtenerTodos()
        {
            var tickets = _repository.ObtenerTodos();

            foreach(var ticket in tickets)
            {
                if (!ValidarTitulo(ticket)) continue;

                ticket.Titulo = RulesServices.AgregarPreFijo(RulesServices.ConvertirMayuscula(RulesServices.EliminarEspaciosVacios(ticket.Titulo)));
                ticket.Descripcion = RulesServices.AgregarPreFijo(RulesServices.ConvertirMayuscula(RulesServices.EliminarEspaciosVacios(ticket.Descripcion)));
            }

            return tickets;

        }

        public Ticket? ObtenerPorId(int id)
        {
            var ticket = _repository.ObtenerPorId(id);

            if (ticket == null || !ValidarTitulo(ticket)) return null;

            ticket.Titulo = RulesServices.AgregarPreFijo(RulesServices.ConvertirMayuscula(RulesServices.EliminarEspaciosVacios(ticket.Titulo)));
            ticket.Descripcion = RulesServices.AgregarPreFijo(RulesServices.ConvertirMayuscula(RulesServices.EliminarEspaciosVacios(ticket.Descripcion)));

            return ticket;
        }
        

    }
}
