FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["example/DoitsuTechnology.Shared.ExampleWebApi/DoitsuTechnology.Shared.ExampleWebApi.csproj", "DoitsuTechnology.Shared.ExampleWebApi/"]
RUN dotnet restore "example/DoitsuTechnology.Shared.ExampleWebApi/DoitsuTechnology.Shared.ExampleWebApi.csproj"
COPY . .
WORKDIR "/src/DoitsuTechnology.Shared.ExampleWebApi"
RUN dotnet build "DoitsuTechnology.Shared.ExampleWebApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "DoitsuTechnology.Shared.ExampleWebApi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "DoitsuTechnology.Shared.ExampleWebApi.dll"]
