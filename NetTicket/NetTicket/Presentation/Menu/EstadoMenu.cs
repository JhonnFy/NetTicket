using NetTicket.Services.DbRules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
 
namespace NetTicket.Presentation.Menu
{
    public class EstadoMenu
    {
        private readonly EstadoService _service;

        public EstadoMenu(EstadoService service)
        {
            _service = service;
        }

        public int countAllEstados()
        {
            var countEst = _service.CountAllEstados();
            return countEst;
        }


        public void RunEstadoMenu()
        {
            int optionMenu;
            Console.Clear();

            do
            {
                Console.WriteLine("---------------------------");
                Console.WriteLine("Welcome To Estados:");
                Console.WriteLine("---------------------------");
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
