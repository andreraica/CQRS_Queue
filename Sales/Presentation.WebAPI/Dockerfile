FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY ["Presentation/Presentation.WebAPI/Presentation.WebAPI.csproj", "Presentation/Presentation.WebAPI/"]
COPY ["Domain.Interfaces/Domain.Interfaces.csproj", "Domain.Interfaces/"]
COPY ["Domain.Models/Domain.Models.csproj", "Domain.Models/"]
COPY ["Domain.Services/Domain.Services.csproj", "Domain.Services/"]
COPY ["Infrastructure.Data/Infrastructure.Data.csproj", "Infrastructure.Data/"]
COPY ["Infrastructure.IoC/Infrastructure.IoC.csproj", "Infrastructure.IoC/"]
RUN dotnet restore "Presentation/Presentation.WebAPI/Presentation.WebAPI.csproj"
COPY . .
WORKDIR "/src/Presentation/Presentation.WebAPI"
RUN dotnet build "Presentation.WebAPI.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "Presentation.WebAPI.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Presentation.WebAPI.dll"]