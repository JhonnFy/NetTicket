using Microsoft.VisualStudio.TestTools.UnitTesting;
using NetTicket.Data.Connection;
using NetTicket.Data.RepositoriesCRUD;
using Microsoft.Extensions.Configuration;
using NetTicket.Models;
using Microsoft.Extensions.DependencyModel;

namespace Testing;

[TestClass]
public class TestEstadoRepository_Update
{
    private EstadoRepository repository = null;

    [TestInitialize]
    public void DatosIniciales()
    {
        try
        {
            IConfiguration configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();

            Conexion conexion = new Conexion(configuration);
            repository = new EstadoRepository(conexion);

        }catch(Exception ex)
        {
            Console.WriteLine("TestEstadoRepository_Update DatosIniciales" + ex.ToString());
        }
    }


    [TestMethod]
    public void Update()
    {
        try
        {
            var updateEst = repository.Update(1,"Actualizado Desde MsTest V1");
            var selectId = repository.ObtenerPorId(1);
            Assert.IsNotNull(updateEst);

        }catch(Exception ex)
        {
            Console.WriteLine("TestEstadoRepository_Update Update" + ex.ToString());
        }
    }
    public TestContext TestContext { get; set; } = null!;
}
