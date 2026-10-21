using NetTicket.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetTicket.Services.DbRules
{
    public class CategoriaService
    {
        public bool ValidarNombre(CategoriaModel c)
        {
            if (string.IsNullOrWhiteSpace(c.Nombre))
            {
                return false;

            }
            return true;
        }
    }

}
