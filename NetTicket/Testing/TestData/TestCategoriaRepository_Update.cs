using Microsoft.VisualStudio.TestTools.UnitTesting;
using NetTicket.Data.Connection;
using NetTicket.Data.RepositoriesCRUD;
using Microsoft.Extensions.Configuration;
using NetTicket.Models;
using Microsoft.Extensions.DependencyModel;
using System.Threading.Tasks;

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
            Console.WriteLine("TestCategoriaRepository_Update DatosIniciales" + ex.Message);
        }
    }
    

    [TestMethod]
    public async Task Update()
    {
        try
        {
            var updateCat = await repository.Update(2,"Actualizado Desde MsTest V2");
            var selectId = await repository.ObtenerPorId(2);
            Assert.IsNotNull(updateCat);

            TestContext.WriteLine($"Id:{selectId.Id} | Nombre:{selectId.Nombre}");

        }catch(Exception ex)
        {
            Console.WriteLine("TestCategoriaRepository_Update Update" + ex.Message);
        }
    }
    public TestContext TestContext { get; set; } = null!;
}
