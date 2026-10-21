using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetTicket.Models
{
    public class CategoriaModel
    {
        public int Id { get; set; }
        public string Nombre { get; set; }

        public CategoriaModel()
        {
            Id = 0;
            Nombre = string.Empty;
        }

    }
}
