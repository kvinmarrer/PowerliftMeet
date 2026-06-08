FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src

COPY Backend/PowerliftMeet/PowerliftMeet.csproj PowerliftMeet/

RUN dotnet restore PowerliftMeet/PowerliftMeet.csproj

COPY Backend/PowerliftMeet/ PowerliftMeet/

WORKDIR /src/PowerliftMeet
RUN dotnet publish -c Release -o /app/publish /p:UseAppHost=false


FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS final
WORKDIR /app

RUN adduser --disabled-password --gecos '' appuser \
    && chown -R appuser:appuser /app

USER appuser

COPY --from=build /app/publish .

ENV ASPNETCORE_URLS=http://+:80 \
    ASPNETCORE_ENVIRONMENT=Production \
    DOTNET_EnableDiagnostics=0

EXPOSE 80

# 🔥 safer than hardcoding DLL name
ENTRYPOINT ["dotnet", "PowerliftMeet.dll"]