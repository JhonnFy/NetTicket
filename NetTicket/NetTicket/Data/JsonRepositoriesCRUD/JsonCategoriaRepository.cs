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

        public JsonCategoriaRepository(Conexion conexion)
        {
            _conexion = conexion;
        }

        public async Task<int> CountAllCategoriasJson()
        {
            try
            {
                await using MySqlConnection cn = _conexion.ObtenerConexion();
                await cn.OpenAsync();

                await using MySqlCommand cmd = new MySqlCommand("CountAllCategorias", cn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                var jsonCountCat = Convert.ToInt32(await cmd.ExecuteScalarAsync());

                return jsonCountCat;

            }catch(Exception ex)
            {
                Console.WriteLine("JsonCategoriaRepository CountAllCategoriasJson");
                throw;
            }
        }
        

    }
}
