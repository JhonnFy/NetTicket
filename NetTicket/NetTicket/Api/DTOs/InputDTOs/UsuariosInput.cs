using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;

namespace NetTicket.Api.DTOs.InputDTOs
{
    public class UsuariosInput
    {
        public string Nombre { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Area { get; set; } = string.Empty;
    }
}
