using Microsoft.VisualStudio.TestTools.UnitTesting;
using NetTicket.Data.Connection;
using NetTicket.Data.RepositoriesCRUD;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;

namespace Testing;

[TestClass]
public class TestUsuarioRepository
{
    [TestMethod]
    public async Task TestObtenerUsuarios()
    {
        try
        {
            IConfiguration configuration = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json")
            .Build();

            Conexion conexion = new Conexion(configuration);
            UsuarioRepository repository = new UsuarioRepository(conexion);

            var usuarios = await repository.ObtenerTodos();

            Assert.IsNotNull(usuarios);
            Assert.IsTrue(usuarios.Count > 0, "No se encontraron usuarios");

            foreach (var usuario in usuarios)
            {
                TestContext.WriteLine($"Id: {usuario.Id} | Nombre: {usuario.Nombre} | Email: {usuario.Email} | Area: {usuario.Area}");
            }
        }
        catch(Exception ex)
        {
            Console.WriteLine("TestObtenerUsuarios TestObtenerUsuarios" + ex.Message);
        }        
    }
    public TestContext TestContext { get; set; }
}
