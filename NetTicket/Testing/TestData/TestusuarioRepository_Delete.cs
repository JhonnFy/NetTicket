using Microsoft.VisualStudio.TestTools.UnitTesting;
using NetTicket.Data.Connection;
using NetTicket.Data.RepositoriesCRUD;
using Microsoft.Extensions.Configuration;
using NetTicket.Models;
using Microsoft.Extensions.DependencyModel;

namespace Testing;

[TestClass]
public class TestusuarioRepository_Delete
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
            Console.WriteLine("TestusuarioRepository_Delete DatosIniciales" + ex.Message);
        }
    }


    [TestMethod]
    public void Delete()
    {
        try
        {
            var delUsr = repository.Delete(4);
            var selectUsr = repository.ObtenerTodos();
            Assert.IsNotNull(delUsr);

            foreach(var i in selectUsr)
            {
                Console.WriteLine($"Id:{i.Id} | Nombre:{i.Nombre} | Email:{i.Email} | Area:{i.Area}");
            }
        }catch(Exception ex)
        {
            Console.WriteLine("TestusuarioRepository_Delete Delete" + ex.Message);
        }
    }
    public TestContext TestContext { get; set; } = null!;
}
