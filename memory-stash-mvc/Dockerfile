#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 5001

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["memory-stash-mvc/memory-stash-mvc.csproj", "memory-stash-mvc/"]
RUN dotnet restore "memory-stash-mvc/memory-stash-mvc.csproj"
COPY . .
WORKDIR "/src/memory-stash-mvc"
RUN dotnet build "memory-stash-mvc.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "memory-stash-mvc.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "memory-stash-mvc.dll"]