using NetTicket.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetTicket.Services.DatabaseValidation
{
    public class EstadoService
    {
        public bool ValidarNombre(Estado e)
        {
            if (string.IsNullOrWhiteSpace(e.Nombre))
            {
                return false;
            }
            return true;
        }
    }
}
