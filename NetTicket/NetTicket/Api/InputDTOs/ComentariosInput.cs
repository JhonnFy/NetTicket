using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;

namespace NetTicket.Api.InputDTOs
{
    public class ComentariosInput
    {
        public int TicketId { get; set; }
        public int UsuarioId { get; set; }
        public string Texto { get; set; } = string.Empty;
        public DateTime Fecha { get; set; }
    }
}

