FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 as build
WORKDIR /src
COPY ["/backend-api-vertical/backend-api-vertical.csproj", "backend-api-vertical/"]
RUN dotnet restore "backend-api-vertical/backend-api-vertical.csproj"
COPY . .
WORKDIR "/src/backend-api-vertical"
RUN dotnet build "backend-api-vertical.csproj" -c Release -o /app/build

FROM build as publish
RUN dotnet publish "backend-api-vertical.csproj" -c Release -o /app/publish

FROM base AS final  
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "backend-api-vertical.dll"]