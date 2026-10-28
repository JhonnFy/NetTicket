using NetTicket.Data.RepositoriesCRUD;
using NetTicket.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetTicket.Services.DbRules
{
    public class CategoriaService
    {
        private readonly CategoriaRepository _repository;
        public CategoriaService(CategoriaRepository repository)
        {
            _repository = repository;
        }

        public bool ValidarNombre(Categoria c)
        {
            if (string.IsNullOrWhiteSpace(c.Nombre))
            {
                return false;

            }
            return true;
        }

        public List<Categoria> ObtenerTodos()
        {
            return _repository.ObtenerTodos();
        }

        public Categoria? ObtenerPorId(int id)
        {
            return _repository.ObtenerPorId(id);
        }

        public Categoria? Create(string nombre)
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
