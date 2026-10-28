using NetTicket.Data.RepositoriesCRUD;
using NetTicket.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetTicket.Services.DbRules
{
    public class UsuarioService
    {
        private readonly UsuarioRepository _repository;

        public UsuarioService(UsuarioRepository repository)
        {
            _repository = repository;
        }

        public bool ValidarNombre(Usuario u)
        {
            if (string.IsNullOrWhiteSpace(u.Nombre))
            {
                return false;
            }
            return true;
        }

        public bool ValidarEmail(Usuario u)
        {
            if (string.IsNullOrWhiteSpace(u.Email) || !u.Email.Contains("@"))
            {
                return false;
            }
            return true;
        }

    }
}
