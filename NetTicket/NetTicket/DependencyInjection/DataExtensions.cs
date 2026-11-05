using Microsoft.Extensions.DependencyInjection;
using NetTicket.Data.Connection;
using NetTicket.Data.RepositoriesCRUD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace NetTicket.DependencyInjection
{
    public static class DataExtensions
    {

        public static IServiceCollection AddNetTicketData(this IServiceCollection services)
        {
            //+Conexion
            services.AddTransient<Conexion>();

            //+CategoriaRepository
            services.AddTransient<CategoriaRepository>();

            //+ComentarioRepository
            services.AddTransient<ComentarioRepository>();

            //+EstadoRepository
            services.AddTransient<EstadoRepository>();

            //+TicketRepository
            services.AddTransient<TicketRepository>();

            //+UsuarioRepository
            services.AddTransient<UsuarioRepository>();

            return services;
        }
    }
}
