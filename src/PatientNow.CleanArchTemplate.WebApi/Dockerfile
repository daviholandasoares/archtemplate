#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["src/PatientNow.MyPatientNow.WebApi/PatientNow.MyPatientNow.WebApi.csproj", "src/PatientNow.MyPatientNow.WebApi/"]
COPY ["src/PatientNow.MyPatientNow.Authentication/PatientNow.MyPatientNow.Authentication.csproj", "src/PatientNow.MyPatientNow.Authentication/"]
COPY ["src/PatientNow.MyPatientNow.Infrastructure/PatientNow.MyPatientNow.Infrastructure.csproj", "src/PatientNow.MyPatientNow.Infrastructure/"]
COPY ["src/PatientNow.MyPatientNow.Core/PatientNow.MyPatientNow.Core.csproj", "src/PatientNow.MyPatientNow.Core/"]
COPY ["src/PatientNow.MyPatientNow.SharedKernel/PatientNow.MyPatientNow.SharedKernel.csproj", "src/PatientNow.MyPatientNow.SharedKernel/"]
RUN dotnet restore "src/PatientNow.MyPatientNow.WebApi/PatientNow.MyPatientNow.WebApi.csproj"
COPY . .
WORKDIR "/src/src/PatientNow.MyPatientNow.WebApi"
RUN dotnet build "PatientNow.MyPatientNow.WebApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "PatientNow.MyPatientNow.WebApi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "PatientNow.MyPatientNow.WebApi.dll"]
