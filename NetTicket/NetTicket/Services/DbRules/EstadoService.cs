using NetTicket.Data.RepositoriesCRUD;
using NetTicket.Models;
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

        public bool ValidarNombre(Estado e)
        {
            if (string.IsNullOrWhiteSpace(e.Nombre))
            {
                return false;
            }
            return true;
        }
        
        public List<Estado> ObtenerTodos()
        {
            return _repository.ObtenerTodos();
        }

        public Estado? ObtenerPorId(int id)
        {
            return _repository.ObtenerPorId(id);
        }

        public Estado? Create(string nombre)
        {
            return _repository.Create(nombre);
        }

        public bool Update(int id, string nombre)
        {
            return _repository.Update(id, nombre);
        }

        public bool Delete(int id)
        {
            return _repository.Delete(id);
        }

    }
}
