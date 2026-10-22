using Microsoft.VisualStudio.TestTools.UnitTesting;
using NetTicket.Data.Connection;
using NetTicket.Data.RepositoriesCRUD;
using Microsoft.Extensions.Configuration;

namespace Testing;

[TestClass]
public class TestCategoriaRepositoryId
{
    [TestMethod]
    public void ObtenerPorId()
    {
        IConfiguration configuration = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json")
            .Build();

        Conexion conexion = new Conexion(configuration);
        CategoriaRepository repository = new CategoriaRepository(conexion);

        var categoria = repository.ObtenerPorId(5);

        Assert.IsNotNull(categoria);
        TestContext.WriteLine($"Id: {categoria.Id} | Nombre: {categoria.Nombre}");
    }
    public TestContext TestContext { get; set; } = null!;
}
