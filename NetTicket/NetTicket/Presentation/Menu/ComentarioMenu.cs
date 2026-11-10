using NetTicket.Services.DbRules;
using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetTicket.Presentation.Menu
{
    public class ComentarioMenu
    {
        private readonly ComentarioMenu _menu;

        public ComentarioMenu(ComentarioMenu menu)
        {
            _menu = menu;
        }
                
        public int countAllComentario() => _menu.countAllComentario();

        public void cabeceraComentarios()
        {
            AnsiConsole.Write(
                new Panel(new Markup("[bold cyan]Welcome To ComentariosMenu[/]").Centered())
                .Border(BoxBorder.Rounded)
                .BorderColor(Color.Cyan)
                .Expand()
            );
        }


    }
}
