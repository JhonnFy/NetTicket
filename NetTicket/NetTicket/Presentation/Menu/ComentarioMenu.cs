using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetTicket.Presentation.Menu
{
    public class ComentarioMenu
    {
        public ComentarioMenu()
        {

        }

        public void RunComentarioMenu()
        {
            int optionMenu;
            Console.Clear();

            do
            {
                Console.WriteLine("---------------------------");
                Console.WriteLine("Welcome To Comentarios:");
                Console.WriteLine("---------------------------");
                Console.WriteLine("1 → Create");
                Console.WriteLine("2 → Read");
                Console.WriteLine("3 → ReadId");
                Console.WriteLine("4 → Update");
                Console.WriteLine("5 → Return To Main Menu");

                Console.WriteLine("‼Enter Your Choice‼ →");
                optionMenu = Convert.ToInt32(Console.ReadLine());
            } while (optionMenu != 5);
        }
    }
}
