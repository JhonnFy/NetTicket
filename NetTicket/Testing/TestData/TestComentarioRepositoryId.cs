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
        IConfiguration configuration = new ConfigurationBuilder()
        .AddJsonFile("appsettings.json")
        .Build();

        Conexion conexion = new Conexion(configuration);
        repository = new ComentarioRepository(conexion);
    }


    [TestMethod]
    public void ObtenerPorId()
    {
        var comentario = repository.ObtenerPorId(1);

        Assert.IsNotNull(comentario);
        TestContext.WriteLine($"Id: {comentario.Id} | TicketId:{comentario.TicketId} | UsuarioId:{comentario.UsuarioId} | Texto:{comentario.Texto} | Fecha:{comentario.Fecha}");

    }

    public TestContext TestContext { get; set; } = null!;
}
