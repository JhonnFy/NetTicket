using NetTicket.Services.DbRules;
using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetTicket.Presentation.Menu
{
    public class UsuarioMenu
    {
        private readonly UsuarioService _usuarioService;

        public UsuarioMenu(UsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        public int CountAllUsuarios() => _usuarioService.CountAllUsuarios();

        private void CabeceraUsuario()
        {
            AnsiConsole.Write(
                new Panel(new Markup("[bold yellow]Welcome To Usuario Menu[/]").Centered())
                .Border(BoxBorder.Rounded)
                .BorderColor(Color.Cyan)
                .Expand()
            );
        }



        public void RunUsuarioMenu()
        {
            int optionMenu;
            Console.Clear();

            do
            {
                Console.WriteLine("---------------------------");
                Console.WriteLine("Welcome To Usuarios:");
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
