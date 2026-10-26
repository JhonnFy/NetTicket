using Microsoft.VisualStudio.TestTools.UnitTesting;
using NetTicket.Data.Connection;
using NetTicket.Data.RepositoriesCRUD;
using Microsoft.Extensions.Configuration;
using NetTicket.Models;
using Microsoft.Extensions.DependencyModel;

namespace Testing;

[TestClass]
public class TestCategoriaRepository_Update
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
        }
        catch(Exception ex)
        {
            Console.WriteLine("TestCategoriaRepository_Update DatosIniciales" + ex.ToString());
        }
    }
    

    [TestMethod]
    public void Update()
    {
        try
        {
            var updateCat = repository.Update(2,"Actualizado Desde MsTest V2");
            var selectId = repository.ObtenerPorId(2);
            Assert.IsNotNull(updateCat);

            TestContext.WriteLine($"Id:{selectId.Id} | Nombre:{selectId.Nombre}");

        }catch(Exception ex)
        {
            Console.WriteLine("TestCategoriaRepository_Update Update" + ex.ToString());
        }
    }
    public TestContext TestContext { get; set; } = null!;
}
