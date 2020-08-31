FROM mcr.microsoft.com/dotnet/core/sdk:latest AS build
WORKDIR /app
EXPOSE 80

COPY *.props .
COPY *.sln .

COPY Contracts.DAL.App/*.csproj ./Contracts.DAL.App/
COPY Contracts.DAL.Base/*.csproj ./Contracts.DAL.Base/
COPY DAL.App.EF/*.csproj ./DAL.App.EF/
COPY DAL.Base.EF/*.csproj ./DAL.Base.EF/
COPY Domain/*.csproj ./Domain/
COPY WebApp/*.csproj ./WebApp/

RUN dotnet restore

# copy everything else and build app
COPY Contracts.DAL.App/. ./Contracts.DAL.App/
COPY Contracts.DAL.Base/. ./Contracts.DAL.Base/
COPY DAL.App.EF/. ./DAL.App.EF/
COPY DAL.Base.EF/. ./DAL.Base.EF/
COPY Domain/. ./Domain/
COPY WebApp/. ./WebApp/

WORKDIR /app/WebApp
RUN dotnet publish -c Release -o out

FROM mcr.microsoft.com/dotnet/core/aspnet:latest AS runtime
WORKDIR /app
EXPOSE 80
ENV ConnectionStrings:DefaultConnection="Server=kkilum.ddns.net;Port=5432;Database=uptime;User Id=uptime;Password=uptime;"
COPY --from=build /app/WebApp/out ./
ENTRYPOINT ["dotnet", "WebApp.dll"]