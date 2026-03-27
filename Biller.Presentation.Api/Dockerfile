# Consulte https://aka.ms/customizecontainer para aprender a personalizar su contenedor de depuración y cómo Visual Studio usa este Dockerfile para compilar sus imágenes para una depuración más rápida.

# Esta fase se usa cuando se ejecuta desde VS en modo rápido (valor predeterminado para la configuración de depuración)
FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081


# Esta fase se usa para compilar el proyecto de servicio
FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Biller.Presentation.Api/Biller.Presentation.Api.csproj", "Biller.Presentation.Api/"]
COPY ["Biller.Application.UseCase/Biller.Application.UseCase.csproj", "Biller.Application.UseCase/"]
COPY ["Biller.Application.Infrastructure.Interface/Biller.Application.Infrastructure.Interface.csproj", "Biller.Application.Infrastructure.Interface/"]
COPY ["Biller.Domain/Biller.Domain.csproj", "Biller.Domain/"]
COPY ["Biller.Application.Models/Biller.Application.Models.csproj", "Biller.Application.Models/"]
COPY ["Biller.Infrastructure/Biller.Infrastructure.csproj", "Biller.Infrastructure/"]
RUN dotnet restore "./Biller.Presentation.Api/Biller.Presentation.Api.csproj"
COPY . .
WORKDIR "/src/Biller.Presentation.Api"
RUN dotnet build "./Biller.Presentation.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

# Esta fase se usa para publicar el proyecto de servicio que se copiará en la fase final.
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Biller.Presentation.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# Esta fase se usa en producción o cuando se ejecuta desde VS en modo normal (valor predeterminado cuando no se usa la configuración de depuración)
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Biller.Presentation.Api.dll"]