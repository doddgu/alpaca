#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["Service/Alpaca.Service.Open/Alpaca.Service.Open.csproj", "Service/Alpaca.Service.Open/"]
COPY ["Model/Alpaca.Model.Account/Alpaca.Model.Account.csproj", "Model/Alpaca.Model.Account/"]
RUN dotnet restore "Service/Alpaca.Service.Open/Alpaca.Service.Open.csproj"
COPY . .
WORKDIR "/src/Service/Alpaca.Service.Open"
RUN dotnet build "Alpaca.Service.Open.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Alpaca.Service.Open.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Alpaca.Service.Open.dll"]
