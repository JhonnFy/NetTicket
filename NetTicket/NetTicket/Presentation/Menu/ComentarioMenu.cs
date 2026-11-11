using Microsoft.Extensions.Configuration;
using NetTicket.Models;
using NetTicket.Services.DbRules;
using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetTicket.Presentation.Menu
{
    public class ComentarioMenu
    {
        private readonly ComentarioService _comentarioService;
        private readonly TicketService _ticketService;
        private readonly UsuarioService _usuarioService;

        public ComentarioMenu(ComentarioService comentarioService, TicketService ticketService, UsuarioService usuarioService)
        {
            _comentarioService = comentarioService;
            _ticketService = ticketService;
            _usuarioService = usuarioService;    
        }
        
        public int countAllComentarios() => _comentarioService.countAllComentarios();

        private void cabeceraComentarios()
        {
            AnsiConsole.Write(
                new Panel(new Markup("[bold yellow]Welcome To Comentarios Menu[/]").Centered())
                .Border(BoxBorder.Rounded)
                .BorderColor(Color.Cyan)
                .Expand()
            );
        }

        public void RunComentarioMenu()
        {
            int optionCmt;

            do
            {
                cabeceraComentarios();
                countAllComentarios();

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

                optionCmt = AnsiConsole.Prompt(menu);
                Console.Clear();

                switch(optionCmt)
                {
                    case 1:
                        cabeceraComentarios();

                        Console.Write("Ingrese el nombre del nuevo comentario: ");
                        string texto = Console.ReadLine()?.Trim();

                        if (string.IsNullOrWhiteSpace(texto))
                        {
                            Console.Clear();
                            AnsiConsole.Write(
                                new Panel($"[bold red]No se permiten valores vacíos.[/]")
                                    .Border(BoxBorder.Rounded)
                                    .BorderColor(Color.Red)
                                    .Expand()
                            );
                            break;
                        }
                        
                        Console.Write("Ingrese el identificador del Ticket_id: ");
                        if (!int.TryParse(Console.ReadLine(),out int ticketid))
                        {
                            Console.Clear();
                            AnsiConsole.Write(
                                new Panel("[bold red] El Ticket_id ingresado no es válido; Solo se permiten valores numéricos.[/]")
                                .Border(BoxBorder.Rounded)
                                .BorderColor(Color.Red)
                                .Expand()
                            );
                            break;
                        }

                        var ticket = _ticketService.ObtenerPorId(ticketid);

                        if (ticket == null)
                        {
                            Console.Clear();
                            AnsiConsole.Write(
                                new Panel($"[bold red]El Ticket_id {ticketid} proporcionado no existe en la base de datos.[/]")
                                    .Border(BoxBorder.Rounded)
                                    .BorderColor(Color.Red)
                                    .Expand()
                            );
                            break;
                        }


                        Console.Write("Ingrese el identificador del Usuario_id: ");
                        if (!int.TryParse(Console.ReadLine(),out int usuarioid))
                        {
                            Console.Clear();
                            AnsiConsole.Write(
                                new Panel("[bold red]El Usuario_id ingresado no es válido; Solo se permiten valores numéricos. [/]")
                                    .Border(BoxBorder.Rounded)
                                    .BorderColor(Color.Red)
                                    .Expand()
                            );
                            break;
                        }

                        var usuario = _usuarioService.ObtenerPorId(usuarioid);
                        if (usuario == null)
                        {
                            Console.Clear();
                            AnsiConsole.Write(
                                new Panel($"[bold red]El Usuario_id {usuarioid} proporcionado no existe en la base de datos.[/]")
                                    .Border(BoxBorder.Rounded)
                                    .BorderColor(Color.Red)
                                    .Expand()
                            );
                            break;
                        }


                        var createComentario = _comentarioService.Create(ticketid, usuarioid, texto);
                        Console.Clear();
                        AnsiConsole.Write(
                            new Panel($"[bold yellow]Id:[/] {createComentario.Id}," +
                            $"\n [bold cyan]ticket_id:[/] {createComentario.TicketId}," +
                            $"\n [bold cyan]usuario_id:[/]{createComentario.UsuarioId}," +
                            $"\n [bold cyan]texto[/]{createComentario.Texto}," +
                            $"\n [bold cyan]fecha[/]{createComentario.Fecha}"
                            )
                            .Border(BoxBorder.Rounded)
                            .Expand()
                        );
                        break;
                }

            } while (optionCmt !=5);
        }
    }
}

