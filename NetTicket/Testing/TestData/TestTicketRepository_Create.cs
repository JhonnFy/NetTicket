using Microsoft.Extensions.Configuration;
using NetTicket.Models;
using Microsoft.Extensions.DependencyModel;
using NetTicket.Data.RepositoriesCRUD;
using NetTicket.Data.Connection;
using System.Security.Cryptography.X509Certificates;

namespace Testing;

[TestClass]
public class TestTicketRepository_Create
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
            Console.WriteLine("TestTicketRepository_Create DatosDeInicio" + ex.ToString());
        }
    }

    [TestMethod]
    public void Create()
    {
        try
        {
            var insertTick = repository.Create("MsTest V1", "Mysql", 1, 1, 2);
            Assert.IsNotNull(insertTick);
            TestContext.WriteLine($"Id{insertTick.Id} | Titulo{insertTick.Titulo} | Descripcion{insertTick.Descripcion} | UsuarioId{insertTick.UsuarioId} | CategoriaId{insertTick.CategoriaId} | EstadoId{insertTick.EstadoId} | FechaCreacion{insertTick.FechaCreacion}");
        }
        catch(Exception ex)
        {
            Console.WriteLine("TestTicketRepository_Create Create" + ex.ToString());
        }
    }
    public TestContext TestContext { get; set; } = null!;
}
