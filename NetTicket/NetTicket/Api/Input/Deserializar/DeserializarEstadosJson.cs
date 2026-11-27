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
    public class DeserializarEstadosJson
    {
        public static async Task<List<EstadosInput>> DeserializarEstados()
        {
            try
            {
                string ruta = "NetTicket/Api/Input/EstadosApi/EstadosApi.json";

                using FileStream stream = File.OpenRead(ruta);

                var inputEstados = await JsonSerializer.DeserializeAsync<List<EstadosInput>>(stream);

                return inputEstados ?? new List<EstadosInput>();

            }catch(Exception ex)
            {
                Console.WriteLine("DeserializarEstadosJson DeserializarEstados " + ex.Message);
                throw;
            }
        }

    }
}
