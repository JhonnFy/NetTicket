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
        private readonly TicketRepository _ticketRepository;

        public TicketService(TicketRepository ticketRepository)
        {
            _ticketRepository = ticketRepository;
        }

        public bool ValidarTitulo(Ticket ticket) => !string.IsNullOrWhiteSpace(ticket.Titulo);
        public int CountAllTickets() => _ticketRepository.CountAllTickets();

        
        public List<Ticket> ObtenerTodos()
        {
            var tickets = _ticketRepository.ObtenerTodos();

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
            var ticket = _ticketRepository.ObtenerPorId(id);

            if (ticket == null || !ValidarTitulo(ticket)) return null;

            ticket.Titulo = RulesServices.AgregarPreFijo(RulesServices.ConvertirMayuscula(RulesServices.EliminarEspaciosVacios(ticket.Titulo)));
            ticket.Descripcion = RulesServices.AgregarPreFijo(RulesServices.ConvertirMayuscula(RulesServices.EliminarEspaciosVacios(ticket.Descripcion)));

            return ticket;
        }

        public Ticket? Create (string titulo, string descripcion, int usuarioId, int categoriaId, int estadoId)
        {
            return _ticketRepository.Create(titulo, descripcion, usuarioId, categoriaId, estadoId);
        }
        
        public bool Update(int id, string titulo, string descripcion)
        {
            return _ticketRepository.Update(id, titulo, descripcion);
        }

    }
}
