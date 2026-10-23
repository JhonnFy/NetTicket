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
        IConfiguration configuration = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json")
            .Build();

        Conexion conexion = new Conexion(configuration);
        repository = new CategoriaRepository(conexion);
    }


        [TestMethod]
    public void ObtenerPorId()
    {
        var categoria = repository.ObtenerPorId(5);

        Assert.IsNotNull(categoria);
        TestContext.WriteLine($"Id: {categoria.Id} | Nombre: {categoria.Nombre}");
    }


    [TestMethod]
    public void ObtenerPorIdFalse()
    {
        var categoria = repository.ObtenerPorId(8);
        Assert.IsNull(categoria, "No se encontro la categoria");
        TestContext.WriteLine("No se encontro la categoria");
    }

    public TestContext TestContext { get; set; } = null!;
}




