# See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

# This stage is used when running from VS in fast mode (Default for Debug configuration)
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
ENV PromotionConnectionDb="Data Source=host.docker.internal,1433;Initial Catalog=ECommerceDb;Persist Security Info=True;User ID=SA;Password=Ilovechang_920520;Trust Server Certificate=True"
EXPOSE 8080


# This stage is used to build the service project
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["PromotionsMicroservice/PromotionsMicroservice.csproj", "PromotionsMicroservice/"]
COPY ["PromotionsMicroservice.Infrastructure/PromotionsMicroservice.Infrastructure.csproj", "PromotionsMicroservice.Infrastructure/"]
COPY ["PromotionsMicroservice.ApplicationCore/PromotionsMicroservice.ApplicationCore.csproj", "PromotionsMicroservice.ApplicationCore/"]
RUN dotnet restore "./PromotionsMicroservice/PromotionsMicroservice.csproj"
COPY . .
WORKDIR "/src/PromotionsMicroservice"
RUN dotnet build "./PromotionsMicroservice.csproj" -c $BUILD_CONFIGURATION -o /app/build

# This stage is used to publish the service project to be copied to the final stage
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./PromotionsMicroservice.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# This stage is used in production or when running from VS in regular mode (Default when not using the Debug configuration)
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "PromotionsMicroservice.dll"]