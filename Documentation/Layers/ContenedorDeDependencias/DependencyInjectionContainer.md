# Microsoft.Extensions.DependencyInjection

## ¿Qué es?

Paquete NuGet que permite configurar un **contenedor de dependencias** en una aplicación .NET. El contenedor se encarga de construir y entregar los objetos que una clase necesita, sin que la clase tenga que crearlos manualmente.

---

## Paso 1: Instalar el paquete

### Opción A: Terminal

Dentro de la carpeta del proyecto:

```bash
dotnet add package Microsoft.Extensions.DependencyInjection
```

### Opción B: Visual Studio

1. Clic derecho en el proyecto → **Manage NuGet Packages**.
2. Buscar `Microsoft.Extensions.DependencyInjection`.
3. Seleccionar el paquete.

![Seleccionar proyecto](docs/img/di-paso1-seleccionar-proyecto.png)

### Seleccionar el proyecto correcto

Al instalar desde Visual Studio, asegúrate de seleccionar **el proyecto `NetTicket`** (no el de `Testing`).

![Proyecto seleccionado](docs/img/di-paso1-proyecto-seleccionado.png)

### Instalar todas las dependencias

Visual Studio pedirá confirmación para instalar el paquete y sus dependencias. Aceptar.

![Instalar todas las dependencias](docs/img/di-paso1-instalar-todas.png)

---

## Resultado

El `.csproj` del proyecto incluye la referencia:

```xml
<PackageReference Include="Microsoft.Extensions.DependencyInjection" Version="10.0.14" />
```

Con el paquete instalado, el siguiente paso es configurar el contenedor en `Program.cs`.
