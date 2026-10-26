using Microsoft.VisualStudio.TestTools.UnitTesting;
using NetTicket.Data.Connection;
using NetTicket.Data.RepositoriesCRUD;
using Microsoft.Extensions.Configuration;
using NetTicket.Models;
using Microsoft.Extensions.DependencyModel;

namespace Testing;

[TestClass]
public class TestComentarioRepository_Update
{
    private ComentarioRepository repository = null;

    [TestInitialize]
    public void DatosIniciales()
    {
        try
        {
            IConfiguration configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();

            Conexion conexion = new Conexion(configuration);
            repository = new ComentarioRepository(conexion);
        }
        catch (Exception ex)
        {
            Console.WriteLine("TestComentarioRepository_Update DatosIniciales" + ex.ToString());
        }
    }


    [TestMethod]
    public void Update()
    {
        try
        {
            var updateCom = repository.Update(8,"Actualizado Desde MsTest V8");
            Assert.IsNotNull(updateCom);

        }
        catch (Exception ex)
        {
            Console.WriteLine("TestComentarioRepository_Update Update" + ex.ToString());
        }
    }
    public TestContext TestContext { get; set; } = null!;
}
