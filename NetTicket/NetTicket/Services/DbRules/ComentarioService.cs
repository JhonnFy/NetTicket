using NetTicket.Data.RepositoriesCRUD;
using NetTicket.Models;
using NetTicket.Services.BusinessRules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Reflection.Metadata.Ecma335;
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

        public bool ValidarTexto(Comentario comentario)
        {
            if (string.IsNullOrWhiteSpace(comentario.Texto)) return false;
            return true;
        }

        public int countAllComentarios()
        {
            var countCom = _repository.countAllComentarios();
            return countCom;
        }


        public List<Comentario> ObtenerTodos()
        {
            var comentarios = _repository.ObtenerTodos();

            foreach (var comentario in comentarios)
            {
                if (!ValidarTexto(comentario)) continue;

                comentario.Texto = RulesServices.AgregarPreFijo(RulesServices.ConvertirMayuscula(RulesServices.EliminarEspaciosVacios(comentario.Texto)));
            }
            return comentarios;
        }

        public Comentario? ObtenerPorId(int id)
        {
            var comentario = _repository.ObtenerPorId(id);
            if (comentario == null || !ValidarTexto(comentario))return null;

            comentario.Texto = RulesServices.AgregarPreFijo(RulesServices.ConvertirMayuscula(RulesServices.EliminarEspaciosVacios(comentario.Texto)));
            return comentario;
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

