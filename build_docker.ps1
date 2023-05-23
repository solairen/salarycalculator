if (Test-Path -Path 'C:\Program Files\Docker\Docker\resources\com.docker.proxy.exe') {
    Write-Output "Building image from Dockerfile"
    docker build --rm -f "Docker/Dockerfile" -t salarycalculator:latest .
    Write-Output "Finished"
} else {
    Write-Output "Docker service is not running or installed"
}
