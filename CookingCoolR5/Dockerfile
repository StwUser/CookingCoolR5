#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["CookingCoolR5/CookingCoolR5.csproj", "CookingCoolR5/"]
RUN dotnet restore "CookingCoolR5/CookingCoolR5.csproj"
COPY . .
WORKDIR "/src/CookingCoolR5"
RUN dotnet build "CookingCoolR5.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CookingCoolR5.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CookingCoolR5.dll"]