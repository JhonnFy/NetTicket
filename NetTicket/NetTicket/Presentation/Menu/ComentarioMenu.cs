using NetTicket.Services.DbRules;
using Spectre.Console;
using NetTicket.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetTicket.Presentation.Menu
{
    public class ComentarioMenu
    {
        private readonly ComentarioService _menu;

        public ComentarioMenu(ComentarioService menu)
        {
            _menu = menu;
        }
        
        public int countAllComentarios() => _menu.countAllComentarios();

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
                        string textoCmt = Console.ReadLine()?.Trim();

                        if (string.IsNullOrWhiteSpace(textoCmt))
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
                        if (!int.TryParse(Console.ReadLine(),out int idTick))
                        {
                            Console.Clear();
                            AnsiConsole.Write(
                                new Panel("[bold red] El ID ingresado no es válido; Solo se permiten valores numéricos.[/]")
                                .Border(BoxBorder.Rounded)
                                .BorderColor(Color.Red)
                                .Expand()
                            );
                            break;
                        }


                        Console.Write("Ingrese el identificador del Usuario_id: ");
                        if (!int.TryParse(Console.ReadLine(),out int idUsr))
                        {
                            Console.Clear();
                            AnsiConsole.Write(
                                new Panel("[bold red] El ID ingresado no es válido; Solo se permiten valores numéricos. [/]")
                                    .Border(BoxBorder.Rounded)
                                    .BorderColor(Color.Red)
                                    .Expand()
                            );
                            break;
                        }

                        var createCom = _menu.Create(idTick, idUsr, textoCmt);
                        break;
                }

            } while (optionCmt !=5);
        }
    }
}
