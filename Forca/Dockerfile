FROM mcr.microsoft.com/dotnet/runtime:7.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["Forca/Forca.csproj", "Forca/"]
RUN dotnet restore "Forca/Forca.csproj"
COPY . .
WORKDIR "/src/Forca"
RUN dotnet build "Forca.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Forca.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Forca.dll"]
