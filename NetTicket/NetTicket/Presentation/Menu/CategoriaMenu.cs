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
                        var categorias = _service.ObtenerTodos();
                        
                            Console.WriteLine("[{Option 2} → {Read.Categorias}  → {}");
                        foreach (var categoria in categorias)
                                    {
                                        Console.WriteLine($"Id:{categoria.Id}, Nombre:{categoria.Nombre}");
                        }
                            Console.WriteLine("]");
                        Console.WriteLine();
                        break;

                    case 3:

                        break;

                    case 4:

                        break;

                    case 5:

                        break;
                }

            } while (optionMenu !=6);
        }
    }
}
