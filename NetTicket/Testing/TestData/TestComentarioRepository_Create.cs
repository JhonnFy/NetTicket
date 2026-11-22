using Microsoft.VisualStudio.TestTools.UnitTesting;
using NetTicket.Data.Connection;
using NetTicket.Data.RepositoriesCRUD;
using Microsoft.Extensions.Configuration;
using NetTicket.Models;
using Microsoft.Extensions.DependencyModel;
using System.Threading.Tasks;


namespace Testing;

[TestClass]
public class TestComentarioRepository_Create
{
    private ComentarioRepository repository = null;

    [TestInitialize]
    public void DatosDeInicio()
    {
        try
        {
            IConfiguration configuration = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json")
            .Build();

            Conexion conexion = new Conexion(configuration);
            repository = new ComentarioRepository(conexion);
        }
        catch(Exception ex)
        {
            Console.WriteLine("TestComentarioRepository_Create DatosDeInicio " + ex.Message);
        }
    }

    [TestMethod]
    public async Task Create()
    {
        try
        {
            var newComentario = await repository.Create(1, 1, "MsTest V1");
            Assert.IsNotNull(newComentario);
            TestContext.WriteLine($"Id{newComentario.Id} | TicketId {newComentario.TicketId} | UsuarioId {newComentario.UsuarioId} | Texto {newComentario.Texto} | Fecha {newComentario.Fecha}");
        }
        catch(Exception ex)
        {
            Console.WriteLine("TestComentarioRepository_Create Create " + ex.Message);
        }

    }
    public TestContext TestContext { get; set; } = null!;
}

