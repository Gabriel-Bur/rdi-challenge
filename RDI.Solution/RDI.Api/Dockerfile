#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["RDI.Api/RDI.Api.csproj", "RDI.Api/"]
RUN dotnet restore "RDI.Api/RDI.Api.csproj"
COPY . .
WORKDIR "/src/RDI.Api"
RUN dotnet build "RDI.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "RDI.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "RDI.Api.dll"]