#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["Transacoes/Transacao.API.csproj", "Transacoes/"]
RUN dotnet restore "Transacoes/Transacao.API.csproj"
COPY . .
WORKDIR "/src/Transacoes"
RUN dotnet build "Transacao.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Transacao.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Transacao.API.dll"]