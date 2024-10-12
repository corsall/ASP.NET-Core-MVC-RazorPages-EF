FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS build

WORKDIR /app
COPY /out .

# Expose the port your app runs on
EXPOSE 80
# Set the application to listen on IPv4 only
ENV ASPNETCORE_URLS=http://0.0.0.0:80

# Start the application
ENTRYPOINT ["dotnet", "lab.dll"]