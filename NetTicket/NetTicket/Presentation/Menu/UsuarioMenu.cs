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

        public async Task<int> CountAllUsuarios() => await _usuarioService.CountAllUsuarios();

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

        private async Task  UsuarioMenuCase2()
        {
            Console.Clear();
            CabeceraUsuario();

            AnsiConsole.Write(
                new Panel($"[bold cyan]Usuarios registrados en la base de datos: [/] {await CountAllUsuarios()}")
                    .Border(BoxBorder.Rounded)
                    .BorderColor(Color.Cyan)
                    .Expand()
            );

            var usuarios = await _usuarioService.ObtenerTodos();

            if(usuarios == null || !usuarios.Any())
            {
                Console.Clear();
                AnsiConsole.Write(
                    new Panel("[bold yellow]No hay usuarios registradas.[/]")
                        .Border(BoxBorder.Rounded)
                        .Expand()
                );
                return;
            }

            foreach(var usuario in usuarios)
            {
                Console.WriteLine($"Id:{usuario.Id}, Nombre:{usuario.Nombre}, Email:{usuario.Email}, Area:{usuario.Area}");
            }
            Console.WriteLine();
        }


        public async Task RunUsuarioMenu()
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
                            UsuarioMenuCase1();
                        break;
                            
                    case 2:
                           await UsuarioMenuCase2();
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

