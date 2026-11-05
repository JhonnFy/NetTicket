using NetTicket.DependencyInjection;
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
            
            do
            {
                Console.Clear();

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

                        break;

                    case 2:
                        new ComentarioMenu().RunComentarioMenu();
                        break;

                    case 3:
                        new EstadoMenu().RunEstadoMenu();

                        break;
                    case 4:
                        new TicketMenu().RunTicketMenu();

                        break;
                    case 5:
                        new UsuarioMenu().RunUsuarioMenu();

                        break;
                    case 6:
                        break;
                }
            }while (optionMenu != 6);
        }
    }
}
