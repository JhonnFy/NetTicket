using Microsoft.VisualStudio.TestTools.UnitTesting;
using NetTicket.Data.Connection;
using NetTicket.Data.RepositoriesCRUD;
using Microsoft.Extensions.Configuration;
using NetTicket.Models;
using Microsoft.Extensions.DependencyModel;

namespace Testing;

[TestClass]
public class TestCategoriaRepositoryId
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
            Console.WriteLine("TestCategoriaRepositoryId  DatosDeInicio" + ex.ToString());
        }
    }
    

    [TestMethod]
    public void ObtenerPorId()
    {
        try
        {
            var categoria = repository.ObtenerPorId(4);

            Assert.IsNotNull(categoria);
            TestContext.WriteLine($"Id: {categoria.Id} | Nombre: {categoria.Nombre}");
        }
        catch(Exception ex)
        {
            Console.WriteLine("TestCategoriaRepositoryId ObtenerPorId" + ex.ToString());
        }
    }


    [TestMethod]
    public void ObtenerPorIdFalse()
    {

        try
        {
            var categoria = repository.ObtenerPorId(50);
            var valor = ObtenerPorId;
            Assert.IsNull(categoria, "No se encontro la categoria.");
            TestContext.WriteLine("No se encontro la categoria");
        }
        catch(Exception ex)
        {
            Console.WriteLine("TestCategoriaRepositoryId ObtenerPorIdFalse" + ex.ToString());
        }
    }

    public TestContext TestContext { get; set; } = null!;
}


