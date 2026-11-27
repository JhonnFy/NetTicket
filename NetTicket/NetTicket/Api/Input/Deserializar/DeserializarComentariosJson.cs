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
    public class DeserializarComentariosJson
    {

        public static async Task<List<ComentariosInput>> DeserializarComentarios()
        {
            try
            {
                string ruta = "NetTicket/Api/Input/ComentariosApi/ComentariosApi.json";

                using FileStream stream = File.OpenRead(ruta);

                var inputComentarios = await JsonSerializer.DeserializeAsync<List<ComentariosInput>>(stream);

                return inputComentarios ?? new List<ComentariosInput>();
            }
            catch(Exception ex)
            {
                Console.WriteLine("DeserializarComentariosJson DeserializarComentarios " + ex.Message);
                throw;
            }
        }
    }
}
