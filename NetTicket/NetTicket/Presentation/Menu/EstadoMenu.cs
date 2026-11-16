using NetTicket.Services.DbRules;
using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
 
namespace NetTicket.Presentation.Menu
{
    public class EstadoMenu
    {
        private readonly EstadoService _estadoService;

        public EstadoMenu(EstadoService estadoService)
        {
            _estadoService = estadoService;
        }

        public int CountAllEstados() => _estadoService.CountAllEstados();

        private void CabeceraEstado()
        {
            AnsiConsole.Write(
                new Panel(new Markup("[bold yellow]Welcome To Estado Menu[/]").Centered())
                .Border(BoxBorder.Rounded)
                .BorderColor(Color.Cyan)
                .Expand()
            );
        }

        private void EstadoMenuCase1()
        {
            Console.Clear();
            CabeceraEstado();
            Console.Write("Ingrese el nombre del nuevo estado: ");
            string nombre = Console.ReadLine()?.Trim();

            if(string.IsNullOrWhiteSpace(nombre))
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

            var createEstado = _estadoService.Create(nombre);
            Console.Clear();

            AnsiConsole.Write(
                new Panel($"[bold yellow]Id:[/] {createEstado.Id}\n[bold cyan]Nombre:[/] {createEstado.Nombre}")
                .Border(BoxBorder.Rounded)
                .Expand()
            );
        }

        public void EstadoMenuCase2()
        {
            Console.Clear();
            CabeceraEstado();

            AnsiConsole.Write(
                new Panel($"[bold cyan]Estados registrados en la base de datos:[/] {CountAllEstados()}")
                    .Border(BoxBorder.Rounded)
                    .BorderColor(Color.Cyan)
                    .Expand()
            );

            var estados = _estadoService.ObtenerTodos();

            if (estados == null || !estados.Any())
            {
                Console.Clear();
                AnsiConsole.Write(
                    new Panel("[bold yellow]No hay estados registrados.[/]")
                        .Border(BoxBorder.Rounded)
                        .Expand()
                );
                return;
            }

            foreach(var estado in estados)
            {
                Console.WriteLine($"Id:{estado.Id}, Nombre{estado.Nombre}");
            }
            Console.WriteLine();
        }


        public void RunEstadoMenu()

        {
            int optionMenu;

            do
            {
                CabeceraEstado();

                var menu = new SelectionPrompt<int>()
                  .PageSize(6)
                  .HighlightStyle(new Style(Color.Black, Color.Aqua, Decoration.Bold))
                  .AddChoices(1, 2, 3, 4, 5, 6)
                  .UseConverter(option => option switch
                  {
                      1 => "Create",
                      2 => "Read",
                      3 => "ReadId",
                      4 => "Update",
                      5 => "Delete",
                      6 => "Return To Main Menu",
                      _ => "Unknown"
                  });

                optionMenu = AnsiConsole.Prompt(menu);

                switch(optionMenu)
                {
                    case 1:
                            EstadoMenuCase1();
                        break;

                    case 2:
                            EstadoMenuCase2();
                        break;

                }
            } while (optionMenu !=6);
        }
    }
}
