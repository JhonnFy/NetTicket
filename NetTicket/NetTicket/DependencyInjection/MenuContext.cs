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
        private readonly CategoriaMenu _categoriaMenu;
        private readonly ComentarioMenu _comentarioMenu;
        private readonly EstadoMenu _estadoMenu;
        private readonly TicketMenu _ticketMenu;
        private readonly UsuarioMenu _usuarioMenu;

        public MenuContext(
                CategoriaMenu categoriaMenu,
                ComentarioMenu comentarioMenu,
                EstadoMenu estadoMenu,
                TicketMenu ticketMenu,
                UsuarioMenu usuarioMenu
             )
        {
            _categoriaMenu = categoriaMenu;
            _comentarioMenu = comentarioMenu;
            _estadoMenu = estadoMenu;
            _ticketMenu = ticketMenu;
            _usuarioMenu = usuarioMenu;
        }
    }
}
