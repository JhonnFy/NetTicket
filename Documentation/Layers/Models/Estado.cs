using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetTicket.Models
{
    public class Estado
    {
        public int Id { get; set; }
        public string Nombre { get; set; }

        public Estado ()
        {
            Id = 0;
            Nombre = string.Empty;
        }


    }
}
