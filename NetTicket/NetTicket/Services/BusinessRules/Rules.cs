using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace NetTicket.Services.BusinessRules
{
    public class Rules
    {
      public static string ConvertirMayuscula(string cadena)
        {
            if (string.IsNullOrWhiteSpace(cadena))
            {
                return cadena;
            }
            return cadena.ToUpper();
        }

      public static string EliminarEspaciosVacios(string cadena)
        {
            if (string.IsNullOrWhiteSpace(cadena))
            {
                return cadena;
            }
            return cadena.Replace(" ", "");
        }

       public static string AgregarPreFijo(string cadena)
        {
            if (string.IsNullOrWhiteSpace(cadena))
            {
                return cadena;
            }

            return "AppTickets " + cadena;
        }

        public static string FormatoFecha(DateTime fecha)
        {
            return fecha.ToString("dd/MM/yyyy HH:mm:ss");

        }

    }
}
