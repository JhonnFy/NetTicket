using Microsoft.VisualStudio.TestTools.UnitTesting;
using NetTicket.Data.Connection;
using NetTicket.Data.RepositoriesCRUD;
using Microsoft.Extensions.Configuration;

namespace Testing;

[TestClass]
public class TestUsuarioRepository
{
    [TestMethod]
    public void TestObtenerUsuarios()
    {
        IConfiguration configuration = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json")
            .Build();

        Conexion conexion = new Conexion(configuration);
        UsuarioRepository repository = new UsuarioRepository(conexion);

        var usuarios = repository.ObtenerTodos();

        Assert.IsNull(usuarios);
        Assert.IsTrue(usuarios.Count > 0, "No se encontraron usuarios");

        foreach(var usuario in usuarios)
        {
            TestContext.WriteLine($"Id: {usuario.Id} | Nombre: {usuario.Nombre} | Email: {usuario.Email} | Area: {usuario.Area}");
        }
    }
    public TestContext TestContext { get; set; }
}
