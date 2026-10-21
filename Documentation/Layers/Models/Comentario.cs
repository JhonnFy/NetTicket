using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetTicket.Models
{
    public class Comentario
    {
        public int Id { get; set; }
        public int TicketId { get; set; }
        public int UsuarioId { get; set; }
        public string Texto { get; set; }
        public DateTime Fecha { get; set; }

        public Comentario()
        {
            Id = 0;
            TicketId = 0;
            UsuarioId = 0;
            Texto = string.Empty;
            Fecha = DateTime.MinValue;
        }
    }
}
