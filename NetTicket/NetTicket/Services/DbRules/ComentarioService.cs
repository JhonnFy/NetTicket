using NetTicket.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetTicket.Services.DbRules
{
    public class ComentarioService
    {
        public bool ValidarTexto(Comentario c)
        {
            if (string.IsNullOrWhiteSpace(c.Texto))
            {
                return false;
            }
            return true;
        }
    }
}
