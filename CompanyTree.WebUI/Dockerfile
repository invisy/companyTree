FROM mcr.microsoft.com/dotnet/core/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build
WORKDIR /src
COPY ["CompanyTree.WebUI/CompanyTree.WebUI.csproj", "CompanyTree.WebUI/"]
COPY ["CompanyTree.BLL.Abstraction/CompanyTree.BLL.Abstraction.csproj", "CompanyTree.BLL.Abstraction/"]
COPY ["CompanyTree.Models/CompanyTree.Models.csproj", "CompanyTree.Models/"]
COPY ["CompanyTree.BLL.Implementation/CompanyTree.BLL.Implementation.csproj", "CompanyTree.BLL.Implementation/"]
COPY ["CompanyTree.DAL.Abstraction/CompanyTree.DAL.Abstraction.csproj", "CompanyTree.DAL.Abstraction/"]
COPY ["CompanyTree.Entities/CompanyTree.Entities.csproj", "CompanyTree.Entities/"]
COPY ["CompanyTree.DAL.Implementation/CompanyTree.DAL.Implementation.csproj", "CompanyTree.DAL.Implementation/"]
COPY ["CompanyTree.Utils/CompanyTree.Utils.csproj", "CompanyTree.Utils/"]
RUN dotnet restore "CompanyTree.WebUI/CompanyTree.WebUI.csproj"
COPY . .
WORKDIR "/src/CompanyTree.WebUI"
RUN dotnet build "CompanyTree.WebUI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CompanyTree.WebUI.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CompanyTree.WebUI.dll"]
