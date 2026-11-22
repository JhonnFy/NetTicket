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
        private readonly UsuarioRepository _usuarioRepository;

        public UsuarioService(UsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }
                
        public async Task<int> CountAllUsuarios() => await _usuarioRepository.CountAllUsuarios();


        public bool ValidarNombre(Usuario usuario) => !string.IsNullOrWhiteSpace(usuario.Nombre);
        public bool ValidarEmail(Usuario usuario) => !string.IsNullOrWhiteSpace(usuario.Email) && usuario.Email.Contains("@");


        public async Task<List<Usuario>> ObtenerTodos()
        {
            var usuarios = await _usuarioRepository.ObtenerTodos();

            foreach(var usuario in usuarios)
            {
                if (!ValidarNombre(usuario) || !ValidarEmail(usuario))continue;

                usuario.Nombre = RulesServices.AgregarPreFijo(RulesServices.ConvertirMayuscula(RulesServices.EliminarEspaciosVacios(usuario.Nombre)));
                usuario.Email =  RulesServices.EliminarEspaciosVacios(usuario.Email);
                usuario.Area = RulesServices.AgregarPreFijo(RulesServices.ConvertirMayuscula(RulesServices.EliminarEspaciosVacios(usuario.Area)));
            }
            return usuarios;    
        }


        public async Task<Usuario?> ObtenerPorId(int id)
        {
            var usuario = await _usuarioRepository.ObtenerPorId(id);

            if (usuario == null || !ValidarNombre(usuario) || !ValidarEmail(usuario)) return null;
            

            usuario.Nombre = RulesServices.AgregarPreFijo(RulesServices.ConvertirMayuscula(RulesServices.EliminarEspaciosVacios(usuario.Nombre)));
            usuario.Email = RulesServices.EliminarEspaciosVacios(usuario.Email);
            usuario.Area = RulesServices.AgregarPreFijo(RulesServices.ConvertirMayuscula(RulesServices.EliminarEspaciosVacios(usuario.Area)));

            return usuario;
        }

        public async Task<Usuario?> Create(string nombre, string email, string area)
        {
            return await _usuarioRepository.Create(nombre, email, area);
        }

        public async Task<bool> Update(int id, string nombre, string email, string area)
        {
            return await _usuarioRepository.Update(id, nombre, email, area);
        }

        public async Task<bool> Delete(int id)
        {
            return await _usuarioRepository.Delete(id);
        }

    }
}
