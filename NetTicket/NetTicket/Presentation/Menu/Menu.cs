using NetTicket.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetTicket.Presentation.Menu
{
    public class Menu
    {
        public void Iniciar()
        {
            int option;

            do
            {
                Console.WriteLine("Select A Table To Customize:");
                Console.WriteLine("Categorias");
                Console.WriteLine("Comentarios");
                Console.WriteLine("Estados");
                Console.WriteLine("Tickets");
                Console.WriteLine("Usuarios");
                Console.WriteLine("Exit Menu");

                Console.WriteLine("‼Enter Your Choice‼ →");
                option = Convert.ToInt32(Console.ReadLine());
            }while (option !=6);
        }

    }
}
