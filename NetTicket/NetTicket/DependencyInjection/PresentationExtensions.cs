using Microsoft.Extensions.DependencyInjection;
using NetTicket.Presentation.Menu;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetTicket.DependencyInjection
{
    public static class PresentationExtensions
    {
        public static IServiceCollection AddNetTicketPresentation(this IServiceCollection services)
        {
            //CategoriaMenu
            services.AddTransient<CategoriaMenu>();

            //ComentarioMenu
            services.AddTransient<ComentarioMenu>();

            //EstadoMenu
            services.AddTransient<EstadoMenu>();

            //Menu
            services.AddTransient<Menu>();

            //TicketMenu
            services.AddTransient<TicketMenu>();

            //UsuarioMenu
            services.AddTransient<UsuarioMenu>();

            return services;
        }
    }
}
