using NetTicket.Data.RepositoriesCRUD;
using NetTicket.Models;
using NetTicket.Services.BusinessRules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace NetTicket.Services.DbRules
{
    public class ComentarioService
    {
        private readonly ComentarioRepository _comentarioRepository;

        public ComentarioService(ComentarioRepository comentarioRepository)
        {
            _comentarioRepository = comentarioRepository;
        }

        public bool ValidarTexto(Comentario comentario) => !string.IsNullOrWhiteSpace(comentario.Texto);

        public async Task<int> CountAllComentarios() => await _comentarioRepository.CountAllComentarios();


        public async Task<List<Comentario>> ObtenerTodos()
        {
            var comentarios = await _comentarioRepository.ObtenerTodos();

            foreach (var comentario in comentarios)
            {
                if (!ValidarTexto(comentario)) continue;

                comentario.Texto = RulesServices.AgregarPreFijo(RulesServices.ConvertirMayuscula(RulesServices.EliminarEspaciosVacios(comentario.Texto)));
            }
            return comentarios;
        }

        public async Task<Comentario?> ObtenerPorId(int id)
        {
            var comentario = await _comentarioRepository.ObtenerPorId(id);
            if (comentario == null || !ValidarTexto(comentario))return null;

            comentario.Texto = RulesServices.AgregarPreFijo(RulesServices.ConvertirMayuscula(RulesServices.EliminarEspaciosVacios(comentario.Texto)));
            return comentario;
        }

        public async Task<Comentario?> Create(int ticketId, int usuarioId, string texto)
        {
            return await _comentarioRepository.Create(ticketId, usuarioId, texto);
        }

        public async Task<bool> Update(int id, string texto)
        {
            return await _comentarioRepository.Update(id, texto);
        }
           
    }
}
