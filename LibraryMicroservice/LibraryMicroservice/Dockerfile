#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443





FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["LibraryMicroservice/LibraryMicroservice.csproj", "LibraryMicroservice/"]
RUN dotnet restore "LibraryMicroservice/LibraryMicroservice.csproj"
COPY . .
WORKDIR "/src/LibraryMicroservice"
RUN dotnet build "LibraryMicroservice.csproj" -c Release -o /app/build

# run the unit tests
FROM build AS test
# set the directory to be within the unit test project
WORKDIR "/src/LibraryMicroservice"
# run the unit tests
RUN dotnet test --logger:trx


FROM build AS publish
RUN dotnet publish "LibraryMicroservice.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "LibraryMicroservice.dll"]