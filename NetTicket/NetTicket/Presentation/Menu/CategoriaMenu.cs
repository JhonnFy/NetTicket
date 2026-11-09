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

        public void RunCategoriaMenu()
        {
            int optionMenu;
            var countCat = countAllCategorias();

            do
            {
                AnsiConsole.Write(
                new Panel(new Markup("[bold cyan]Welcome To CategoriaMenu[/]").Centered())
                .Border(BoxBorder.Rounded)
                .BorderColor(Color.Cyan)
                .Expand()
                );

                AnsiConsole.Write(
                new Panel(
                    $"[[{countCat}]]-[[Categorias]]-[[Registradas]]\n" 
                )
                    .Border(BoxBorder.Rounded)
                    .BorderColor(Color.Cyan)
                    .Expand()
                );

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
                        Console.Write("Digite el nombre de la categoría: ");
                        string nameCat = Convert.ToString(Console.ReadLine());
                        var createCat = _service.Create(nameCat);
                               
                        if(createCat == null) { Console.WriteLine($"No Se Creo La Categoria"); break; }
                        Console.WriteLine($"Nueva Categoría Registrada;  Id:{createCat.Id}, Nombre{createCat.Nombre}");

                        break;

                    case 2:
                        var countAll = _service.ObtenerTodos();

                        //Console.WriteLine($"[Option 2 → Read.Categorias  → {countCat}]");
                        foreach (var categoria in countAll)
                        {
                            Console.WriteLine($"Id:{categoria.Id}, Nombre:{categoria.Nombre}");
                        }
                        Console.WriteLine("]");
                        Console.WriteLine();
                        break;

                    case 3:
                        Console.Write("Ingrese El Parámetro De Consulta: ");
                        int id = Convert.ToInt32(Console.ReadLine());
                        var countId = _service.ObtenerPorId(id);
                        Console.Clear();

                        Console.WriteLine($"[Option 3 → Read.Categorias.Id → ]");
                        if (countId == null) { Console.WriteLine($"El Id Proporcionado No Existe En La Base De Datos\n]"); break; }
                        Console.WriteLine($"Id:{countId.Id}, Nombre:{countId.Nombre}\n]\n");

                        break;


                    case 4:
                        

                        break;

                    case 5:

                        break;
                }

            } while (optionMenu != 6);
        }
    }
}
