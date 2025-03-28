FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

COPY ["TaskManagmentSystem.API/TaskManagmentSystem.API.csproj", "TaskManagmentSystem.API/"]
COPY ["TaskManagmentSystem.Application/TaskManagmentSystem.Application.csproj", "TaskManagmentSystem.Application/"]
COPY ["TaskManagmentSystem.Domain/TaskManagmentSystem.Domain.csproj", "TaskManagmentSystem.Domain/"]
COPY ["TaskManagmentSystem.Infrastructure/TaskManagmentSystem.Infrastructure.csproj", "TaskManagmentSystem.Infrastructure/"]

RUN dotnet restore "TaskManagmentSystem.API/TaskManagmentSystem.API.csproj"
COPY . .
WORKDIR "/src/TaskManagmentSystem.API"
RUN dotnet build -c Release -o /app/build

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS publish
WORKDIR "/src/TaskManagmentSystem.API"  
RUN dotnet publish -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TaskManagmentSystem.API.dll"]