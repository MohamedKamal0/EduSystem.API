FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build-env
WORKDIR /app

# نسخ ملفات المشروع أولاً
COPY ["SchoolProject.API/SchoolProject.API.csproj", "SchoolProject.API/"]
COPY ["SchoolProject.Core/SchoolProject.Core.csproj", "SchoolProject.Core/"]
COPY ["SchoolProject.Data/SchoolProject.Data.csproj", "SchoolProject.Data/"]
COPY ["SchoolProject.Infrastructure/SchoolProject.Infrastructure.csproj", "SchoolProject.Infrastructure/"]
COPY ["SchoolProject.Service/SchoolProject.Service.csproj", "SchoolProject.Service/"]

# استعادة التبعيات - كفاية restore واحد للمشروع الرئيسي
RUN dotnet restore "SchoolProject.API/SchoolProject.API.csproj"

# نسخ باقي الملفات
COPY . ./

# البناء والنشر
RUN dotnet publish "SchoolProject.API/SchoolProject.API.csproj" -c Release -o out

# صورة وقت التشغيل
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
EXPOSE 8080
COPY --from=build-env /app/out .
ENTRYPOINT ["dotnet", "SchoolProject.API.dll"]