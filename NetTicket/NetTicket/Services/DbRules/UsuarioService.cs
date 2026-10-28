using NetTicket.Data.RepositoriesCRUD;
using NetTicket.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
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

        public bool ValidarNombre(string nombre)
        {
            if (string.IsNullOrWhiteSpace(nombre)) return false;
            return true;
        }

        public bool ValidarEmail(Usuario u)
        {
            if (string.IsNullOrWhiteSpace(u.Email) || !u.Email.Contains("@")) return false;
            return true;
        }

        public List<Usuario> ObtenerTodos()
        {
            return _repository.ObtenerTodos();
        }

        public Usuario? ObtenerPorId(int id)
        {
            return _repository.ObtenerPorId(id);
        }




    }
}
