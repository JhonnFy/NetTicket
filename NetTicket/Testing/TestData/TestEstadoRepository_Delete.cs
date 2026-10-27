using Microsoft.VisualStudio.TestTools.UnitTesting;
using NetTicket.Data.Connection;
using NetTicket.Data.RepositoriesCRUD;
using Microsoft.Extensions.Configuration;
using NetTicket.Models;
using Microsoft.Extensions.DependencyModel;

namespace Testing;

[TestClass]
public class TestEstadoRepository_Delete
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
            Console.WriteLine("TestEstadoRepository_Delete DatosIniciales" + ex.Message);
        }
    }

    [TestMethod]
    public void Delete()
    {
        try
        {
            var delEst = repository.Delete(6);
            var selectEst = repository.ObtenerTodos();
            Assert.IsNotNull(delEst);

            foreach(var i in selectEst)
            {
                Console.WriteLine($"Id:{i.Id} | Nombre:{i.Nombre}");
            }
        }catch(Exception ex)
        {
            Console.WriteLine("TestEstadoRepository_Delete Delete" + ex.Message);
        }
    }
}
