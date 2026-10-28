using NetTicket.Data.RepositoriesCRUD;
using NetTicket.Models;
using System;
using System.Collections.Generic;
using System.Linq;
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
    }
}
