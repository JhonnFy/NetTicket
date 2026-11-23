using Microsoft.Extensions.Configuration;
using MySqlConnector;
using NetTicket.Services.DbRules;
using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Linq.Expressions;
using System.Net.Http.Headers;
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

        private async Task UsuarioMenuCase1()
        { 
            Console.Clear();
            CabeceraUsuario();

            Console.Write("Ingrese el nombre, del nuevo usuario: ");
            string nombre = Console.ReadLine()?.Trim();

            if (string.IsNullOrWhiteSpace(nombre))
            {
                Console.Clear();
                AnsiConsole.Write(
                    new Panel($"[bold red]No se permiten valores vacíos.[/]")
                        .Border(BoxBorder.Rounded)
                        .BorderColor(Color.Red)
                        .Expand()
                );
                return;
            }

            Console.Write("Ingrese el email, del nuevo usuario: ");
            string email = Console.ReadLine()?.Trim();

                if (string.IsNullOrWhiteSpace(email))
                {
                    Console.Clear();
                    AnsiConsole.Write(
                        new Panel($"[bold red]No se permiten valores vacíos.[/]")
                            .Border(BoxBorder.Rounded)
                            .BorderColor(Color.Red)
                            .Expand()
                    );
                    return;
                }
                       
            Console.Write("Ingrese el area, del nuevo usuario: ");
            string area = Console.ReadLine()?.Trim();

            if(string.IsNullOrWhiteSpace(area))
            {
                Console.Clear();
                AnsiConsole.Write(
                    new Panel($"[bold red]No se permiten valores vacíos.[/]")
                        .Border(BoxBorder.Rounded)
                        .BorderColor(Color.Red)
                        .Expand()
                );
                return;
            }
                                    
            try
            {
                var createUsuario = await _usuarioService.Create(nombre, email, area);
                Console.Clear();

                AnsiConsole.Write(
                    new Panel($"[bold yellow]Id:[/] {createUsuario.Id},\n" +
                    $"[bold cyan]Nombre:[/] {createUsuario.Nombre},\n" +
                    $"[bold cyan]Email:[/] {createUsuario.Email},\n" +
                    $"[bold cyan]Area:[/] {createUsuario.Area}")
                    .Border(BoxBorder.Rounded)
                    .Expand()
                );
            }
            catch (MySqlException ex) when (ex.Number == 1062)
            {
                Console.Clear();
                AnsiConsole.Write(
                     new Panel($"[bold red]El email ya existe en la base de datos.[/]\n[grey]{ex.Message}[/]")
                    .Border(BoxBorder.Rounded)
                    .BorderColor(Color.Red)
                    .Expand()
                );
            }  
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

        private async Task UsuarioMenuCase3()
        {
            Console.Clear();
            CabeceraUsuario();

            Console.Write("Ingrese el parámetro de consulta: ");
            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                Console.Clear();
                AnsiConsole.Write(
                    new Panel("[bold red]El ID ingresado no es válido; Solo se permiten valores numéricos.[/]")
                        .Border(BoxBorder.Rounded)
                        .BorderColor(Color.Red)
                        .Expand()
                );
                return;
            }

            var usuario = await _usuarioService.ObtenerPorId(id);
            Console.Clear();

            if(usuario == null)
            {
                AnsiConsole.Write(
                    new Panel($"[bold red]El Id {id} proporcionado no existe en la base de datos.[/]")
                        .Border(BoxBorder.Rounded)
                        .BorderColor(Color.Red)
                        .Expand()
                );
                return;
            }

            AnsiConsole.Write(
                new Panel($"[bold yellow]Id:[/] {usuario.Id},\n" +
                $"[bold cyan]Nombre:[/] {usuario.Nombre},\n" +
                $"[bold cyan]Email:[/] {usuario.Email},\n" +
                $"[bold cyan]Area:[/] {usuario.Area}")
                .Border(BoxBorder.Rounded)
                .Expand()
            );
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
             
                switch(optionMenu)
                {
                    case 1:
                           await UsuarioMenuCase1();
                        break;
                            
                    case 2:
                           await UsuarioMenuCase2();
                        break;

                    case 3:
                            await UsuarioMenuCase3();
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



