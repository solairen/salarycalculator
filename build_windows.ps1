if (Test-Path -Path "C:\Program Files (x86)\WiX Toolset v3.11\bin") {
    Write-Output "Building application..."
    dotnet publish .\src\SalaryCalculator.csproj -c Release -r win10-x64
    Write-Output "Creating files..."
    & "candle.exe" -arch x64 -dPlatform=x64 wix\*.wxs -o WiX\obj\
    Write-Output "Creating msi installer..."
    & "light.exe" WiX\obj\*.wixobj -loc wix\Common.wxl -ext WixUIExtension -o wix\bin\salarycalculator.msi
    Write-Output "Installer has been created in wix\bin\"
} else {
    Write-Output "WiX Toolset is not installed or not added to the environment path"
}
