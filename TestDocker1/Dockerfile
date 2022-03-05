#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["TestDocker1/TestDocker1.csproj", "TestDocker1/"]
RUN dotnet restore "TestDocker1/TestDocker1.csproj"
COPY . .
WORKDIR "/src/TestDocker1"
RUN dotnet build "TestDocker1.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "TestDocker1.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TestDocker1.dll"]