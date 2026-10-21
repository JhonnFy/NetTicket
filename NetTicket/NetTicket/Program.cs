using Microsoft.Extensions.Configuration;
using MySqlConnector;
using NetTicket.Data.Connection;

try
{
    IConfiguration configuration = new ConfigurationBuilder()
        .AddJsonFile("appsettings.json")
        .Build();

    Conexion conexion = new Conexion(configuration);

    using MySqlConnection cn = conexion.ObtenerConexion();

    cn.Open();

    Console.WriteLine("Conexión exitosa a MySQL.");
}
catch (MySqlException ex)
{
    Console.WriteLine($"Error de MySQL: {ex.Message}");
}
catch (FileNotFoundException ex)
{
    Console.WriteLine($"No se encontró el archivo Json: {ex.Message}");
}
catch (Exception ex)
{
    Console.WriteLine($"Error inesperado: {ex.Message}");
}