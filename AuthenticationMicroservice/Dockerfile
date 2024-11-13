# See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

# This stage is used when running from VS in fast mode (Default for Debug configuration)
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
# ENV AuthenticationConnectionDb="Server=tcp:yb-movieshop.database.windows.net,1433;Initial Catalog=ECommerceDb;Persist Security Info=False;User ID=YuzheBai;Password=Ilovechang26;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=True;Connection Timeout=30"

ENV AuthenticationConnectionDb="Data Source=host.docker.internal,1433;Initial Catalog=ECommerceDb;Persist Security Info=True;User ID=SA;Password=Ilovechang_920520;Trust Server Certificate=True"
EXPOSE 8080


# This stage is used to build the service project
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["AuthenticationMicroservice/AuthenticationMicroservice.csproj", "AuthenticationMicroservice/"]
COPY ["JwtAuthenticationManager/JwtAuthenticationManager.csproj", "JwtAuthenticationManager/"]
RUN dotnet restore "./AuthenticationMicroservice/AuthenticationMicroservice.csproj"
COPY . .
WORKDIR "/src/AuthenticationMicroservice"
RUN dotnet build "./AuthenticationMicroservice.csproj" -c $BUILD_CONFIGURATION -o /app/build

# This stage is used to publish the service project to be copied to the final stage
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./AuthenticationMicroservice.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# This stage is used in production or when running from VS in regular mode (Default when not using the Debug configuration)
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "AuthenticationMicroservice.dll"]