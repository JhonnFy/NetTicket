using Microsoft.VisualStudio.TestTools.UnitTesting;
using NetTicket.Data.Connection;
using NetTicket.Data.RepositoriesCRUD;
using Microsoft.Extensions.Configuration;
using NetTicket.Models;
using Microsoft.Extensions.DependencyModel;

namespace Testing;

[TestClass]
public class TestCategoriaRepository_Create
{
    private CategoriaRepository repository = null;

    [TestInitialize]
    public void DatosDeInicio()
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
            Console.WriteLine("TestCategoriaRepository_Create DatosDeInicio " + ex.Message);
        }
                


    }

    [TestMethod]
    public void Create()
    {
        try
        {
            var insertCat = repository.Create("NetTicket V8");
            Assert.IsNotNull(insertCat);
            TestContext.WriteLine($"Id:{insertCat.Id} | Categoria:{insertCat.Nombre}");
        }
        catch(Exception ex)
        {
            Console.WriteLine("TestCategoriaRepository_Create Create " + ex.Message);
        }




    }
    public TestContext TestContext { get; set; } = null!;
}
