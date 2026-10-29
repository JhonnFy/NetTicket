using NetTicket.Data.RepositoriesCRUD;
using NetTicket.Models;
using NetTicket.Services.BusinessRules;
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

        public bool ValidarNombre(Usuario usuario)
        {
            if (string.IsNullOrWhiteSpace(usuario.Nombre)) return false;
            return true;
        }

        public bool ValidarEmail(Usuario usuario)
        {
            if (string.IsNullOrWhiteSpace(usuario.Email) || !usuario.Email.Contains("@")) return false;
            return true;
        }

        public List<Usuario> ObtenerTodos()
        {
            var usuarios = _repository.ObtenerTodos();

            foreach(var usuario in usuarios)
            {
                usuario.Nombre = RulesServices.AgregarPreFijo(RulesServices.ConvertirMayuscula(RulesServices.EliminarEspaciosVacios(usuario.Nombre)));
                usuario.Email = RulesServices.AgregarPreFijo(RulesServices.ConvertirMayuscula(RulesServices.EliminarEspaciosVacios(usuario.Email)));
                usuario.Area = RulesServices.AgregarPreFijo(RulesServices.ConvertirMayuscula(RulesServices.EliminarEspaciosVacios(usuario.Nombre)));
                


            }

            return usuarios;

        }

        public Usuario? ObtenerPorId(int id)
        {
            return _repository.ObtenerPorId(id);
        }

        public Usuario? Create(string nombre, string email, string area)
        {
            return _repository.Create(nombre, email, area);
        }

        public bool Update(int id, string nombre, string email, string area)
        {
            return _repository.Update(id, nombre, email, area);
        }

        public bool Delete(int id)
        {
            return _repository.Delete(id);
        }

    }
}
