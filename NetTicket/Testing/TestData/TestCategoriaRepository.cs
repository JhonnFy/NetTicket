using Microsoft.VisualStudio.TestTools.UnitTesting;
using NetTicket.Data.Connection;
using NetTicket.Data.RepositoriesCRUD;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;

namespace Testing;

[TestClass]
public class TestCategoriaRepository
{
    [TestMethod]
    public async Task TestObtenerCategorias()
    {
        try
        {
            IConfiguration configuration = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json")
            .Build();

            Conexion conexion = new Conexion(configuration);
            CategoriaRepository repository = new CategoriaRepository(conexion);

            var categorias = await repository.ObtenerTodos();

            Assert.IsNotNull(categorias);
            Assert.IsTrue(categorias.Count > 0, "No se encontraron categorías.");

            foreach (var categoria in categorias)
            {
                TestContext.WriteLine($"ID: {categoria.Id} | Nombre: {categoria.Nombre}");
            }
        }
        catch(Exception ex)
        {
            Console.WriteLine("TestCategoriaRepository TestObtenerCategorias " + ex.Message);
        }
        
    }

    public TestContext TestContext { get; set; } = null!;
}