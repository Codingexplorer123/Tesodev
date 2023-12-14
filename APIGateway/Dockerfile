#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/sdk:7.0
WORKDIR /app
COPY . .
RUN dotnet restore
RUN dotnet publish APIGateway.csproj -c Release -o out
WORKDIR out
ENV ASPNETCORE_URLS ="http://*:1234"
ENTRYPOINT ["dotnet","APIGateway.dll"]