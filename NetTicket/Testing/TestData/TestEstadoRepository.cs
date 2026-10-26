using Microsoft.VisualStudio.TestTools.UnitTesting;
using NetTicket.Data.Connection;
using NetTicket.Data.RepositoriesCRUD;
using Microsoft.Extensions.Configuration;


namespace Testing;

[TestClass]
public class TestEstadoRepository
{
    [TestMethod]
    public void TestObtenerEstados()
    {
        try
        {
            IConfiguration configuration = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json")
            .Build();

            Conexion conexion = new Conexion(configuration);
            EstadoRepository repository = new EstadoRepository(conexion);

            var estados = repository.ObtenerTodos();


            Assert.IsNotNull(estados);
            Assert.IsTrue(estados.Count > 0, "No se encontraron estados");

            foreach (var estado in estados)
            {
                TestContext.WriteLine($"Id: {estado.Id} | Nombre: {estado.Nombre} ");
            }
        }
        catch(Exception ex)
        {
            Console.WriteLine("TestEstadoRepository TestObtenerEstados" + ex.Message);
        }
    }

    public TestContext TestContext { get; set; }
}
