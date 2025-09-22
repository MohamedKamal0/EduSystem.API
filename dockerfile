FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build-env
WORKDIR /app

COPY ["SchoolProject.API/SchoolProject.API.csproj", "SchoolProject.API/"]
COPY ["SchoolProject.Core/SchoolProject.Core.csproj", "SchoolProject.Core/"]
COPY ["SchoolProject.Data/SchoolProject.Data.csproj", "SchoolProject.Data/"]
COPY ["SchoolProject.Infrastructure/SchoolProject.Infrastructure.csproj", "SchoolProject.Infrastructure/"]
COPY ["SchoolProject.Service/SchoolProject.Service.csproj", "SchoolProject.Service/"]


RUN dotnet restore "SchoolProject.API/SchoolProject.API.csproj"

COPY . ./

RUN dotnet publish "SchoolProject.API/SchoolProject.API.csproj" -c Release -o out

FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
EXPOSE 8080
COPY --from=build-env /app/out .
ENTRYPOINT ["dotnet", "SchoolProject.API.dll"]