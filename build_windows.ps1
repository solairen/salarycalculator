param(
    [ValidateSet("x64", "arm64")]
    [string]$Platform = "x64"
)

$RuntimeMap = @{
    "x64"   = "win-x64"
    "arm64" = "win-arm64"
}
$RuntimeId = $RuntimeMap[$Platform]

Write-Output "Building application for $Platform ($RuntimeId)..."
dotnet publish .\src\SalaryCalculator.csproj -c Release -r $RuntimeId -o .\publish

Write-Output "Creating MSI installer ($Platform)..."
wix build `
    -arch $Platform `
    -loc wix\Common.wxl `
    -ext WixToolset.UI.wixext `
    -d Platform=$Platform `
    -o wix\bin\salarycalculator-$Platform.msi `
    wix\*.wxs

Write-Output "Installer created: wix\bin\salarycalculator-$Platform.msi"
