$docker = Get-Process -Name 'com.docker.proxy' -ErrorAction SilentlyContinue

if ($null -ne $docker){
    Write-Output "Building image from Dockerfile"
    docker build --rm -f "Docker/Dockerfile" -t salarycalculator:latest .
    Write-Output "Finished"
}
else{
    Write-Output "Docker service is not running or installed"
}
