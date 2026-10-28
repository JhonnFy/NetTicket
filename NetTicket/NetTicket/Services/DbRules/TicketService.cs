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
        

        public List<Ticket> ObtenerTodos()
        {
            return _repository.ObtenerTodos();
        }

        public Ticket? ObtenerPorId(int id)
        {
            return _repository.ObtenerPorId(id);
        }

        public Ticket? Create(string titulo, string descripcion, int usuarioId, int categoriaId, int estadoId)
        {
            return _repository.Create(titulo,descripcion,usuarioId,categoriaId,estadoId);
        }

        public bool Update(int id, string titulo, string descripcion)
        {
            return _repository.Update(id,titulo,descripcion);
        }

    }
}
