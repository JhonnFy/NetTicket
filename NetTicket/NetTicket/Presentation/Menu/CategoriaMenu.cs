using Microsoft.VisualBasic;
using NetTicket.Data.RepositoriesCRUD;
using NetTicket.Services.DbRules;
using System;
using System.Collections.Generic;
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

        public void RunCategoriaMenu()
        {
            int optionMenu;

            do
            {
                Console.WriteLine("---------------------------");
                Console.WriteLine("Welcome To Categorias:");
                Console.WriteLine("---------------------------");
                Console.WriteLine("1 → Create");
                Console.WriteLine("2 → Read");
                Console.WriteLine("3 → ReadId");
                Console.WriteLine("4 → Update");
                Console.WriteLine("5 → Delete");
                Console.WriteLine("6 → Return To Main Menu");

                Console.WriteLine("‼Enter Your Choice‼ →");
                optionMenu = Convert.ToInt32(Console.ReadLine());

                Console.Clear();

                switch (optionMenu)
                {
                    case 1:

                        break;

                    case 2:
                        var countAll = _service.ObtenerTodos();
                        var countCat = _service.CountCategoria();

                        Console.WriteLine($"[Option 2 → Read.Categorias  → {countCat}]");
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
