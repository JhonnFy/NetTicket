using NetTicket.Data.RepositoriesCRUD;
using NetTicket.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace NetTicket.Services.DbRules
{
    public class ComentarioService
    {
        private readonly ComentarioRepository _repository;

        public ComentarioService(ComentarioRepository repository)
        {
            _repository = repository;
        }

        public bool ValidarTexto(Comentario c)
        {
            if (string.IsNullOrWhiteSpace(c.Texto))
            {
                return false;
            }
            return true;
        }


        public List<Comentario> ObtenerTodos()
        {
            return _repository.ObtenerTodos();
        }

        public Comentario? ObtenerPorId(int id)
        {
            return _repository.ObtenerPorId(id);
        }

        public Comentario? Create(int ticketId, int usuarioId, string texto)
        {
            return _repository.Create(ticketId, usuarioId, texto);
        }

        public bool Update(int id, string texto)
        {
            return _repository.Update(id, texto);
        }

    }
}

