using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetTicket.Api.Output.OutputDTOs
{
    public class ComentariosOutput
    {
        public int Id { get; set; }
        public int TicketId { get; set; }
        public int UsuarioId { get; set; }
        public string Texto { get; set; } = string.Empty;
        public DateTime Fecha { get; set; }
    }
}
