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

        public int CountAllUsuarios() => _repository.countAllUsuarios();

        public bool ValidarNombre(Usuario usuario) => !string.IsNullOrWhiteSpace(usuario.Nombre);
        public bool ValidarEmail(Usuario usuario) => !string.IsNullOrWhiteSpace(usuario.Email) && usuario.Email.Contains("@");


        public List<Usuario> ObtenerTodos()
        {
            var usuarios = _repository.ObtenerTodos();

            foreach(var usuario in usuarios)
            {
                if (!ValidarNombre(usuario) || !ValidarEmail(usuario))continue;

                usuario.Nombre = RulesServices.AgregarPreFijo(RulesServices.ConvertirMayuscula(RulesServices.EliminarEspaciosVacios(usuario.Nombre)));
                usuario.Email =  RulesServices.EliminarEspaciosVacios(usuario.Email);
                usuario.Area = RulesServices.AgregarPreFijo(RulesServices.ConvertirMayuscula(RulesServices.EliminarEspaciosVacios(usuario.Area)));
            }
            return usuarios;    
        }

        public Usuario? ObtenerPorId(int id)
        {
            var usuario = _repository.ObtenerPorId(id);

            if (usuario == null || !ValidarNombre(usuario) || !ValidarEmail(usuario)) return null;
            

            usuario.Nombre = RulesServices.AgregarPreFijo(RulesServices.ConvertirMayuscula(RulesServices.EliminarEspaciosVacios(usuario.Nombre)));
            usuario.Email = RulesServices.EliminarEspaciosVacios(usuario.Email);
            usuario.Area = RulesServices.AgregarPreFijo(RulesServices.ConvertirMayuscula(RulesServices.EliminarEspaciosVacios(usuario.Area)));

            return usuario;
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
