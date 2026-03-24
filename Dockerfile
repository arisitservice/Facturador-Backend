FROM mcr.microsoft.com/dotnet/sdk:10.0
WORKDIR /src
COPY . .
RUN dotnet restore Biller.Presentation.Api/Biller.Presentation.Api.csproj
EXPOSE 8080
ENTRYPOINT ["dotnet", "watch", "run", "--project", "Biller.Presentation.Api", "--no-launch-profile"]
