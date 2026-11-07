using NetTicket.DependencyInjection;
using Spectre.Console;
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
        private readonly MenuContext _menuContext;
        
        public Menu(MenuContext menuContext)
        {
            _menuContext = menuContext;
        }

        public void Iniciar()
        {
            int optionMenu;

            Console.Clear();

            var countCat = _menuContext.CategoriaMenu.countAllCategorias();


            AnsiConsole.Write(new Markup("[bold cyan]Welcome To TicketsDb[/]").Centered());
            Console.WriteLine($"[{countCat}]-[Categorias]-[Registradas]");
            Console.WriteLine($"[{countCat}]-[Comentarios]-[Registrados]");
            Console.WriteLine($"[{countCat}]-[Estados]-[Registrados]");
            Console.WriteLine($"[{countCat}]-[Tickets]-[Registrados]");
            Console.WriteLine($"[{countCat}]-[Usuarios]-[Registrados]");

            do
            {
                //Console.WriteLine("Select A Table To Customize:");
                //Console.WriteLine("1 → Categorias");
                //Console.WriteLine("2 → Comentarios");
                //Console.WriteLine("3 → Estados");
                //Console.WriteLine("4 → Tickets");
                //Console.WriteLine("5 → Usuarios");
                //Console.WriteLine("6 → Exit Menu");

                //Console.WriteLine("‼Enter Your Choice‼ →");
                optionMenu = Convert.ToInt32(Console.ReadLine());
                Console.Clear();


                switch(optionMenu)
                {
                    case 1:
                        _menuContext.CategoriaMenu.RunCategoriaMenu();
                        break;

                    case 2:
                        _menuContext.ComentarioMenu.RunComentarioMenu();
                        break;

                    case 3:
                        _menuContext.EstadoMenu.RunEstadoMenu();
                        break;
                    case 4:
                        _menuContext.TicketMenu.RunTicketMenu();
                        break;
                    case 5:
                        _menuContext.UsuarioMenu.RunUsuarioMenu();
                        break;
                    case 6:
                        break;
                }
            }while (optionMenu != 6);
        }
    }
}
