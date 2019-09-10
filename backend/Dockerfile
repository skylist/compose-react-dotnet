FROM mcr.microsoft.com/dotnet/core/sdk:2.2 AS builder
WORKDIR /app
COPY *.csproj .
RUN dotnet restore

COPY . .
RUN dotnet public -c Release -o build

FROM mcr.microsoft.com/dotnet/core/aspnet:2.2
WORKDIR /release
COPY --from=builder /app/build .
ENTRYPOINT [ "dotnet", "backend.dll" ]