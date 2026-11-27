using NetTicket.Api.Input.InputDTOs;
using NetTicket.Api.Output.OutputDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;


namespace NetTicket.Api.Input.Deserializar
{
    public class DeserializarCategoriasJson
    {
        public static async Task<List<CategoriaInput>> DeserializarCategorias()
        {
            try
            {

                string ruta = "NetTicket/Api/Input/CategoriasApi/CategoriasApi.json";

                using FileStream stream = File.OpenRead(ruta);

                var inputCategorias = await JsonSerializer.DeserializeAsync<List<CategoriaInput>>(stream);

                return inputCategorias ?? new List<CategoriaInput>();
            }
            catch(Exception ex)
            {
                Console.WriteLine("DeserializarCategoriasJson DeserializarCategorias " + ex.Message);
                throw;
            }
        }
    }
}
