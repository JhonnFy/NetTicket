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
        private readonly CategoriaMenu _categoriaMenu;
        private readonly ComentarioMenu _comentarioMenu;
        private readonly EstadoMenu _estadoMenu;
        private readonly TicketMenu ticketMenu;
        private readonly UsuarioMenu usuarioMenu;

        public MenuContext()
        {
            //Agrupador De Dependencias
        }
    }
}
