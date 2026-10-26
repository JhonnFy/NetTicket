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
            Console.WriteLine("TestEstadoRepository_Update DatosIniciales" + ex.Message);
        }
    }


    [TestMethod]
    public void Update()
    {
        try
        {
            var updateEst = repository.Update(3,"Actualizado Desde MsTest V3");
            var selectId = repository.ObtenerPorId(3);
            Assert.IsNotNull(updateEst);


            Console.WriteLine($"Id {selectId.Id} | {selectId.Nombre}");

        }catch(Exception ex)
        {
            Console.WriteLine("TestEstadoRepository_Update Update" + ex.Message);
        }
    }
    public TestContext TestContext { get; set; } = null!;
}
