using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NetTicket.Data.Connection;
using NetTicket.Data.RepositoriesCRUD;
using NetTicket.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Testing;

[TestClass]
public class TestUsuarioRepositoryId
{
    private UsuarioRepository repository = null;
    
    [TestInitialize]
    public void DatosDeInicio()
    {
        try
        {
            IConfiguration configuration = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json")
            .Build();

            Conexion conexion = new Conexion(configuration);
            repository = new UsuarioRepository(conexion);
        }
        catch(Exception ex)
        {
            Console.WriteLine("TestUsuarioRepositoryId DatosDeInicio" + ex.ToString());
        }
    }

    [TestMethod]
    public void ObtenerPorId()
    {
        try
        {
            var usuario = repository.ObtenerPorId(1);

            Assert.IsNotNull(usuario);
            TestContext.WriteLine($"Id:{usuario.Id} | Nombre:{usuario.Nombre} | Email:{usuario.Email} | Area:{usuario.Area}");
        }
        catch(Exception ex)
        {
            Console.WriteLine("TestUsuarioRepositoryId ObtenerPorId" + ex.ToString());
        }
    }

    [TestMethod]
    public void ObtenerPorIdFalse()
    {
        try
        {
            var usuario = repository.ObtenerPorId(8);
            Assert.IsNull(usuario, "No se encontro el usuario");
            TestContext.WriteLine("No se encontro el usuario");
        }
        catch(Exception ex)
        {
            Console.WriteLine("TestUsuarioRepositoryId ObtenerPorIdFalse" + ex.ToString());
        }

    }

    public TestContext TestContext { get; set; } = null!;
}
