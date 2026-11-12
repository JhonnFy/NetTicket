using NetTicket.Services.DbRules;
using Spectre.Console;
using System.Diagnostics.Metrics;
using MySqlConnector;
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

        }

        private void CategoriaMenuCase2()
        {
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
            return;
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
                Console.Clear();


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
                }
            } while (optionMenu != 6);
        }
    }
}
