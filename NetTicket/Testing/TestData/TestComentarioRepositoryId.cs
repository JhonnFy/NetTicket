using Microsoft.VisualStudio.TestTools.UnitTesting;
using NetTicket.Data.Connection;
using NetTicket.Data.RepositoriesCRUD;
using Microsoft.Extensions.Configuration;
using NetTicket.Models;
using Microsoft.Extensions.DependencyModel;


namespace Testing;

[TestClass]
public class TestComentarioRepositoryId
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
            Console.WriteLine("TestComentarioRepositoryId DatosDeInicio" + ex.ToString());
        }
    }


    [TestMethod]
    public void ObtenerPorId()
    {
        try
        {
            var comentario = repository.ObtenerPorId(1);

            Assert.IsNotNull(comentario);
            TestContext.WriteLine($"Id: {comentario.Id} | TicketId:{comentario.TicketId} | UsuarioId:{comentario.UsuarioId} | Texto:{comentario.Texto} | Fecha:{comentario.Fecha}");
        }
        catch(Exception ex)
        {
            Console.WriteLine("TestComentarioRepositoryId ObtenerPorId" + ex.ToString());
        }
    }

    [TestMethod]
    public void ObtenerPorIdFalse()
    {
        try
        {
            var comentario = repository.ObtenerPorId(1023);
            Assert.IsNull(comentario, "No se encontro el comentario");
            TestContext.WriteLine("No se encontro el comentario");
        }
        catch(Exception ex)
        {
            Console.WriteLine("TestComentarioRepositoryId ObtenerPorIdFalse " + ex.ToString());
        }
    }

    public TestContext TestContext { get; set; } = null!;
}
