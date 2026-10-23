using Microsoft.VisualStudio.TestTools.UnitTesting;
using NetTicket.Data.Connection;
using NetTicket.Data.RepositoriesCRUD;
using Microsoft.Extensions.Configuration;
using NetTicket.Models;
using Microsoft.Extensions.DependencyModel;

namespace Testing;

[TestClass]
public class TestTicketRepositoryId
{
    private TicketRepository repository = null;

    [TestInitialize]
    public void DatosDeInicio()
    {
        IConfiguration configuration = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json")
            .Build();

        Conexion conexion = new Conexion(configuration);
        repository = new TicketRepository(conexion);

    }

    [TestMethod]
    public void ObtenerPorId()
    {
        var ticket = repository.ObtenerPorId(1);

        Assert.IsNotNull(ticket);
        TestContext.WriteLine($"Id:{ticket.Id} | Titulo:{ticket.Titulo} | Descripcion:{ticket.Descripcion} | UsuarioId:{ticket.UsuarioId} | CategoriaId:{ticket.CategoriaId} | EstadoId:{ticket.EstadoId} | FechaCreacion:{ticket.FechaCreacion}");                 
    }

    [TestMethod]
    public void ObtenerPorIdFalse()
    {
        var ticket = repository.ObtenerPorId(9);
        Assert.IsNull(ticket, "No se encontro Ticket");
        TestContext.WriteLine("No se encontro Ticket");
    }

    public TestContext TestContext { get; set; } = null!;
}
