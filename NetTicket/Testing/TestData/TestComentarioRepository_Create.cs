using Microsoft.VisualStudio.TestTools.UnitTesting;
using NetTicket.Data.Connection;
using NetTicket.Data.RepositoriesCRUD;
using Microsoft.Extensions.Configuration;
using NetTicket.Models;
using Microsoft.Extensions.DependencyModel;


namespace Testing;

[TestClass]
public class TestComentarioRepository_Create
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
    public void Create()
    {
        var newComentario = repository.Create(1,1,"MsTest V1");
        Assert.IsNotNull(newComentario);
        TestContext.WriteLine($"Id{newComentario.Id} | TicketId {newComentario.TicketId} | UsuarioId {newComentario.UsuarioId} | Texto {newComentario.Texto} | Fecha {newComentario.Fecha}");
    }
    public TestContext TestContext { get; set; } = null!;
}
