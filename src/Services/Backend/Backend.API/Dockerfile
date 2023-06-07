FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

RUN set -ex; \
	apt-get update; \
	apt-get install -y --no-install-recommends \
		wkhtmltopdf \
		libgdiplus \
	; \
	rm -rf /var/lib/apt/lists/*

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src

COPY ["src/Services/Backend/Backend.API/Backend.API.csproj", "src/Services/Backend/Backend.API/"]
COPY ["src/Services/Shared/Shared.API/Shared.API.csproj", "src/Services/Shared/Shared.API/"]
COPY ["src/Services/Shared/Shared.Infrastructure/Shared.Infrastructure.csproj", "src/Services/Shared/Shared.Infrastructure/"]
COPY ["src/Services/Shared/Shared.Application/Shared.Application.csproj", "src/Services/Shared/Shared.Application/"]
COPY ["src/Services/Shared/Shared.Domain/Shared.Domain.csproj", "src/Services/Shared/Shared.Domain/"]
COPY ["src/Services/Backend/Backend.Infrastructure/Backend.Infrastructure.csproj", "src/Services/Backend/Backend.Infrastructure/"]
COPY ["src/Services/Backend/Backend.Application/Backend.Application.csproj", "src/Services/Backend/Backend.Application/"]
COPY ["src/Services/Backend/Backend.Domain/Backend.Domain.csproj", "src/Services/Backend/Backend.Domain/"]

RUN dotnet restore "src/Services/Backend/Backend.API/Backend.API.csproj"

COPY . .

WORKDIR "/src/src/Services/Backend/Backend.API"

RUN dotnet build "Backend.API.csproj" -c Release -o /app/build

FROM build AS publish

RUN dotnet publish "Backend.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final

WORKDIR /app
COPY --from=publish /app/publish .

ENTRYPOINT ["dotnet", "Backend.API.dll"]
