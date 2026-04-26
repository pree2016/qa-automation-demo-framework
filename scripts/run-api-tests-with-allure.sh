#!/usr/bin/env bash
set -euo pipefail

ROOT_DIR="$(cd "$(dirname "$0")/.." && pwd)"
cd "$ROOT_DIR"

rm -rf allure-results allure-report
mkdir -p allure-results

API_BASE_URL="${API_BASE_URL:-http://localhost:5078}" dotnet test tests/ApiTests/ApiTests.csproj

if command -v allure >/dev/null 2>&1; then
  allure generate allure-results --clean -o allure-report
  echo "Generated Allure report in: $ROOT_DIR/allure-report"
else
  echo "Tests finished. Install Allure CLI to generate HTML from allure-results."
fi
