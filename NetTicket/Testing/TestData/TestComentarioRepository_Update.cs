using Microsoft.VisualStudio.TestTools.UnitTesting;
using NetTicket.Data.Connection;
using NetTicket.Data.RepositoriesCRUD;
using Microsoft.Extensions.Configuration;
using NetTicket.Models;
using Microsoft.Extensions.DependencyModel;
using System.Threading.Tasks;

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
            Console.WriteLine("TestComentarioRepository_Update DatosIniciales" + ex.Message);
        }
    }


    [TestMethod]
    public async Task Update()
    {
        try
        {
            var updateCom = await repository.Update(3,"Actualizado Desde MsTest V3");
            var selectId = await repository.ObtenerPorId(3);
            Assert.IsNotNull(updateCom);

            TestContext.WriteLine($"Id:{selectId.Id} | Texto:{selectId.Texto}");

        }
        catch (Exception ex)
        {
            Console.WriteLine("TestComentarioRepository_Update Update" + ex.Message);
        }
    }
    public TestContext TestContext { get; set; } = null!;
}
