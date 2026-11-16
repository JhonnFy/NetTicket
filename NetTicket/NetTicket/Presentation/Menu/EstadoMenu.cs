using MySqlConnector;
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

        private void EstadoMenuCase2()
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

        private void EstadoMenuCase3()
        {
            Console.Clear();
            CabeceraEstado();

            Console.Write("Ingrese el parámetro de consulta: ");
            if (!int.TryParse(Console.ReadLine(), out int id))
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

            var estado = _estadoService.ObtenerPorId(id);
            Console.Clear();

            if (estado == null)
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
                new Panel($"[bold yellow]Id:[/] {estado.Id}\n[bold cyan]Nombre:[/] {estado.Nombre}")
                .Border(BoxBorder.Rounded)
                .Expand()
            );
        }

        private void EstadoMenuCase4()
        {
            Console.Clear();
            CabeceraEstado();

            Console.Write("Ingrese el ID de la estado que desea modificar: ");
            if(!int.TryParse(Console.ReadLine(), out int id))
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

            var estado = _estadoService.ObtenerPorId(id);
            if(estado == null)
            {
                Console.Clear();
                AnsiConsole.Write(
                    new Panel($"[bold red]No existe una estado con Id {id}.[/]")
                        .Border(BoxBorder.Rounded)
                        .BorderColor(Color.Red)
                        .Expand()
                );
                return;
            }

            Console.Write("Ingrese el nuevo nombre de la estado: ");
            string nombre = Console.ReadLine()?.Trim();

            if(string.IsNullOrWhiteSpace(nombre))
            {
                Console.Clear();
                AnsiConsole.Write(
                    new Panel($"[bold red]El nombre no puede estar vacío; No se realizó ningún cambio.[/]")
                        .Border(BoxBorder.Rounded)
                        .BorderColor(Color.Red)
                        .Expand()
                );
                return;
            }

            _estadoService.Update(id, nombre);
            Console.Clear();

            AnsiConsole.Write(
                 new Panel($"[bold yellow]Id:[/] {id}\n[bold cyan]Nombre:[/] {nombre}")
                 .Border(BoxBorder.Rounded)
                 .Expand()
            );
        }

        private void EstadoMenuCase5()
        {
            Console.Clear();
            CabeceraEstado();

            Console.Write("Ingrese el ID del estado que desea eliminar: ");
            if (!int.TryParse(Console.ReadLine(), out int id))
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

            var estado = _estadoService.ObtenerPorId(id);
            if(estado == null)
            {
                Console.Clear();
                AnsiConsole.Write(
                    new Panel($"[bold red]No existe un estado con Id {id}.[/]")
                        .Border(BoxBorder.Rounded)
                        .BorderColor(Color.Red)
                        .Expand()
                );
                return;
            }

            Console.Clear();
            AnsiConsole.Write(
                new Panel($"[bold yellow]Id:[/] {estado.Id}\n[bold cyan]Nombre:[/] {estado.Nombre}")    
                    .Border(BoxBorder.Rounded)
                    .Expand()
            );

            Console.Write("¿Confirma eliminar este estado? (s/n): ");
            string confirm = Console.ReadLine()?.Trim().ToLowerInvariant();

            if(confirm != "s")
            {
                Console.Clear();
                AnsiConsole.Write(
                    new Panel("[bold yellow]Operación cancelada. No se eliminó ningún registro.[/]")
                        .Border(BoxBorder.Rounded)
                        .Expand()
                );
                return;
            }

            try
            {
                bool eliminado = _estadoService.Delete(id);
                Console.Clear();

                if(eliminado)
                {
                    AnsiConsole.Write(
                        new Panel($"[bold yellow]Estado con Id {id} eliminado correctamente.[/]")
                            .Border(BoxBorder.Rounded)
                            .Expand()
                    );
                }
                else
                {
                    AnsiConsole.Write(
                        new Panel($"[bold red]No se pudo eliminar el estado con Id {id}.[/]")
                            .Border(BoxBorder.Rounded)
                            .BorderColor(Color.Red)
                            .Expand()
                    );
                }
            }
            catch(MySqlException ex) when (ex.Number == 1451)
            {
                Console.Clear();
                AnsiConsole.Write(
                    new Panel($"[bold red]No se puede eliminar el estado con Id {id} porque está siendo utilizado en otros registros (FK).[/]")
                        .Border(BoxBorder.Rounded)
                        .BorderColor(Color.Red)
                        .Expand()
                );
                return;
            }

            catch (Exception ex)
            {
                Console.Clear();
                AnsiConsole.Write(
                    new Panel($"[bold red]Error al eliminar:[/] {ex.Message}")
                        .Border(BoxBorder.Rounded)
                        .BorderColor(Color.Red)
                        .Expand()
                );
            }
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
                Console.Clear();

                switch(optionMenu)
                {
                    case 1:
                            EstadoMenuCase1();
                        break;

                    case 2:
                            EstadoMenuCase2();
                        break;


                    case 3:
                            EstadoMenuCase3();
                        break;

                    case 4:
                            EstadoMenuCase4();
                        break;

                    case 5:
                            EstadoMenuCase5();
                        break;
                }
            } while (optionMenu !=6);
        }
    }
}
