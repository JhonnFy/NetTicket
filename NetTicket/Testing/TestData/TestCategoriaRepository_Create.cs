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
        IConfiguration configuration = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json")
            .Build();

        Conexion conexion = new Conexion(configuration);
        repository = new CategoriaRepository(conexion);
    }

    [TestMethod]
    public void Create()
    {
        var insertCat = repository.Create("NetTicket V4");
        Assert.IsNotNull(insertCat);
        TestContext.WriteLine($"Id:{insertCat.Id} | Categoria:{insertCat.Nombre}");



    }
    public TestContext TestContext { get; set; } = null!;
}
