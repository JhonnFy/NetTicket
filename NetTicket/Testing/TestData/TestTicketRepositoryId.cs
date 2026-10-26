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
        try
        {
            IConfiguration configuration = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json")
            .Build();

            Conexion conexion = new Conexion(configuration);
            repository = new TicketRepository(conexion);
        }
        catch(Exception ex)
        {
            Console.WriteLine("TestTicketRepositoryId DatosDeInicio" + ex.Message);
        }
    }

    [TestMethod]
    public void ObtenerPorId()
    {
        try
        {
            var ticket = repository.ObtenerPorId(1);

            Assert.IsNotNull(ticket);
            TestContext.WriteLine($"Id:{ticket.Id} | Titulo:{ticket.Titulo} | Descripcion:{ticket.Descripcion} | UsuarioId:{ticket.UsuarioId} | CategoriaId:{ticket.CategoriaId} | EstadoId:{ticket.EstadoId} | FechaCreacion:{ticket.FechaCreacion}");
        }
        catch(Exception ex)
        {
            Console.WriteLine("TestTicketRepositoryId ObtenerPorId" + ex.Message);
        }
    }

    [TestMethod]
    public void ObtenerPorIdFalse()
    {
        try
        {
            var ticket = repository.ObtenerPorId(9);
            Assert.IsNull(ticket, "No se encontro Ticket");
            TestContext.WriteLine("No se encontro Ticket");
        }
        catch(Exception ex)
        {
            Console.WriteLine("TestTicketRepositoryId ObtenerPorIdFalse" + ex.Message);
        }
    }

    public TestContext TestContext { get; set; } = null!;
}
