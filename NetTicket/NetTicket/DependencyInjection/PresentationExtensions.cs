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
            services.AddTransient<CategoriaMenu>();

            services.AddTransient<ComentarioMenu>();

            services.AddTransient<EstadoMenu>();

            services.AddTransient<Menu>();

            services.AddTransient<TicketMenu>();

            services.AddTransient<UsuarioMenu>();

            return services;
        }
    }
}
