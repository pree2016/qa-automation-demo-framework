<h1 align="center">QA Automation Demo Framework</h1>

<p align="center">
  End-to-end UI + API automation framework using Playwright, .NET, Allure & CI/CD
</p>

<p align="center">
  <a href="https://github.com/pree2016/qa-automation-demo-framework/actions">
    <img src="https://github.com/pree2016/qa-automation-demo-framework/actions/workflows/dotnet-ci.yml/badge.svg" alt="CI">
  </a>
  <img src="https://img.shields.io/badge/.NET-8-blue?style=for-the-badge" />
  <img src="https://img.shields.io/badge/Playwright-UI%20Tests-green?style=for-the-badge" />
  <img src="https://img.shields.io/badge/Allure-Reports-orange?style=for-the-badge" />
</p>

# 🚀 QA Automation Demo Framework  
*A production-grade QA automation showcase using .NET, Playwright, RestSharp, Allure, and GitHub Actions*


---

## 📌 Overview  

QA Automation Demo Framework is a **public-repository-ready** , end-to-end QA automation framework designed to simulate a real-world product + continuous testing workflow.

It demonstrates how a QA Engineer / QA Lead can:

- ✅ Validate UI and API layers 
- ✅ Integrate automation into CI/CD 
- ✅ Debug failures using rich reporting 

This project balances simplicity (quick to run) with depth (enterprise-ready patterns).

---

## 🎯 Key Features  

- 🎭 UI Automation → Playwright (C#) 
- 🔌 API Automation → RestSharp 
- ⚙️ System Under Test → ASP.NET Core Minimal API 
- 🔄 CI/CD → GitHub Actions 
- 📊 Reporting → Allure (with screenshots) 
- 🧪 Debug-friendly setup → Local + CI 

---

## 🧱 Project Structure  

```
QaAutomationDemoFramework.sln
src/
  DemoApp/
    DemoApp.csproj
    Program.cs
    wwwroot/
      index.html
      app.js
      styles.css
tests/
  ApiTests/
    ApiTests.csproj
    LoginApiTests.cs
    allureConfig.json
  PlaywrightTests/
    PlaywrightTests.csproj
    LoginUiTests.cs
    allureConfig.json
.github/
  workflows/
    dotnet-ci.yml
scripts/
  run-api-tests-with-allure.sh
  run-ui-tests-with-allure.sh
  run-api-tests-with-allure.ps1
  run-ui-tests-with-allure.ps1
README.md
.gitignore
```

---

## 🔐 Demo Credentials  

| Field    | Value                |
|----------|----------------------|
| Email    | qa.user@example.com  |
| Password | Password123!         |

---

## Rename instructions for your repo name

Use this repo name on GitHub:
```text
qa-automation-demo-framework
```

Suggested local flow:

1. Extract the ZIP.
2. Rename the extracted folder to `qa-automation-demo-framework`.
3. Open that folder in VS Code.
4. Run local validation.
5. Create a **public** GitHub repo named `qa-automation-demo-framework`.
6. Push after the local checks pass.

---

## 🪟 Windows Setup

Full local flow for Windows (PowerShell):

### 1. Extract and Rename
```powershell
Expand-Archive -Path .\qa-automation-demo-framework.zip -DestinationPath .
Rename-Item -Path .\qa-automation-demo-framework-main -NewName qa-automation-demo-framework
cd qa-automation-demo-framework
```

### 2. Restore and Build
```powershell
dotnet restore QaAutomationDemoFramework.sln
dotnet build QaAutomationDemoFramework.sln
```

### 3. Run Application
```powershell
dotnet run --project src\DemoApp\DemoApp.csproj --urls http://localhost:5078
```
*(Keep this terminal open)*

### 4. Run Tests
```powershell
.\scripts\run-ui-tests-with-allure.ps1
```

#### 📝 Notes & Assumptions:
- **SDK**: Assumes .NET 8 SDK is installed.
- **Java**: Java (JRE) must be installed for Allure reports.
- **ZIP Name**: Assumes the source is `qa-automation-demo-framework.zip`.
- **Verification**: Manually verify `http://localhost:5078` is accessible before running tests.

---

## 🍎 macOS Setup

Full local flow for macOS (Terminal):

### 1. Extract and Rename
```bash
unzip qa-automation-demo-framework.zip
mv qa-automation-demo-framework-main qa-automation-demo-framework
cd qa-automation-demo-framework
```

### 2. Restore and Build
```bash
dotnet restore QaAutomationDemoFramework.sln
dotnet build QaAutomationDemoFramework.sln
```

### 3. Run Application
```bash
dotnet run --project src/DemoApp/DemoApp.csproj --urls http://localhost:5078
```
*(Keep this terminal open)*

### 4. Run Tests
```bash
chmod +x scripts/run-ui-tests-with-allure.sh
./scripts/run-ui-tests-with-allure.sh
```

#### 📝 Notes & Assumptions:
- **SDK**: Assumes .NET 8 SDK is installed.
- **Java**: Java (JRE) must be installed for Allure reports.
- **Permissions**: Scripts require `chmod +x` before execution.
- **Verification**: Manually verify `http://localhost:5078` is accessible before running tests.

---


## 🏁 Getting Started  

```bash
git clone <your-repo-url>
cd qa-automation-demo-framework

dotnet restore QaAutomationDemoFramework.sln
dotnet build QaAutomationDemoFramework.sln
```

---

## ▶️ Run Application  

```bash
dotnet run --project src/DemoApp/DemoApp.csproj --urls http://localhost:5078
```

Open: http://localhost:5078 

---

## ⚠️ Pre-requisite  

Application must be running before executing tests.

---

## 🧪 API Test Execution  

### Linux / macOS
```bash
export API_BASE_URL=http://localhost:5078
dotnet test tests/ApiTests/ApiTests.csproj
```

### Windows
```powershell
$env:API_BASE_URL="http://localhost:5078"
dotnet test tests/ApiTests/ApiTests.csproj
```

---

## 🌐 UI Test Execution with Browser (headed mode)

### Linux / macOS
```bash
dotnet build tests/PlaywrightTests/PlaywrightTests.csproj

pwsh tests/PlaywrightTests/bin/Debug/net8.0/playwright.ps1 install chromium
pwsh tests/PlaywrightTests/bin/Debug/net8.0/playwright.ps1 install-deps chromium

export APP_BASE_URL=http://localhost:5078

# local visible browser mode
HEADLESS=false dotnet test tests/PlaywrightTests
```

### Windows Powershell
```powershell
dotnet build tests/PlaywrightTests/PlaywrightTests.csproj

pwsh tests/PlaywrightTests/bin/Debug/net8.0/playwright.ps1 install chromium

$env:APP_BASE_URL="http://localhost:5078"

dotnet test tests/PlaywrightTests/PlaywrightTests.csproj
```

### Run only smoke:

dotnet test --filter TestCategory=Smoke

### Run only UI:

dotnet test --filter TestCategory=UI

---

## 🧠 Execution Modes Debug vs CI  

| Environment | Headless | SlowMo |
|------------|----------|--------|
| Local      | false    | 500ms  |
| CI         | true     | 0      |

---

## 📊 Allure Reporting

### 🐧 Ubuntu Setup for Allure  
```bash
sudo apt update
sudo apt install default-jre -y
sudo npm install -g allure-commandline --save-dev
```

### Run Tests with Allure through scripts

#### Windows (PowerShell)
```powershell
.\scripts\run-ui-tests-with-allure.ps1
.\scripts\run-api-tests-with-allure.ps1
```

#### Ubuntu / macOS (PowerShell Core)
```bash
pwsh ./scripts/run-ui-tests-with-allure.ps1
pwsh ./scripts/run-api-tests-with-allure.ps1
```

#### Ubuntu / macOS (Shell)
```bash
chmod +x scripts/run-ui-tests-with-allure.sh
chmod +x scripts/run-api-tests-with-allure.sh
./scripts/run-ui-tests-with-allure.sh
./scripts/run-api-tests-with-allure.sh
```

### 📈 (Optional) Generate Report for only UI tests  
```bash
allure generate tests/PlaywrightTests/bin/Debug/net8.0/allure-results --clean -o allure-report 
cd allure-report 
python3 -m http.server 8080 
```
Open: http://localhost:8080 

### Generate combined Allure Report after running scripts
```bash
rm -rf allure-results allure-report
mkdir -p allure-results
cp -r tests/ApiTests/bin/Debug/net8.0/allure-results/* allure-results/ 2>/dev/null
cp -r tests/PlaywrightTests/bin/Debug/net8.0/allure-results/* allure-results/ 2>/dev/null
allure generate allure-results --clean -o allure-report
cd allure-report
python3 -m http.server 8080
```

Open: http://localhost:8080 

---

## 🧹 Clean Reports  

```bash
rm -rf allure-results allure-report 
rm -rf tests/ApiTests/bin/Debug/net8.0/allure-results 
rm -rf tests/PlaywrightTests/bin/Debug/net8.0/allure-results
```

---

## 🔁 Local Fresh Run after generating allure report once  
```bash
dotnet test tests/ApiTests/ApiTests.csproj 
dotnet test tests/PlaywrightTests/PlaywrightTests.csproj 

mkdir -p allure-results 

cp -R tests/ApiTests/bin/Debug/net8.0/allure-results/. allure-results/ 
cp -R tests/PlaywrightTests/bin/Debug/net8.0/allure-results/. allure-results/ 

allure generate allure-results --clean -o allure-report 
cd allure-report 
python3 -m http.server 8080
``` 
Open: http://localhost:8080

---

## 📸 Screenshots  

- Stored under: `docs/images/screenshots`
- Automatically captured on UI test failure
- Attached to Allure report 

---

## ⚙️ CI/CD Pipeline  

`.github/workflows/dotnet-ci.yml`

### Pipeline Steps:

- Build
- Install Playwright
- Start App
- Run API Tests
- Run UI Tests
- Generate Allure Report
- Upload Artifacts

### Artifacts:

- allure-html-report
- allure-results-and-screenshots

---

## 🔄 TODO / Enhancements 

- Add Dependabot for automated dependency updates 
- Configure PR validation flow for dependency upgrades 
- Validate and document setup on Windows
- Validate and document setup on macOS
- Add OS-specific troubleshooting notes if needed

---

## 🚀 Git Setup  

```bash
git init
git add .
git commit -m "Initial commit: QA Demo Repo Pro"

git branch -M main
git remote add origin https://github.com/<your-username>/qa-automation-demo-framework.git
git push -u origin main
```

---

## 🧠 Why This Project Matters  

- Demonstrates real QA architecture 
- Shows CI/CD integration 
- Includes reporting + debugging strategy 
- Production-ready structure 

---

## 🧹 Notes  

- Allure results are **not committed** 
- Generated locally or via CI artifacts 

---

## 📬 Final Note  

Ideal for showcasing:

- QA Automation 
- Framework Design 
- CI/CD Expertise 