using Microsoft.VisualStudio.TestTools.UnitTesting;
using NetTicket.Data.Connection;
using NetTicket.Data.RepositoriesCRUD;
using Microsoft.Extensions.Configuration;

namespace Testing;

[TestClass]
public class TestTicketRepository
{
    [TestMethod]
    public void TestObtenerTockets()
    {
        IConfiguration configuration = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json")
            .Build();

        Conexion conexion = new Conexion(configuration);
        TicketRepository repository = new TicketRepository(conexion);

        var tickets = repository.ObtenerTodos();

        Assert.IsNotNull(tickets);
        Assert.IsTrue(tickets.Count > 0, "No se encontraron Tickets");

        foreach(var ticket in tickets)
        {
            TestContext.WriteLine($"Id: {ticket.Id} | Titulo: {ticket.Titulo} | Descripcion {ticket.Descripcion} | UsuarioId {ticket.UsuarioId} | CategoriaId {ticket.CategoriaId} | EstadoId {ticket.EstadoId} | FechaCreacion{ticket.FechaCreacion}");
        }
    }

    public TestContext TestContext { get; set; } = null!;
}
