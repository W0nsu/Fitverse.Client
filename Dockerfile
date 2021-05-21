FROM mcr.microsoft.com/dotnet/sdk:5.0-focal AS build
WORKDIR /src
COPY . ./

WORKDIR /src/Fitverse.Client
RUN dotnet restore "Fitverse.Client.csproj"

RUN dotnet build "Fitverse.Client.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Fitverse.Client.csproj" -c Release -o /app/publish

FROM nginx:alpine AS final
WORKDIR /usr/share/nginx/html
COPY --from=publish /app/publish/wwwroot .
COPY Fitverse.Client/nginx.conf /etc/nginx/nginx.conf
