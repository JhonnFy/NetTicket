using Microsoft.Extensions.DependencyInjection;
using NetTicket.Presentation.Menu;
using NetTicket.Services.BusinessRules;
using NetTicket.Services.DbRules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetTicket.DependencyInjection
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddNetTicketService(this IServiceCollection services)
        {
            services.AddTransient<CategoriaService>();
            services.AddTransient<ComentarioService>();
            services.AddTransient<EstadoService>();
            services.AddTransient<TicketService>();
            services.AddTransient<UsuarioService>();

            return services;
        }
    }
}
