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
            int optionMenu;

            do
            {
                Console.WriteLine("Select A Table To Customize:");
                Console.WriteLine("1 → Categorias");
                Console.WriteLine("2 → Comentarios");
                Console.WriteLine("3 → Estados");
                Console.WriteLine("4 → Tickets");
                Console.WriteLine("5 → Usuarios");
                Console.WriteLine("6 → Exit Menu");

                Console.WriteLine("‼Enter Your Choice‼ →");
                optionMenu = Convert.ToInt32(Console.ReadLine());

                switch(optionMenu)
                {
                    case 1:
                        new CategoriaMenu().IniciarCategoriaMenu();
                        break;

                    case 2:
                        new ComentarioMenu().IniciarComentarioMenu();
                        break;

                }
            }while (optionMenu != 6);
        }

    }
}
