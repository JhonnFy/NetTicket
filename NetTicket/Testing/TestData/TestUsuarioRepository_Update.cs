using Microsoft.VisualStudio.TestTools.UnitTesting;
using NetTicket.Data.Connection;
using NetTicket.Data.RepositoriesCRUD;
using Microsoft.Extensions.Configuration;
using NetTicket.Models;
using Microsoft.Extensions.DependencyModel;


namespace Testing;

[TestClass]
public class TestUsuarioRepository_Update
{
    private UsuarioRepository repository = null;

    [TestInitialize]
    public void DatosIniciales()
    {
        try
        {
            IConfiguration configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();

            Conexion conexion = new Conexion(configuration);
            repository = new UsuarioRepository(conexion);

        }catch(Exception ex)
        {
            Console.WriteLine("TestUsuarioRepository_Update DatosIniciales" + ex.Message);
        }
    }


    [TestMethod]
    public void TestMethod1()
    {
    }
}
