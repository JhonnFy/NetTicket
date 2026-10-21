using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetTicket.Models
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Email { get; set; }
        public string Area { get; set; }

        public Usuario()
        {
            Id = 0;
            Nombre = string.Empty;
            Email = string.Empty;
            Area = string.Empty;
        }
    }
}
