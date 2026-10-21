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
        //1-Poner todo en mayuscula.
        //2-Eliminar Espacio Vacios.
        //3-Asignar Un Pre-Fijo. 'AppTtickets'
        //4-Asignar El Formato De Fecha 'YYYY'-'MM'-'DD'

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

    }
}
