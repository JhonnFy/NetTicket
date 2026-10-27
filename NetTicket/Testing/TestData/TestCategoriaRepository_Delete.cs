using Microsoft.VisualStudio.TestTools.UnitTesting;
using NetTicket.Data.Connection;
using NetTicket.Data.RepositoriesCRUD;
using Microsoft.Extensions.Configuration;
using NetTicket.Models;
using Microsoft.Extensions.DependencyModel;

namespace Testing;

[TestClass]
public class TestCategoriaRepository_Delete
{
    private CategoriaRepository repository = null;

    [TestInitialize]
    public void DatosIniciales()
    {
        try
        {
            IConfiguration configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();

            Conexion conexion = new Conexion(configuration);
            repository = new CategoriaRepository(conexion);

        }catch(Exception ex)
        {
            Console.WriteLine("TestCategoriaRepository_Delete DatosIniciales" + ex.Message);
        }
    }

    [TestMethod]
    public void Delete()
    {
        try
        {
            var delCat = repository.Delete(35);
            var selectCat = repository.ObtenerTodos();
            Assert.IsNotNull(delCat);

            foreach(var c in selectCat)
            {
                Console.WriteLine($"Id:{c.Id} | Nombre:{c.Nombre}");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("TestCategoriaRepository_Delete Delete" + ex.Message);
        }
    }
    public TestContext TestContext { get; set; } = null!;
}
