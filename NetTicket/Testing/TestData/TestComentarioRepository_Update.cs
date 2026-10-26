using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.Win32;
using NetTicket.Data.Connection;
using NetTicket.Data.RepositoriesCRUD;
using NetTicket.Models;
using System.Security.Cryptography.X509Certificates;

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
            repository.Update(7, "Actualizado Desde MsTest V7");
            var updateCom = repository.ObtenerPorId(7);
            Assert.IsNotNull(updateCom);
            Assert.AreEqual("Update MsTest V9", updateCom.Texto);

            TestContext.WriteLine($"Id{updateCom.Id} | Texto{updateCom.Texto}");

        }
        catch (Exception ex)
        {
            Console.WriteLine("TestComentarioRepository_Update Update" + ex.ToString());
        }
    }
    public TestContext TestContext { get; set; } = null!;
}
