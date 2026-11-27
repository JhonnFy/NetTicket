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
    public class DeserializarUsuariosJson
    {
        public static async Task<List<UsuariosInput>> DeserializarUsuarios()
        {
            try
            {

                string ruta = "NetTicket/Api/Input/UsuariosApi/UsuariosApi.json";

                using FileStream stream = File.OpenRead(ruta);

                var inputUsuarios = await JsonSerializer.DeserializeAsync<List<UsuariosInput>>(stream);

                return inputUsuarios ?? new List<UsuariosInput>();
            }
            catch(Exception ex)
            {
                Console.WriteLine("DeserializarUsuariosJson DeserializarUsuarios" + ex.Message);
                throw;
            }
        }
    }
}
