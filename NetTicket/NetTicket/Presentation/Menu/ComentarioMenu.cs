using NetTicket.Services.DbRules;
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




    }
}
