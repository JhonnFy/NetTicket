using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.Win32;
using NetTicket.Data.Connection;
using NetTicket.Data.RepositoriesCRUD;
using NetTicket.Models;

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
        catch(Exception ex)
        {
            Console.WriteLine("TestComentarioRepository_Update DatosIniciales" + ex.ToString());
        }
    }


    [TestMethod]
    public void Update()
    {
        try
        {
            repository.Update(9,"Actualizado Desde MsTest V1");
            var registro = repository.ObtenerPorId(9);
            Assert.IsNotNull(registro);
            Assert.AreEqual("Update MsTest V9", registro.Texto);

            Console.WriteLine($"TestComentario Repository Update : {registro.Texto}");

        }
        catch (Exception ex)
        {
            Console.WriteLine("TestComentarioRepository_Update Update" + ex.ToString());
        }
        
    }
}
