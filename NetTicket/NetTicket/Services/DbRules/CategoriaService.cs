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
        private readonly CategoriaRepository _categoriaRepository;


        public CategoriaService(CategoriaRepository categoriaRepository)
        {
            _categoriaRepository = categoriaRepository;
        }

        public bool ValidarNombre(Categoria categoria) => !string.IsNullOrWhiteSpace(categoria.Nombre);

        public async Task<int> CountAllCategorias() => await _categoriaRepository.CountAllCategorias();


        public async Task<List<Categoria>> ObtenerTodos()
        {
            var categorias = await _categoriaRepository.ObtenerTodos();

            foreach (var categoria in categorias)
            {
                if (!ValidarNombre(categoria)) continue;

                categoria.Nombre = RulesServices.AgregarPreFijo(RulesServices.ConvertirMayuscula(RulesServices.EliminarEspaciosVacios(categoria.Nombre)));
            }
            return categorias;
        }

        public async Task<Categoria?> ObtenerPorId(int id)
        {
            var categoria = await _categoriaRepository.ObtenerPorId(id);

            if (categoria == null || !ValidarNombre(categoria)) return null;

            categoria.Nombre = RulesServices.AgregarPreFijo(RulesServices.ConvertirMayuscula(RulesServices.EliminarEspaciosVacios(categoria.Nombre)));

            return categoria;

        }

        public async Task<Categoria?> Create(string nombre)
        {
            var temp = new Categoria { Nombre = nombre };

            if (!ValidarNombre(temp)) return null;
            return await _categoriaRepository.Create(nombre);
        }

        public async Task<bool> Update(int id, string nombre)
        {
            return await _categoriaRepository.Update(id,nombre);
        }

        public async Task<bool> Delete(int id)
        {
            return await _categoriaRepository.Delete(id);
        }
    }
}
