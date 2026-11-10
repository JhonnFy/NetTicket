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
        private readonly ComentarioService _menu;

        public ComentarioMenu(ComentarioService menu)
        {
            _menu = menu;
        }
        
        public int countAllComentarios() => _menu.countAllComentarios();


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
