using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetTicket.Models
{
    public class Ticket
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Descripcion { get; set; }
        public int UsuarioId { get; set; }
        public int CategoriaId { get; set; }
        public int EstadoId { get; set; }
        public DateTime FechaCreacion { get; set; }


        public Ticket ()
        {
            Id = 0;
            Titulo = string.Empty;
            Descripcion = string.Empty;
            UsuarioId = 0;
            CategoriaId = 0;
            EstadoId = 0;
            FechaCreacion = DateTime.MinValue;
        }

    }
}
