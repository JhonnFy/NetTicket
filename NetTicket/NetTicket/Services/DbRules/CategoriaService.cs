using NetTicket.Data.RepositoriesCRUD;
using NetTicket.Models;
using NetTicket.Services.BusinessRules;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
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

        public bool ValidarNombre(Categoria categoria)
        {
            if (string.IsNullOrWhiteSpace(categoria.Nombre)) return false;
            return true;
        }

        public List<Categoria> ObtenerTodos()
        {
            var categorias = _repository.ObtenerTodos();

            foreach (var categoria in categorias)
            {
                if (!ValidarNombre(categoria)) continue;

                categoria.Nombre = RulesServices.AgregarPreFijo(RulesServices.ConvertirMayuscula(RulesServices.EliminarEspaciosVacios(categoria.Nombre)));
            }
            return categorias;
        }

        public Categoria? ObtenerPorId(int id)
        {
            var categoria = _repository.ObtenerPorId(id);

            if (categoria == null || !ValidarNombre(categoria)) return null;

            categoria.Nombre = RulesServices.AgregarPreFijo(RulesServices.ConvertirMayuscula(RulesServices.EliminarEspaciosVacios(categoria.Nombre)));

            return categoria;

        }

        public Categoria? Create(string nombre)
        {
            return _repository.Create(nombre);
        }

        public bool Update(int id, string nombre)
        {

        }

        public bool Delete(int id)
        {

        }
    }
}
