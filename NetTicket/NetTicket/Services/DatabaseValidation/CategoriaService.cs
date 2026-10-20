using NetTicket.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetTicket.Services.DatabaseValidation
{
    public class CategoriaService
    {
        public bool ValidarNombre(Categoria c)
        {
            if (string.IsNullOrWhiteSpace(c.Nombre))
            {
                return false;
            }
            return true;
        }
    }
}
