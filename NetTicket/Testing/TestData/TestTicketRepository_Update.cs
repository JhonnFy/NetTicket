using Microsoft.VisualStudio.TestTools.UnitTesting;
using NetTicket.Data.Connection;
using NetTicket.Data.RepositoriesCRUD;
using Microsoft.Extensions.Configuration;
using NetTicket.Models;
using Microsoft.Extensions.DependencyModel;

namespace Testing;

[TestClass]
public class TestTicketRepository_Update
{
    private TicketRepository repository = null;

    [TestInitialize]
    public void DatosIniciales()
    {
        try
        {
            IConfiguration configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();

            Conexion conexion = new Conexion(configuration);
            repository = new TicketRepository(conexion);

        }catch(Exception ex)
        {
            Console.WriteLine("TestTicketRepository_Update DatosIniciales" + ex.Message);
        }
    }


    [TestMethod]
    public void Update()
    {
        try
        {
            var updateTick = repository.Update(3,"Net Ticket","Test V1");
            var selectId = repository.ObtenerPorId(3);
            Assert.IsNotNull(updateTick);

            TestContext.WriteLine($"Id:{selectId.Id} | Titulo:{selectId.Titulo} | Descripcion:{selectId.Descripcion}");

        }catch(Exception ex)
        {
            Console.WriteLine("TestTicketRepository_Update" + ex.Message);
        }
    }
    public TestContext TestContext { get; set; } = null!;
}
