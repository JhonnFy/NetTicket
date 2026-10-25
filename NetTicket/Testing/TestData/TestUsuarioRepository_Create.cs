using Microsoft.DiaSymReader;
using NetTicket.Data.Connection;
using NetTicket.Data.RepositoriesCRUD;
using Microsoft.Extensions.Configuration;
using NetTicket.Models;
using Microsoft.Extensions.DependencyModel;


namespace Testing;

[TestClass]
public class TestUsuarioRepository_Create
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
            Console.WriteLine("TestUsuarioRepository_Create DatosDeInicio" + ex.ToString());
        }
    }


    [TestMethod]
    public void Create()
    {
        try
        {
            var insertUsr = repository.Create("MsTest V1", "MsTestV1@gmail.com", "Testing");
            Assert.IsNotNull(insertUsr);
            TestContext.WriteLine($"Id{insertUsr.Id} | Nombre{insertUsr.Nombre} | Email{insertUsr.Email} | Area{insertUsr.Area}");
        }
        catch(Exception ex)
        {
            Console.WriteLine("TestUsuarioRepository_Create Create" + ex.Message);
        }
    }
    public TestContext TestContext { get; set; } = null!;
}
