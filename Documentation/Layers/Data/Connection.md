**1.** Crear `appsettings.json` con la cadena.
**2.** Editar el `.csproj` para que se copie a la salida.
**3.** Instalar `Microsoft.Extensions.Configuration.Json`.
**4.** Escribir `Conexion.cs` que la lea.
**5.** Agregar `appsettings.json` al `.gitignore`.
**6.** Crear `appsettings.example.json`.

## Configuración de la conexión a MySQL

## Paso 1 — Crear `appsettings.json`

<img width="1366" height="768" alt="image" src="https://github.com/user-attachments/assets/40a84494-e395-4d6d-a57d-ed6e557fd06d" />


Editar appsettings

{
  "ConnectionStrings": {
    "MySqlConnection": "Server=localhost;Database=dB;User=TU_USER;Password=TU_PASSWORD;"
  }
}

---

2 ** Editar el `.csproj` para que se copie a la salida

<img width="1366" height="768" alt="image" src="https://github.com/user-attachments/assets/92a87947-92a2-4a09-a8a1-9bced4ce58f5" />

<img width="1366" height="768" alt="image" src="https://github.com/user-attachments/assets/4c917874-8e87-4aad-a443-f7b925e51667" />

<img width="1366" height="768" alt="image" src="https://github.com/user-attachments/assets/f922511c-a3d0-48f6-b5d3-dfac9b068a15" />


3 Instalar `Microsoft.Extensions.Configuration.Json
<img width="1366" height="768" alt="image" src="https://github.com/user-attachments/assets/2fabf474-19cb-462d-8159-92a0040c1206" />
<img width="1366" height="768" alt="image" src="https://github.com/user-attachments/assets/2d17fef5-ac71-48bb-a927-d88ea2b0b6b8" />
<img width="1366" height="768" alt="image" src="https://github.com/user-attachments/assets/5dfa74c9-f086-480e-9743-f108f1ab2ae2" />

4.** Cear `Conexion.cs` que la lea.
<img width="1366" height="768" alt="image" src="https://github.com/user-attachments/assets/7b74467d-e6dc-4f00-9d7b-755a2b3d9fa1" />

Modificar Program.cs
<img width="1366" height="768" alt="image" src="https://github.com/user-attachments/assets/e7f7b8fc-5808-4572-b574-47914402b73b" />

