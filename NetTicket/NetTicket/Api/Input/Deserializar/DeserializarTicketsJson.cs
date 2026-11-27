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
    public class DeserializarTicketsJson
    {
        public static async Task<List<TicketsInput>> DeserializarTicket()
        {
            try
            {

                string ruta = "NetTicket/Api/Input/TicketsApi/TicketsApi.json";

                using FileStream stream = File.OpenRead(ruta);

                var inputTickets = await JsonSerializer.DeserializeAsync<List<TicketsInput>>(stream);

                return inputTickets ?? new List<TicketsInput>();
            }
            catch(Exception ex)
            {
                Console.WriteLine("DeserializarTicketsJson DeserializarTicket " + ex.Message);
                throw;
            }
        }
    }
}
