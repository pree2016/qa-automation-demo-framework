$ErrorActionPreference = "Stop"
$RootDir = Split-Path -Path $PSScriptRoot -Parent
Set-Location $RootDir

Remove-Item -Recurse -Force allure-results, allure-report -ErrorAction SilentlyContinue
New-Item -ItemType Directory -Force -Path allure-results | Out-Null

if (-not $env:API_BASE_URL) { $env:API_BASE_URL = "http://localhost:5078" }
dotnet test tests/ApiTests/ApiTests.csproj

if (Get-Command allure -ErrorAction SilentlyContinue) {
    allure generate allure-results --clean -o allure-report
    Write-Host "Generated Allure report in: $RootDir/allure-report"
} else {
    Write-Host "Tests finished. Install Allure CLI to generate HTML from allure-results."
}
