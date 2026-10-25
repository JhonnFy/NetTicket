using Microsoft.VisualStudio.TestTools.UnitTesting;
using NetTicket.Data.Connection;
using NetTicket.Data.RepositoriesCRUD;
using Microsoft.Extensions.Configuration;
using NetTicket.Models;
using Microsoft.Extensions.DependencyModel;


namespace Testing;

[TestClass]
public class TestEstadoRepository_Create
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
    public void Create()
    {
        var insertCom = repository.Create("MsTestV1");
        Assert.IsNotNull(insertCom);
        TestContext.WriteLine($"Id {insertCom.Id} | Nombre {insertCom.Nombre} ");
    }
    public TestContext TestContext { get; set; } = null!;
}
