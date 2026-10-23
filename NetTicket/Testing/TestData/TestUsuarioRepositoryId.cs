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
        IConfiguration configuration = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json")
            .Build();

        Conexion conexion = new Conexion(configuration);
        repository = new UsuarioRepository(conexion);
    }

    [TestMethod]
    public void ObtenerPorId()
    {
        var usuario = repository.ObtenerPorId(1);

        Assert.IsNotNull(usuario);
        TestContext.WriteLine($"Id:{usuario.Id} | Nombre:{usuario.Nombre} | Email:{usuario.Email} | Area:{usuario.Area}");

    }

    [TestMethod]
    public void ObtenerPorIdFalse()
    {
        var usuario = repository.ObtenerPorId(8);
        Assert.IsNull(usuario, "No se encontro el usuario");
        TestContext.WriteLine("No se encontro el usuario");
    }

    public TestContext TestContext { get; set; } = null!;
}
