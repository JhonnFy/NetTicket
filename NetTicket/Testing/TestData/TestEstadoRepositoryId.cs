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
        IConfiguration configuration = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json")
            .Build();

        Conexion conexion = new Conexion(configuration);
        repository = new EstadoRepository(conexion);
    }


    [TestMethod]
    public void ObtenerPorId()
    {
        var estado = repository.ObtenerPorId(2);
        Assert.IsNotNull(estado);
        TestContext.WriteLine($"Id:{estado.Id} | Nombre:{estado.Nombre}");
    }

    public TestContext TestContext { get; set; } = null!;

}
