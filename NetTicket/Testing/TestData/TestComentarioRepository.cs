using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NetTicket.Data.Connection;
using NetTicket.Data.RepositoriesCRUD;
using NetTicket.Models;

namespace Testing;

[TestClass]
public class TestComentarioRepository
{
    [TestMethod]
    public void TestObtenerComentarios()
    {
        IConfiguration configuration = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json")
            .Build();

        Conexion conexion = new Conexion(configuration);
        ComentarioRepository repository = new ComentarioRepository(conexion);


        var comentarios = repository.ObtenerTodos();

        Assert.IsNotNull(comentarios);
        Assert.IsTrue(comentarios.Count >0, "No se encontraron comentarios.");

        foreach(var comentario in comentarios)
        {
            TestContext.WriteLine($"Id: {comentario.Id}  | UsuarioId: {comentario.UsuarioId} | Texto: {comentario.Texto} | Fecha: {comentario.Fecha}");
        }

    }

    public TestContext TestContext { get; set; }
}
