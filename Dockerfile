#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["src/PatientNow.CleanArchTemplate.WebApi/PatientNow.CleanArchTemplate.WebApi.csproj", "src/PatientNow.CleanArchTemplate.WebApi/"]
COPY ["src/PatientNow.CleanArchTemplate.Authentication/PatientNow.CleanArchTemplate.Authentication.csproj", "src/PatientNow.CleanArchTemplate.Authentication/"]
COPY ["src/PatientNow.CleanArchTemplate.Infrastructure/PatientNow.CleanArchTemplate.Infrastructure.csproj", "src/PatientNow.CleanArchTemplate.Infrastructure/"]
COPY ["src/PatientNow.CleanArchTemplate.Core/PatientNow.CleanArchTemplate.Core.csproj", "src/PatientNow.CleanArchTemplate.Core/"]
COPY ["src/PatientNow.CleanArchTemplate.SharedKernel/PatientNow.CleanArchTemplate.SharedKernel.csproj", "src/PatientNow.CleanArchTemplate.SharedKernel/"]
RUN dotnet restore "src/PatientNow.CleanArchTemplate.WebApi/PatientNow.CleanArchTemplate.WebApi.csproj"
COPY . .
WORKDIR "/src/src/PatientNow.CleanArchTemplate.WebApi"
RUN dotnet build "PatientNow.CleanArchTemplate.WebApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "PatientNow.CleanArchTemplate.WebApi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "PatientNow.CleanArchTemplate.WebApi.dll"]