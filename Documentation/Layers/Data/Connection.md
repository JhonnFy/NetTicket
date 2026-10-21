**1.** Crear `appsettings.json` con la cadena.
**2.** Editar el `.csproj` para que se copie a la salida.
**3.** Instalar `Microsoft.Extensions.Configuration.Json`.
**4.** Escribir `Conexion.cs` que la lea.
**5.** Agregar `appsettings.json` al `.gitignore`.
**6.** Crear `appsettings.example.json`.

1


Crear: appsettings.json
<img width="1366" height="768" alt="image" src="https://github.com/user-attachments/assets/40a84494-e395-4d6d-a57d-ed6e557fd06d" />

Editar appsettings

{
  "ConnectionStrings": {
    "MySqlConnection": "Server=localhost;Database=dB;User=TU_USER;Password=TU_PASSWORD;"
  }
}

2.** Editar el `.csproj` para que se copie a la salida

<img width="1366" height="768" alt="image" src="https://github.com/user-attachments/assets/92a87947-92a2-4a09-a8a1-9bced4ce58f5" />




