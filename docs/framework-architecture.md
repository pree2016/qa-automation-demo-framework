# docs/framework-architecture.md

# Framework Architecture

## Overview

This framework follows a scalable hybrid automation architecture supporting:

- UI Automation
- API Automation
- Reporting
- CI/CD Integration
- Reusable utilities
- Configurable execution

The framework is designed using maintainable and production-style automation principles.

---

# Folder Structure

```text
project-root/
│
├── src/
│   └── DemoApp/
│
├── tests/
│   ├── PlaywrightTests/
│   └── ApiTests/
│
├── scripts/
├── docs/
│
├── .github/
│   └── workflows/
│
├── .gitignore
├── README.md
└── QaAutomationDemoFramework.sln
```

---

# POM Architecture and DriverFactory - Enhancement

The current implementation uses Playwright test classes directly. A Page Object Model and DriverFactory layer are planned future enhancements.

---

# Utilities & Helpers

Utility classes provide reusable framework functionality.

Examples:

* Wait helpers
* Screenshot utilities
* JSON utilities

Benefits:

* Reduced duplication
* Improved maintainability
* Centralized reusable logic

---

# Configuration Management - Enhancement

The framework currently includes Allure configuration through allureConfig.json. Broader framework configuration management for URLs, browser settings, and environment values is planned as a future enhancement.

Framework configuration management implies:

appsettings.json
testsettings.json
config.json

with values such as:

```
{
  "urls": {
    "ui": "http://localhost:5078",
    "api": "http://localhost:5078"
  },
  "browser": {
    "headless": true,
    "name": "chromium"
  }
}
```

Configurable areas:

* URLs
* Browser settings
* Environment values
* Execution modes

---

# Reporting Architecture

The framework uses Allure Reporting.

Report contents:

* Execution summary
* Step details
* Failure Screenshots
* Logs
* Categories
* Historical trends

Benefits:

* Improved visibility
* Easier debugging
* Better stakeholder reporting

---

# API Layer

The API automation layer uses RestSharp.

Responsibilities:

* Request handling
* Response validation
* Authentication support
* Header management
* Payload handling

Example structure:

```text
ApiTests/
├── LoginApiTests.cs
```

---

# UI Layer

The UI automation layer uses Playwright with NUnit.

Responsibilities:
- Browser interaction
- UI validations
- End-to-end workflow testing
- Locator handling
- User journey validation

Current implementation:
- Direct Playwright test implementation
- Login workflow validation
- Headless and headed execution support


Example structure:

```text
PlaywrightTests/
├── LoginTests.cs
```
---

# Demo Application Structure

A lightweight demo application is included for framework validation.

Responsibilities:

* UI testing target
* API validation target
* CI execution validation

Benefits:

* Self-contained framework demo
* Faster onboarding
* Easier local execution

---

# CI Architecture

The framework integrates with GitHub Actions.

Pipeline responsibilities:

* Build validation
* Browser installation
* Test execution
* Artifact generation
* Reporting

Execution flow:

```text
Code Push
   ↓
GitHub Actions
   ↓
Build & Restore
   ↓
Execute Tests
   ↓
Generate Allure Report
   ↓
Upload Artifacts
```

---

# Logging & Debugging

The framework supports:

* Console logging
* CI logs
* Allure attachments
* Failure screenshots

These features help accelerate troubleshooting.

---

# Scalability & Extensibility

The framework is designed for future scalability.

---

# Design Principles

The framework follows:

* Reusability
* Maintainability
* Scalability
* Modularity
* Separation of concerns

---

# Conclusion

This framework provides a strong foundation for modern QA automation using:

* Playwright
* RestSharp
* NUnit
* GitHub Actions
* Allure Reporting

The architecture supports both learning and enterprise-level extensibility.

---