FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 50965
EXPOSE 44307

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY ["src/PolarWeb/PolarWeb.csproj", "src/PolarWeb/"]
RUN dotnet restore "src/PolarWeb/PolarWeb.csproj"
COPY . .
WORKDIR "/src/src/PolarWeb"
RUN dotnet build "PolarWeb.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "PolarWeb.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "PolarWeb.dll"]