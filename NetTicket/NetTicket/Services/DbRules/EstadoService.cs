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
        public async  Task<int> CountAllEstados() => await _estadoRepository.CountAllEstados();

        public bool ValidarNombre(Estado estado) => !string.IsNullOrWhiteSpace(estado.Nombre);

        public async Task<List<Estado>> ObtenerTodos()
        {
            var estados = await _estadoRepository.ObtenerTodos();

            foreach(var estado in estados)
            {
                if (!ValidarNombre(estado))continue;

                estado.Nombre = RulesServices.AgregarPreFijo(RulesServices.ConvertirMayuscula(RulesServices.EliminarEspaciosVacios(estado.Nombre)));
            }
            return estados;
        }

        public async Task<Estado?> ObtenerPorId(int id)
        {
            var estado = await _estadoRepository.ObtenerPorId(id);

            if (estado == null || !ValidarNombre(estado)) return null;

            estado.Nombre = RulesServices.AgregarPreFijo(RulesServices.ConvertirMayuscula(RulesServices.EliminarEspaciosVacios(estado.Nombre)));

            return estado;
        }

        public async Task<Estado?> Create(string nombre)
        {
            return await _estadoRepository.Create(nombre);
        }

        public async Task<bool> Update(int id, string nombre)
        {
            return await _estadoRepository.Update(id,nombre);
        }

        public async Task<bool> Delete(int id)
        {
            return await _estadoRepository.Delete(id);
        }

    }
}

