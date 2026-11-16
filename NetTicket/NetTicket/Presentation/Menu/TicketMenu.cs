using NetTicket.Services.DbRules;
using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetTicket.Presentation.Menu
{
    public class TicketMenu
    {

        private readonly TicketService _ticketService;
        private readonly UsuarioService _usuarioService;
        private readonly CategoriaService _categoriaService;
        private readonly EstadoService _estadoService;

        public TicketMenu(TicketService ticketService, UsuarioService usuarioService, CategoriaService categoriaService, EstadoService estadoService)
        {
            _ticketService = ticketService;
            _usuarioService = usuarioService;
            _categoriaService = categoriaService;
            _estadoService = estadoService;
        }

        public int CountAllTickets() => _ticketService.CountAllTickets();

        public void CabeceraTicket()
        {
            AnsiConsole.Write(
                new Panel(new Markup("[bold yellow]Welcome To Ticket Menu[/]").Centered())
                .Border(BoxBorder.Rounded)
                .BorderColor(Color.Cyan)
                .Expand()
            );
        }


        private void TicketMenuCase1()
        {
            Console.Clear();
            CabeceraTicket();
            Console.Write("Ingrese el nombre del nuevo estado: ");


        }


        public void RunTicketMenu()
        {
            int optionMenu;

            do
            {
                CabeceraTicket();

                var menu = new SelectionPrompt<int>()
                .PageSize(6)
                .HighlightStyle(new Style(Color.Black, Color.Aqua, Decoration.Bold))
                .AddChoices(1, 2, 3, 4, 5)
                .UseConverter(option => option switch
                {
                    1 => "Create",
                    2 => "Read",
                    3 => "ReadId",
                    4 => "Update",
                    5 => "Return To Main Menu",
                    _ => "Unknown"
                });

                optionMenu = AnsiConsole.Prompt(menu);
                Console.Clear();

                switch(optionMenu)
                {
                    case 1:
                            TicketMenuCase1();
                        break;
                    case 2:
                            
                        break;
                    case 3:
                            
                        break;
                    case 4:
                            
                        break;
                }
            } while (optionMenu !=6);
        }
    }
}
