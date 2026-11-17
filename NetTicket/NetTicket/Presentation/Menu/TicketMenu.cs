using NetTicket.Models;
using NetTicket.Services.DbRules;
using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
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
            Console.Write("Ingrese el titulo del nuevo estado: ");
            string titulo = Console.ReadLine()?.Trim();

            if(string.IsNullOrWhiteSpace(titulo))
            {
                Console.Clear();
                AnsiConsole.Write(
                    new Panel($"[bold red]No se permiten valores vacíos.[/]")
                    .Border(BoxBorder.Rounded)
                    .BorderColor(Color.Red)
                    .Expand()
                );
                return;
            }

            Console.Write("Ingrese la descripción del estado: ");
            string descripcion = Console.ReadLine()?.Trim();
            
            if(string.IsNullOrWhiteSpace(descripcion))
            {
                Console.Clear();
                AnsiConsole.Write(
                    new Panel($"[bold red]No se permiten valores vacíos.[/]")
                    .Border(BoxBorder.Rounded)
                    .BorderColor(Color.Red)
                    .Expand()
                );
                return;
            }
            

            Console.Write("Ingrese el identificador del Usuario_id: ");
            if (!int.TryParse(Console.ReadLine(), out int usuarioId))
            {
                Console.Clear();
                AnsiConsole.Write(
                    new Panel("[bold red] El Usuario_Id ingresado no es válido; Solo se permiten valores numéricos.[/]")
                    .Border(BoxBorder.Rounded)
                    .BorderColor(Color.Red)
                    .Expand()
                );
                return;
            }
            
            
            var usuario = _ticketService.ObtenerPorId(usuarioId);

            if(usuario == null)
            {
                Console.Clear();
                AnsiConsole.Write(
                    new Panel($"[bold red]El Usuario_Id {usuarioId} proporcionado no existe en la base de datos.[/]")
                        .Border(BoxBorder.Rounded)
                        .BorderColor(Color.Red)
                        .Expand()
                );
                return;
            }

            Console.Write("Ingrese el identificador de la  Categoria_id: ");
            if(!int.TryParse(Console.ReadLine(), out int categoriaId))
            {
                Console.Clear();
                AnsiConsole.Write(
                    new Panel("[bold red] La Categoria_id ingresada no es válida; Solo se permiten valores numéricos.[/]")
                    .Border(BoxBorder.Rounded)
                    .BorderColor(Color.Red)
                    .Expand()
                );
                return;
            }

            var categoria = _ticketService.ObtenerPorId(categoriaId);

            if (categoria == null)
            {
                Console.Clear();
                AnsiConsole.Write(
                    new Panel($"[bold red]La categoriaId {categoriaId} proporcionada no existe en la base de datos.[/]")
                    .Border(BoxBorder.Rounded)
                    .BorderColor(Color.Red)
                    .Expand()
                );
                return;
            }


            Console.Write("Ingrese el identificador del Estado_id: ");
            if (!int.TryParse(Console.ReadLine(), out int estadoId))
            {
                Console.Clear();
                AnsiConsole.Write(
                    new Panel("[bold red] El Estado_id ingresado no es válido; Solo se permiten valores numéricos.[/]")
                    .Border(BoxBorder.Rounded)
                    .BorderColor(Color.Red)
                    .Expand()
                );
                return;
            }

            var estado = _estadoService.ObtenerPorId(estadoId);

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
