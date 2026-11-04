using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetTicket.Presentation.Menu
{
    public class Menu
    {
        public void Iniciar()
        {
            int option;

            do
            {


                Console.WriteLine("‼Enter Your Choice‼ →");
                option = Convert.ToInt32(Console.ReadLine());
            }while (option !=6);
        }

    }
}
