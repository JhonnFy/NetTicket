# 1. Imagen base
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS build

# 2. Directorio de trabajo
WORKDIR /app

# 3. Copiar archivos del proyecto
COPY . .

# 4. Restaurar dependencias
RUN dotnet restore

# 5. Compilar y publicar
RUN dotnet publish -c Release -o out

# 6. Imagen de ejecución
FROM mcr.microsoft.com/dotnet/runtime:9.0 AS final

# 7. Directorio de trabajo
WORKDIR /app

# 8. Copiar publicación
COPY --from=build /app/out .

# 9. Ejecutar aplicación
ENTRYPOINT ["dotnet", "NetTicket.dll"]