using NetTicket.Services.DbRules;
using Spectre.Console;
using Microsoft.Extensions.Configuration;
using Microsoft.VisualBasic;
using NetTicket.Data.RepositoriesCRUD;
using NetTicket.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetTicket.Presentation.Menu
{
    public class CategoriaMenu
    {
        private readonly CategoriaService _service;

        public CategoriaMenu(CategoriaService service)
        {
            _service = service;
        }

        public int countAllCategorias()
        {
            var countCat = _service.countAllCategorias();

            return countCat;
        }

        public void cabeceraCategorias()
        {
                AnsiConsole.Write(
                new Panel(new Markup("[bold cyan]Welcome To CategoriaMenu[/]").Centered())
                .Border(BoxBorder.Rounded)
                .BorderColor(Color.Cyan)
                .Expand()
            );
        }



        public void RunCategoriaMenu()
        {
            int optionMenu;
            var countCat = countAllCategorias();

            do
            {
                cabeceraCategorias();

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
                        
                        cabeceraCategorias();

                        Console.Write("Digite el nombre de la categoría: ");
                        string nameCat = Convert.ToString(Console.ReadLine());
                        var createCat = _service.Create(nameCat);

                        Console.Clear();

                        //if(createCat == null) { Console.WriteLine($"No Se Creo La Categoria"); break; }
                        //if(createCat == null) { Console.WriteLine($"No Se Creo La Categoria"); break; }
                        //Console.WriteLine($"Nueva Categoría Registrada;  Id:{createCat.Id}, Nombre{createCat.Nombre}");

                        if (createCat == null) { AnsiConsole.Write(
                                new Panel($"[bold red]No se permiten valores vacíos [/]")
                                    .Border(BoxBorder.Rounded)
                                    .BorderColor(Color.Red)
                                    .Expand()
                            ); break; }




                        break;


                    case 2:

                        cabeceraCategorias();

                        var countAll = _service.ObtenerTodos();

                        foreach (var categoria in countAll)
                        {
                            Console.WriteLine($"Id:{categoria.Id}, Nombre:{categoria.Nombre}");
                        }
                        Console.WriteLine();
                        break;


                    case 3:

                        cabeceraCategorias();

                        Console.Write("Ingrese El Parámetro De Consulta: ");
                        int id = Convert.ToInt32(Console.ReadLine());
                        var countId = _service.ObtenerPorId(id);
                        Console.Clear();

                        if (countId == null)
                        {
                            AnsiConsole.Write(
                                new Panel($"[bold red]El Id {id} proporcionado no existe en la base de datos[/]")
                                    .Border(BoxBorder.Rounded)
                                    .BorderColor(Color.Red)
                                    .Expand()
                            );
                            break;
                        }

                        AnsiConsole.Write(
                            new Panel($"[bold yellow]Id:[/] {countId.Id}\n[bold cyan]Nombre:[/] {countId.Nombre}")
                            .Border(BoxBorder.Rounded)
                            .Expand()
                        );

                     break;


                    case 4:
                        cabeceraCategorias();
                        break;

                    case 5:
                        cabeceraCategorias();
                        break;
                }

            } while (optionMenu != 6);
        }
    }
}
