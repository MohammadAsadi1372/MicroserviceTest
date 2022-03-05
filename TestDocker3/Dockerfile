#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["TestDocker3/TestDocker3.csproj", "TestDocker3/"]
RUN dotnet restore "TestDocker3/TestDocker3.csproj"
COPY . .
WORKDIR "/src/TestDocker3"
RUN dotnet build "TestDocker3.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "TestDocker3.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TestDocker3.dll"]