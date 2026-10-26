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

        } catch (Exception ex)
        {
            Console.WriteLine("TestUsuarioRepository_Update DatosIniciales" + ex.Message);
        }
    }


    [TestMethod]
    public void Update()
    {
        try
        {
            var updateUsr = repository.Update(1, "Test MsTest", "MsTest@gmail.com", "Qa V1");
            var selectUsr = repository.ObtenerPorId(1);
            Assert.IsNotNull(updateUsr);

            TestContext.WriteLine($"Id:{selectUsr.Id} | Nombre:{selectUsr.Nombre}| Email:{selectUsr.Email} | Area:{selectUsr.Area}");


        } catch (Exception ex)
        {
            Console.WriteLine("TestUsuarioRepository_Update Update" + ex.Message);
        }
    }
    public TestContext TestContext { get; set; } = null!;
}
