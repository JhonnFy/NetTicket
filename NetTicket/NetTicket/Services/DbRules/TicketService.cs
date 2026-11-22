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
        public async Task<int> CountAllTickets() => await _ticketRepository.CountAllTickets();

        
        public async  Task<List<Ticket>> ObtenerTodos()
        {
            var tickets = await _ticketRepository.ObtenerTodos();

            foreach(var ticket in tickets)
            {
                if (!ValidarTitulo(ticket)) continue;

                ticket.Titulo = RulesServices.AgregarPreFijo(RulesServices.ConvertirMayuscula(RulesServices.EliminarEspaciosVacios(ticket.Titulo)));
                ticket.Descripcion = RulesServices.AgregarPreFijo(RulesServices.ConvertirMayuscula(RulesServices.EliminarEspaciosVacios(ticket.Descripcion)));
            }

            return tickets;
        }

        public async Task<Ticket?> ObtenerPorId(int id)
        {
            var ticket = await _ticketRepository.ObtenerPorId(id);

            if (ticket == null || !ValidarTitulo(ticket)) return null;

            ticket.Titulo = RulesServices.AgregarPreFijo(RulesServices.ConvertirMayuscula(RulesServices.EliminarEspaciosVacios(ticket.Titulo)));
            ticket.Descripcion = RulesServices.AgregarPreFijo(RulesServices.ConvertirMayuscula(RulesServices.EliminarEspaciosVacios(ticket.Descripcion)));

            return ticket;
        }

        public async Task<Ticket?> Create (string titulo, string descripcion, int usuarioId, int categoriaId, int estadoId)
        {
            return await _ticketRepository.Create(titulo, descripcion, usuarioId, categoriaId, estadoId);
        }
        
        public async Task<bool> Update(int id, string titulo, string descripcion)
        {
            return await _ticketRepository.Update(id, titulo, descripcion);
        }

    }
}
