#!/usr/bin/env bash
set -euo pipefail

ROOT_DIR="$(cd "$(dirname "$0")/.." && pwd)"
cd "$ROOT_DIR"

rm -rf allure-results allure-report
mkdir -p allure-results

dotnet build tests/PlaywrightTests/PlaywrightTests.csproj
pwsh tests/PlaywrightTests/bin/Debug/net8.0/playwright.ps1 install-deps chromium
APP_BASE_URL="${APP_BASE_URL:-http://localhost:5078}" dotnet test tests/PlaywrightTests/PlaywrightTests.csproj

if command -v allure >/dev/null 2>&1; then
  allure generate allure-results --clean -o allure-report
  echo "Generated Allure report in: $ROOT_DIR/allure-report"
else
  echo "Tests finished. Install Allure CLI to generate HTML from allure-results."
fi
