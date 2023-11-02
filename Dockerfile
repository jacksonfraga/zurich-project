FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["ProjectZurich.API/ProjectZurich.API.csproj", "ProjectZurich.API/"]
RUN dotnet restore "ProjectZurich.API/ProjectZurich.API.csproj"
COPY . .
WORKDIR "/src/ProjectZurich.API"
RUN dotnet build "ProjectZurich.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ProjectZurich.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENV ASPNETCORE_URLS=http://+:80
ENTRYPOINT ["dotnet", "ProjectZurich.API.dll"]
