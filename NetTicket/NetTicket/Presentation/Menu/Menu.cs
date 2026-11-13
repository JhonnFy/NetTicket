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

            do
            {
                var countCat = _menuContext.CategoriaMenu.CountAllCategorias();
                var countCom = _menuContext.ComentarioMenu.CountAllComentarios();
                var countEst = _menuContext.EstadoMenu.countAllEstados();
                var countTck = _menuContext.TicketMenu.countAllTickets();
                var countUsr = _menuContext.UsuarioMenu.countAllUsuarios();

                Console.Clear();
                AnsiConsole.Write(
                new Panel(new Markup("[bold cyan]Welcome To TicketsDb[/]").Centered())
                .Border(BoxBorder.Rounded)
                .BorderColor(Color.Cyan)
                .Expand()
                );

                AnsiConsole.Write(
                new Panel(
                    $"[[{countCat}]]-[[Categorias]]-[[Registradas]]\n" +
                    $"[[{countCom}]]-[[Comentarios]]-[[Registrados]]\n" +
                    $"[[{countEst}]]-[[Estados]]-[[Registrados]]\n" +
                    $"[[{countTck}]]-[[Tickets]]-[[Registrados]]\n" +
                    $"[[{countUsr}]]-[[Usuarios]]-[[Registrados]]"
                )
                    .Border(BoxBorder.Rounded)
                    .BorderColor(Color.Cyan)
                    .Expand()
                );

                var menu = new SelectionPrompt<int>()
                    .PageSize(6)
                    .HighlightStyle(new Style(Color.Black, Color.Aqua, Decoration.Bold))
                    .AddChoices(1, 2, 3, 4, 5, 6)
                    .UseConverter(option => option switch
                {
                    1 => "Categorías",
                    2 => "Comentarios",
                    3 => "Estados",
                    4 => "Tickets",
                    5 => "Usuarios",
                    6 => "Exit Menu",
                    _ => "Unknown"
                });

                optionMenu = AnsiConsole.Prompt(menu);
                Console.Clear();


                switch (optionMenu)
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
                        Environment.Exit(0);
                        break;
                }
            }while (optionMenu != 6);
        }
    }
}

