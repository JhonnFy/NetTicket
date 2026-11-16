using NetTicket.Services.DbRules;
using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
 
namespace NetTicket.Presentation.Menu
{
    public class EstadoMenu
    {
        private readonly EstadoService _estadoService;

        public EstadoMenu(EstadoService estadoService)
        {
            _estadoService = estadoService;
        }

        public int CountAllEstados() => _estadoService.CountAllEstados();

        public void CabeceraEstado()
        {
            AnsiConsole.Write(
                new Panel(new Markup("[bold yellow]Welcome To Estado Menu[/]").Centered())
                .Border(BoxBorder.Rounded)
                .BorderColor(Color.Cyan)
                .Expand()
            );
        }

        public void RunEstadoMenu()
        {
            int optionMenu;

            do
            {
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
                            
                        break;

                }
            } while (optionMenu !=6);
        }
    }
}
