using NetTicket.Services.DbRules;
using Spectre.Console;
using MySqlConnector;
using System.Diagnostics.Metrics;
using Microsoft.Extensions.Configuration;
using Microsoft.VisualBasic;
using NetTicket.Data.RepositoriesCRUD;
using NetTicket.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetTicket.Presentation.Menu
{
    public class CategoriaMenu
    {
        private readonly CategoriaService _categoriaService;

        public CategoriaMenu(CategoriaService categoriaService)
        {
            _categoriaService = categoriaService;
        }

        public int CountAllCategorias() => _categoriaService.CountAllCategorias();

        private void CabeceraCategorias()
        {
            AnsiConsole.Write(
                new Panel(new Markup("[bold yellow]Welcome To Categoria Menu[/]").Centered())
                .Border(BoxBorder.Rounded)
                .BorderColor(Color.Cyan)
                .Expand()
            );
        }

        private void CategoriaMenuCase1()
        {
            Console.Clear();
            CabeceraCategorias();
            Console.Write("Ingrese el nombre de la nueva categoría: ");
            string nombre = Console.ReadLine()?.Trim();

            if (string.IsNullOrWhiteSpace(nombre))
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

            var createCategoria = _categoriaService.Create(nombre);
            Console.Clear();

            AnsiConsole.Write(
                new Panel($"[bold yellow]Id:[/] {createCategoria.Id}\n[bold cyan]Nombre:[/] {createCategoria.Nombre}")
                .Border(BoxBorder.Rounded)
                .Expand()
            );
            return;
        }

        private void CategoriaMenuCase2()
        {
            Console.Clear();
            CabeceraCategorias();

            AnsiConsole.Write(
                new Panel($"[bold cyan]Categorías registradas en la base de datos: [/] {CountAllCategorias()}")
                 .Border(BoxBorder.Rounded)
                .BorderColor(Color.Cyan)
                .Expand()
            );

            var categorias = _categoriaService.ObtenerTodos();

            if (categorias == null || !categorias.Any())
            {
                AnsiConsole.Write(
                    new Panel("[bold yellow]No hay categorías registradas.[/]")
                        .Border(BoxBorder.Rounded)
                        .Expand()
                );
                return;
            }

            foreach (var categoria in categorias)
            {
                Console.WriteLine($"Id:{categoria.Id}, Nombre:{categoria.Nombre}");
            }

            Console.WriteLine();
        }


        private void CategoriaMenuCase3()
        {
            Console.Clear();
            CabeceraCategorias();

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

            var categoria = _categoriaService.ObtenerPorId(id);
            Console.Clear();

            if (categoria == null)
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
                new Panel($"[bold yellow]Id:[/] {categoria.Id}\n[bold cyan]Nombre:[/] {categoria.Nombre}")
                    .Border(BoxBorder.Rounded)
                    .Expand()
            );
        }

        private void CategoriaMenuCase4()
        {
            Console.Clear();
            CabeceraCategorias();

            Console.Write("Ingrese el ID de la categoría que desea modificar: ");
            if (!int.TryParse(Console.ReadLine(), out int id))
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

            var categoria = _categoriaService.ObtenerPorId(id);
            if (categoria == null)
            {
                Console.Clear();
                AnsiConsole.Write(
                    new Panel($"[bold red]No existe una categoría con Id {id}.[/]")
                        .Border(BoxBorder.Rounded)
                        .BorderColor(Color.Red)
                        .Expand()
                );
                return;
            }

            Console.Write("Ingrese el nuevo nombre de la categoría: ");
            string nombre = Console.ReadLine()?.Trim();

            if (string.IsNullOrWhiteSpace(nombre))
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

            _categoriaService.Update(id, nombre);
            Console.Clear();

            AnsiConsole.Write(
                new Panel($"[bold yellow]Id:[/] {id}\n[bold cyan]Nombre:[/] {nombre}")
                .Border(BoxBorder.Rounded)
                .Expand()
            );
        }

        private void CategoriaMenuCase5()
        {
            Console.Clear();
            CabeceraCategorias();

            Console.Write("Ingrese el ID de la categoría que desea eliminar: ");
            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                AnsiConsole.Write(
                    new Panel("[bold red]El ID ingresado no es válido; Solo se permiten valores numéricos.[/]")
                        .Border(BoxBorder.Rounded)
                        .BorderColor(Color.Red)
                        .Expand()
                );
                return;
            }

            var categoria = _categoriaService.ObtenerPorId(id);
            if (categoria == null)
            {
                AnsiConsole.Write(
                    new Panel($"[bold red]No existe una categoría con Id {id}.[/]")
                        .Border(BoxBorder.Rounded)
                        .BorderColor(Color.Red)
                        .Expand()
                );
                return;
            }

            AnsiConsole.Write(
                new Panel($"[bold yellow]Id:[/] {categoria.Id}\n[bold cyan]Nombre:[/] {categoria.Nombre}")
                    .Border(BoxBorder.Rounded)
                    .Expand()
            );

            Console.Write("¿Confirma eliminar esta categoría? (s/n): ");
            string confirm = Console.ReadLine()?.Trim().ToLowerInvariant();

            if (confirm != "s")
            {
                AnsiConsole.Write(
                    new Panel("[bold yellow]Operación cancelada. No se eliminó ningún registro.[/]")
                        .Border(BoxBorder.Rounded)
                        .Expand()
                );
                return;
            }

            try
            {
                bool eliminado = _categoriaService.Delete(id);

                if (eliminado)
                {
                    AnsiConsole.Write(
                        new Panel($"[bold yellow]Categoría con Id {id} eliminada correctamente.[/]")
                            .Border(BoxBorder.Rounded)
                            .Expand()
                    );
                }
                else
                {
                    AnsiConsole.Write(
                        new Panel($"[bold red]No se pudo eliminar la categoría con Id {id}.[/]")
                            .Border(BoxBorder.Rounded)
                            .BorderColor(Color.Red)
                            .Expand()
                    );
                }
            }
            catch (MySqlException ex) when (ex.Number == 1451)
            {
                AnsiConsole.Write(
                    new Panel($"[bold red]No se puede eliminar la categoría con Id {id} porque está siendo utilizada en otros registros (FK).[/]")
                        .Border(BoxBorder.Rounded)
                        .BorderColor(Color.Red)
                        .Expand()
                );
                return;
            }

            catch (Exception ex)
            {
                AnsiConsole.Write(
                    new Panel($"[bold red]Error al eliminar:[/] {ex.Message}")
                        .Border(BoxBorder.Rounded)
                        .BorderColor(Color.Red)
                        .Expand()
                );
            }
        }


        public void RunCategoriaMenu()
        {
            int optionMenu;

            do
            {
                CabeceraCategorias();
                CountAllCategorias();

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
                

                switch (optionMenu)
                {
                    case 1:
                            CategoriaMenuCase1();
                        break;
                    
                    case 2:
                            CategoriaMenuCase2();
                        break;
                    
                    case 3:
                            CategoriaMenuCase3();
                        break;
                            
                    case 4:
                            CategoriaMenuCase4(); 
                        break;
                    case 5:
                            CategoriaMenuCase5();
                        break;
                }
            } while (optionMenu != 6);
        }
    }
}
