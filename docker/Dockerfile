# Etapa 1: build : en esta etapada es donde se compila el proyecto y se screa el compilado
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

# Copiar archivos de solución y restaurar dependencias
COPY .. . 
WORKDIR /app/src/Template.Api
RUN dotnet restore

# Publicar en modo release
RUN dotnet publish -c Release -o /app/publish



# Etapa 2: runtime : en esta etapa es donde exponemos el proyecto compilado en la etapa anterior, siempre es necesario tener ambas etapas , publicar en aspnet hace que el poryecto se exponga a internet por http
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app
COPY --from=build /app/publish .

# Exponer puerto
EXPOSE 80

# Comando por defecto
ENTRYPOINT ["dotnet", "Template.Api.dll"]
