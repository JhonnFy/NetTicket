using Microsoft.VisualStudio.TestTools.UnitTesting;
using NetTicket.Data.Connection;
using NetTicket.Data.RepositoriesCRUD;
using Microsoft.Extensions.Configuration;
using NetTicket.Models;
using Microsoft.Extensions.DependencyModel;

namespace Testing;

[TestClass]
public class TestEstadoRepositoryId
{
    private EstadoRepository repository = null;

    [TestInitialize]
    public void DatosDeInicio()
    {
        try
        {
            IConfiguration configuration = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json")
            .Build();

            Conexion conexion = new Conexion(configuration);
            repository = new EstadoRepository(conexion);
        }
        catch(Exception ex)
        {
            Console.WriteLine("TestEstadoRepositoryId DatosDeInicio" + ex.Message);
        }
    }


    [TestMethod]
    public void ObtenerPorId()
    {
        try
        {
            var estado = repository.ObtenerPorId(3);
            Assert.IsNotNull(estado);
            TestContext.WriteLine($"Id:{estado.Id} | Nombre:{estado.Nombre}");
        }
        catch(Exception ex)
        {
            Console.WriteLine("TestEstadoRepositoryId ObtenerPorId" + ex.Message);
        }
    }

    [TestMethod]
    public void ObtenerPorIdFalse()
    {
        try
        {
            var estado = repository.ObtenerPorId(8);
            Assert.IsNull(estado, "No se encontro la categoria.");
            TestContext.WriteLine("No se encontro la categoria");
        }
        catch(Exception ex)
        {
            Console.WriteLine("TestEstadoRepositoryId ObtenerPorIdFalse" + ex.Message);
        }
    }

    public TestContext TestContext { get; set; } = null!;
}
