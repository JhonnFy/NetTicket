using NetTicket.Services.DbRules;
using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Dynamic;
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

        private void UsuarioMenuCase1()
        {
            Console.Clear();
            CabeceraUsuario();
        }


        public void RunUsuarioMenu()
        {
            int optionMenu;

            do
            {
                CabeceraUsuario();

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

                switch(optionMenu)
                {
                    case 1:
                            
                        break;

                    case 2:
                            
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
