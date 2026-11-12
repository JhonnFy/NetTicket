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
        private readonly EstadoRepository _repository;

        public EstadoService(EstadoRepository repository)
        {
            _repository = repository;
        }

        public int CountAllEstados()
        {
            var countEst = _repository.CountAllEstados();
            return countEst;
        }

        public bool ValidarNombre(Estado estado)
        {
            if (string.IsNullOrWhiteSpace(estado.Nombre)) return false;
            return true;
        }

        public List<Estado> ObtenerTodos()
        {
            var estados = _repository.ObtenerTodos();

            foreach(var estado in estados)
            {
                if (!ValidarNombre(estado))continue;

                estado.Nombre = RulesServices.AgregarPreFijo(RulesServices.ConvertirMayuscula(RulesServices.EliminarEspaciosVacios(estado.Nombre)));
            }
            return estados;
        }

        public Estado? ObtenerPorId(int id)
        {
            var estado = _repository.ObtenerPorId(id);

            if (estado == null || !ValidarNombre(estado)) return null;

            estado.Nombre = RulesServices.AgregarPreFijo(RulesServices.ConvertirMayuscula(RulesServices.EliminarEspaciosVacios(estado.Nombre)));

            return estado;
        }

        public Estado? Create(string nombre)
        {
            return _repository.Create(nombre);
        }

        public bool Update(int id, string nombre)
        {
            return _repository.Update(id,nombre);
        }

        public bool Delete(int id)
        {
            return _repository.Delete(id);
        }

    }
}
