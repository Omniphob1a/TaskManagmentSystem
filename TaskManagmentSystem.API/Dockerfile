FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

COPY TaskManagmentSystem.sln ./
COPY TaskManagmentSystem.API/TaskManagmentSystem.API.csproj TaskManagmentSystem.API/
COPY TaskManagmentSystem.Application/TaskManagmentSystem.Application.csproj TaskManagmentSystem.Application/
COPY TaskManagmentSystem.Domain/TaskManagmentSystem.Domain.csproj TaskManagmentSystem.Domain/
COPY TaskManagmentSystem.Infrastructure/TaskManagmentSystem.Infrastructure.csproj TaskManagmentSystem.Infrastructure/

RUN dotnet restore TaskManagmentSystem.API/TaskManagmentSystem.API.csproj

COPY . .

RUN dotnet publish TaskManagmentSystem.API/TaskManagmentSystem.API.csproj -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS final
WORKDIR /app

COPY --from=build /app/publish .

RUN dotnet tool install --global dotnet-ef --version 8.0.13
ENV PATH="${PATH}:/root/.dotnet/tools"

ENTRYPOINT ["dotnet", "TaskManagmentSystem.API.dll"]
