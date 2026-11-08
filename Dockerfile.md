# Dockerfile – Construcción y ejecución de NetTicket

## ¿Qué es un Dockerfile?

Un Dockerfile es un archivo que contiene instrucciones para construir una imagen Docker. En nuestro caso, lo utilizaremos para empaquetar la aplicación NetTicket desarrollada en .NET 9 y preparar el entorno necesario para su ejecución.

## Estructura del Dockerfile

### 1. Imagen base (FROM)

```dockerfile
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
```

Define la imagen base que utilizará Docker durante la primera etapa de construcción.

- `FROM`: indica la imagen base.
- `mcr.microsoft.com/dotnet/sdk`: imagen oficial de .NET SDK.
- `9.0`: versión del SDK.
- `AS build`: asigna el nombre `build` a esta etapa.

**Objetivo:** disponer del entorno y las herramientas necesarias para restaurar dependencias, compilar y publicar la aplicación.

### 2. Directorio de trabajo (WORKDIR)

```dockerfile
WORKDIR /app
```

Establece el directorio de trabajo dentro de la imagen Docker.

Las siguientes instrucciones se ejecutarán tomando `/app` como directorio de referencia.

**Importante:** esta ruta pertenece al entorno interno de Docker, no al sistema de archivos de nuestro computador.

### 3. Copiar archivos del proyecto (COPY)

```dockerfile
COPY . .
```

Copia los archivos del proyecto desde el contexto de construcción hacia el directorio de trabajo de la imagen.

- Primer punto (`.`): representa el origen, es decir, el contexto de construcción.
- Segundo punto (`.`): representa el destino, en este caso `/app`.

**Objetivo:** disponer de los archivos fuente de NetTicket dentro del entorno de construcción.

### 4. Restaurar dependencias (RUN)

```dockerfile
RUN dotnet restore
```

Ejecuta el comando `dotnet restore`, encargado de restaurar las dependencias declaradas en el archivo `.csproj`.

.NET descarga los paquetes NuGet necesarios para que el proyecto pueda compilarse.

**Objetivo:** preparar las dependencias requeridas por la aplicación.

### 5. Compilar y publicar (RUN)

```dockerfile
RUN dotnet publish -c Release -o out
```

Compila y prepara la aplicación para su distribución y ejecución.

- `dotnet publish`: compila y publica el proyecto.
- `-c Release`: establece la configuración de publicación Release.
- `-o out`: establece el directorio de salida de los archivos publicados.

Los archivos resultantes quedan disponibles en `/app/out`.

**Objetivo:** generar los archivos necesarios para ejecutar NetTicket.

### 6. Imagen de ejecución (FROM)

```dockerfile
FROM mcr.microsoft.com/dotnet/runtime:9.0 AS final
```

Inicia una segunda etapa de construcción utilizando la imagen oficial de .NET Runtime 9.0.

- `FROM`: inicia una nueva etapa.
- `dotnet/runtime:9.0`: proporciona el entorno necesario para ejecutar aplicaciones .NET.
- `AS final`: asigna el nombre `final` a esta etapa.

**Objetivo:** separar el entorno de construcción del entorno de ejecución. La imagen final no necesita incluir el SDK completo.

### 7. Directorio de trabajo (WORKDIR)

```dockerfile
WORKDIR /app
```

Establece nuevamente el directorio de trabajo, pero esta vez dentro de la segunda etapa (`final`).

Cada instrucción `FROM` inicia una etapa independiente, por lo que es necesario establecer nuevamente el directorio de trabajo.

### 8. Copiar publicación (COPY)

```dockerfile
COPY --from=build /app/out .
```

Copia los archivos publicados durante la primera etapa hacia la segunda etapa.

- `--from=build`: identifica la etapa de origen.
- `/app/out`: indica la ubicación de los archivos publicados.
- `.`: representa el directorio de destino, `/app`.

**Objetivo:** trasladar los archivos necesarios para ejecutar NetTicket sin copiar todo el entorno de construcción.

### 9. Ejecutar aplicación (ENTRYPOINT)

```dockerfile
ENTRYPOINT ["dotnet", "NetTicket.dll"]
```

Define el proceso principal que se ejecutará cuando se inicie el contenedor.

- `ENTRYPOINT`: establece el comando principal del contenedor.
- `dotnet`: ejecuta el runtime de .NET.
- `NetTicket.dll`: identifica el ensamblado publicado de nuestra aplicación.

**Objetivo:** iniciar NetTicket automáticamente cuando arranque el contenedor.

---

## Concepto de Multi-stage Build

Nuestro Dockerfile utiliza una técnica denominada *Multi-stage build*, que permite dividir la construcción de una imagen en diferentes etapas.

| Etapa | Imagen | Responsabilidad |
|---|---|---|
| BUILD | .NET SDK 9.0 | Restaurar, compilar y publicar. |
| FINAL | .NET Runtime 9.0 | Ejecutar la aplicación. |

Esta separación permite generar una imagen final más ligera, evitando incorporar herramientas de desarrollo que no son necesarias durante la ejecución.

## Flujo general

1. Docker obtiene la imagen base del SDK.
2. Establece el directorio de trabajo.
3. Copia los archivos fuente del proyecto.
4. Restaura las dependencias NuGet.
5. Compila y publica la aplicación.
6. Inicia una segunda etapa con .NET Runtime.
7. Establece el directorio de trabajo de ejecución.
8. Copia los archivos publicados desde BUILD hacia FINAL.
9. Configura el comando que iniciará NetTicket.

**Resultado:** una imagen Docker preparada para ejecutar nuestra aplicación NetTicket en un entorno aislado.
