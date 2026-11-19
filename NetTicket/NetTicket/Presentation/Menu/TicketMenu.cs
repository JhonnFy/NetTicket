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

        private void CabeceraTicket()
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
            Console.Write("Ingrese el título del nuevo ticket: ");
            string titulo = Console.ReadLine()?.Trim();

            if (string.IsNullOrWhiteSpace(titulo))
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

            Console.Write("Ingrese la descripción del ticket: ");
            string descripcion = Console.ReadLine()?.Trim();

            if (string.IsNullOrWhiteSpace(descripcion))
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

            var usuario = _usuarioService.ObtenerPorId(usuarioId);

            if (usuario == null)
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

            Console.Write("Ingrese el identificador de la Categoria_id: ");
            if (!int.TryParse(Console.ReadLine(), out int categoriaId))
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

            var categoria = _categoriaService.ObtenerPorId(categoriaId);

            if (categoria == null)
            {
                Console.Clear();
                AnsiConsole.Write(
                    new Panel($"[bold red]La categoria_id {categoriaId} proporcionada no existe en la base de datos.[/]")
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
                    new Panel("[bold red] El estado_id ingresado no es válido; Solo se permiten valores numéricos.[/]")
                    .Border(BoxBorder.Rounded)
                    .BorderColor(Color.Red)
                    .Expand()
                );
                return;
            }

            var estado = _estadoService.ObtenerPorId(estadoId);

            if (estado == null)
            {
                Console.Clear();
                AnsiConsole.Write(
                    new Panel($"[bold red]El Estado_id {estadoId} proporcionado no existe en la base de datos.[/]")
                    .Border(BoxBorder.Rounded)
                    .BorderColor(Color.Red)
                    .Expand()
                );
                return;
            }

            var createTicket = _ticketService.Create(titulo, descripcion, usuarioId, categoriaId, estadoId);
            Console.Clear();
            AnsiConsole.Write(
                new Panel($"[bold yellow]Id:[/] {createTicket.Id}," +
                $"\n[bold cyan]titulo:[/] {createTicket.Titulo}," +
                $"\n[bold cyan]descripcion:[/] {createTicket.Descripcion}," +
                $"\n[bold cyan]usuario_id:[/] {createTicket.UsuarioId}," +
                $"\n[bold cyan]categoria_id:[/] {createTicket.CategoriaId}," +
                $"\n[bold cyan]estado_id:[/] {createTicket.EstadoId}," +
                $"\n[bold cyan]fecha_creacion:[/] {createTicket.FechaCreacion}"
                )
                .Border(BoxBorder.Rounded)
                .Expand()
            );
        }

        private void TicketMenuCase2()
        {
            Console.Clear();
            CabeceraTicket();

            AnsiConsole.Write(
                new Panel($"[bold cyan]Tickets registrados en la base de datos: [/] {CountAllTickets()}")
                .Border(BoxBorder.Rounded)
                .BorderColor(Color.Cyan)
                .Expand()
                );

            var tickets = _ticketService.ObtenerTodos();

            if (tickets == null || !tickets.Any())
            {
                Console.Clear();
                AnsiConsole.Write(
                    new Panel("[bold yellow]No hay tickets registrados.[/]")
                    .Border(BoxBorder.Rounded)
                    .Expand()
                );
                return;
            }

            foreach (var ticket in tickets)
            {
                Console.WriteLine($"Id: {ticket.Id}, titulo: {ticket.Titulo}, descripcion: {ticket.Descripcion}, usuario_id: {ticket.UsuarioId}, categoria_id: {ticket.CategoriaId}, estado_id: {ticket.EstadoId}, fecha_creacion: {ticket.FechaCreacion}");
            }
            Console.WriteLine();
        }

        private void TicketMenuCase3()
        {
            Console.Clear();
            CabeceraTicket();

            Console.Write("Ingrese el parámetro de consulta: ");
            if(!int.TryParse(Console.ReadLine(),out int id))
            {
                Console.Clear();
                AnsiConsole.Write(
                new Panel("[bold red]El ID ingresado no es válido; Solo se permiten valores numéricos.[/]")
                .Border(BoxBorder.Rounded)
                .BorderColor(Color.Red)
                .Expand()
                );
                return;
            }

            var ticket = _ticketService.ObtenerPorId(id);
            Console.Clear();

            if(ticket == null)
            {
                AnsiConsole.Write(
                    new Panel($"[bold red]El Id {id} proporcionado no existe en la base de datos.[/]")
                    .Border(BoxBorder.Rounded)
                    .BorderColor(Color.Red)
                    .Expand()
                );
                return;
            }

            AnsiConsole.Write(
                new Panel($"[bold yellow]Id:[/] {ticket.Id}," +
                $"\n[bold cyan]titulo:[/] {ticket.Titulo}," +
                $"\n[bold cyan]descripcion:[/] {ticket.Descripcion}," +
                $"\n[bold cyan]usuario_id:[/] {ticket.UsuarioId}," +
                $"\n[bold cyan]categoria_id:[/] {ticket.CategoriaId}," +
                $"\n[bold cyan]estado_id:[/] {ticket.EstadoId}," +
                $"\n[bold cyan]fecha_creacion:[/] {ticket.FechaCreacion}"
                )
                .Border(BoxBorder.Rounded)
                .Expand()
            );
        }

        public void TicketMenuCase4()
        {
            Console.Clear();
            CabeceraTicket();

            Console.Write("Ingrese el ID del ticket que desea modificar: ");
            if(!int.TryParse(Console.ReadLine(), out int  id))
            {
                Console.Clear();
                AnsiConsole.Write(
                    new Panel($"[bold red]El ID ingresado no es válido; Solo se permiten valores numéricos.[/]")
                    .Border(BoxBorder.Rounded)
                    .BorderColor(Color.Red)
                    .Expand()
                );
                return;
            }


            var ticket = _ticketService.ObtenerPorId(id);
            if(ticket == null)
            {
                Console.Clear();
                AnsiConsole.Write(
                    new Panel($"[bold red]No existe un ticket con Id {id}.[/]")
                    .Border(BoxBorder.Rounded)
                    .BorderColor(Color.Red)
                    .Expand()
                );
                return;
            }

            Console.Write("Ingrese el nuevo titulo del ticket: ");
            string titulo = Console.ReadLine()?.Trim();

            if(string.IsNullOrWhiteSpace(titulo))
            {
                Console.Clear();
                AnsiConsole.Write(
                new Panel($"[bold red]El titulo no puede estar vacío; No se realizó ningún cambio.[/]")
                    .Border(BoxBorder.Rounded)
                    .BorderColor(Color.Red)
                    .Expand()
                );
                return;
            }


            Console.Write("Ingrese la nueva descripcion del ticket: ");
            string descripcion = Console.ReadLine()?.Trim();

            if (string.IsNullOrWhiteSpace(descripcion))
            {
                Console.Clear();
                AnsiConsole.Write(
                new Panel($"[bold red]La descripcion no puede estar vacía; No se realizó ningún cambio.[/]")
                    .Border(BoxBorder.Rounded)
                    .BorderColor(Color.Red)
                    .Expand()
                );
                return;
            }


            _ticketService.Update(id, titulo, descripcion);
            Console.Clear();

            AnsiConsole.Write(
                new Panel($"[bold yellow]Id:[/] {ticket.Id},\n" +
                $" [bold cyan]Titulo:[/] {ticket.Titulo},\n" +
                $" [bold cyan]Descripcion:[/] {ticket.Descripcion},\n" +
                $" [bold cyan]Usuario_id:[/] {ticket.UsuarioId},\n" +
                $" [bold cyan]Categoria_id:[/] {ticket.CategoriaId},\n" +
                $" [bold cyan]Estado_id:[/] {ticket.EstadoId},\n" +
                $" [bold cyan]Fecha_creacion:[/] {ticket.FechaCreacion}"
                )
                .Border(BoxBorder.Rounded)
                .Expand()
            );
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

                switch (optionMenu)
                {
                    case 1:
                            TicketMenuCase1();
                        break;
                    case 2:
                            TicketMenuCase2();
                        break;
                    case 3:
                            TicketMenuCase3();
                        break;
                    case 4:
                            TicketMenuCase4();
                        break;
                }
            } while (optionMenu != 5);
        }
    }
}
