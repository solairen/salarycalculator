# Create the build environment image
FROM mcr.microsoft.com/dotnet/core/sdk:3.1 as build-env
WORKDIR /app
 
# Copy the project file and restore the dependencies
COPY src/*.csproj ./
RUN dotnet restore
 
# Copy the remaining source files and build the application
COPY src/. ./
RUN dotnet publish -c Release -r linux-x64 -o out
 
# Build the runtime image
FROM mcr.microsoft.com/dotnet/core/runtime:3.1
WORKDIR /app
COPY --from=build-env /app/out .
ENTRYPOINT ["dotnet", "SalaryCalculator.dll"]