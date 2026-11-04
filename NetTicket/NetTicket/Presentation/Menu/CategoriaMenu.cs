using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetTicket.Presentation.Menu
{
    public class CategoriaMenu
    {
        public void IniciarCategoriaMenu()
        {
            int optionMenu;
            Console.Clear();

            do
            {
                Console.WriteLine("Welcome To Categorias:");
                Console.WriteLine("1 → Create");
                Console.WriteLine("2 → Read");
                Console.WriteLine("3 → ReadId");
                Console.WriteLine("4 → Update");
                Console.WriteLine("5 → Delete");
                Console.WriteLine("6 → Return To Main Menu");

                Console.WriteLine("‼Enter Your Choice‼ →");
                optionMenu = Convert.ToInt32(Console.ReadLine());
            } while (optionMenu !=6);
        }
    }
}
