using NetTicket.Presentation.Menu;
using NetTicket.Services.DbRules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetTicket.DependencyInjection
{
    public class MenuContext
    {
        //Agrupador De Dependencias
        public readonly CategoriaMenu CategoriaMenu;
        public readonly ComentarioMenu ComentarioMenu;
        public readonly EstadoMenu EstadoMenu;
        public readonly TicketMenu TicketMenu;
        public readonly UsuarioMenu UsuarioMenu;

        public MenuContext(
                CategoriaMenu categoriaMenu,
                ComentarioMenu comentarioMenu,
                EstadoMenu estadoMenu,
                TicketMenu ticketMenu,
                UsuarioMenu usuarioMenu
             )
        {
             CategoriaMenu = categoriaMenu;
             ComentarioMenu = comentarioMenu;
             EstadoMenu = estadoMenu;
             TicketMenu = ticketMenu;
             UsuarioMenu = usuarioMenu;
        }
    }
}
