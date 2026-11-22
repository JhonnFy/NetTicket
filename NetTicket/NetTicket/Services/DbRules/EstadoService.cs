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
    public class EstadoService
    {
        private readonly EstadoRepository _estadoRepository;

        public EstadoService(EstadoRepository estadoRepository)
        {
            _estadoRepository = estadoRepository;
        }


        public int CountAllEstados() => _estadoRepository.CountAllEstados();

        public bool ValidarNombre(Estado estado) => !string.IsNullOrWhiteSpace(estado.Nombre);


        public List<Estado> ObtenerTodos()
        {
            var estados = _estadoRepository.ObtenerTodos();

            foreach(var estado in estados)
            {
                if (!ValidarNombre(estado))continue;

                estado.Nombre = RulesServices.AgregarPreFijo(RulesServices.ConvertirMayuscula(RulesServices.EliminarEspaciosVacios(estado.Nombre)));
            }
            return estados;
        }

        public Estado? ObtenerPorId(int id)
        {
            var estado = _estadoRepository.ObtenerPorId(id);

            if (estado == null || !ValidarNombre(estado)) return null;

            estado.Nombre = RulesServices.AgregarPreFijo(RulesServices.ConvertirMayuscula(RulesServices.EliminarEspaciosVacios(estado.Nombre)));

            return estado;
        }

        public Estado? Create(string nombre)
        {
            return _estadoRepository.Create(nombre);
        }

        public bool Update(int id, string nombre)
        {
            return _estadoRepository.Update(id,nombre);
        }

        public bool Delete(int id)
        {
            return _estadoRepository.Delete(id);
        }

    }
}
