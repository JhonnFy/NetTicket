using Microsoft.Extensions.DependencyInjection;
using MySqlConnector;
using NetTicket.Data.Connection;
using NetTicket.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Runtime.InteropServices.Marshalling;
using System.Text;
using System.Threading.Tasks;

namespace NetTicket.Data.JsonRepositoriesCRUD
{
    public class JsonCategoriaRepository
    {
        private readonly Conexion _conexion;
        private readonly string _rutaArchivo;

        public JsonCategoriaRepository(Conexion conexion, string rutaArchivo)
        {
            _conexion = conexion;
            _rutaArchivo = rutaArchivo;
        }
    }
}
