$wix = Get-ItemProperty -Path "C:\Program Files (x86)\WiX Toolset v3.11\bin"
$xml = [xml](Get-Content .\salarycalculator\SalaryCalculator.csproj)
$ver = $xml.Project.PropertyGroup.Version

if($null -ne $wix){
    Write-Output "Building application..."
    dotnet publish .\salarycalculator\SalaryCalculator.csproj -c Release -r win10-x64
    Write-Output "Creating files..."
    candle.exe -arch x64 -dPlatform=x64 wix\*.wxs -o WiX\obj\
    Write-Output "Creating msi installer..."
    light.exe WiX\obj\*.wixobj -loc wix\Common.wxl -ext WixUIExtension -o wix\bin\salarycalculator_$ver.msi
    Write-Output "Installer has been created in wix\bin\"
}
else{
    Write-Output "WiX ToolSet is not installed or not added to environment path"
}