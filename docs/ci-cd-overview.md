# docs/ci-cd-overview.md

# CI/CD Overview

## Overview

This framework uses GitHub Actions to implement Continuous Integration and Continuous Delivery practices.

The pipeline automatically:
- Restores dependencies
- Builds the solution
- Executes UI and API tests
- Generates Allure Reports
- Publishes execution artifacts

---

# GitHub Actions Workflow

The workflow is configured using:

```text
.github/workflows/dotnet-ci.yml
````

The workflow executes automatically during:

* Push events
* Pull requests
* Manual workflow dispatch

---

# Build Pipeline

The CI pipeline performs the following stages:

| Stage            | Purpose                     |
| ---------------- | --------------------------- |
| Checkout         | Pull repository code        |
| Setup .NET       | Install .NET SDK            |
| Restore          | Restore NuGet packages      |
| Build            | Compile solution            |
| Install Browsers | Install Playwright browsers |
| Execute Tests    | Run UI and API tests        |
| Generate Reports | Create Allure reports       |
| Upload Artifacts | Publish reports/logs        |

---

# Playwright Browser Installation

Playwright browser dependencies are installed during CI execution.

Example:

```bash
playwright install --with-deps chromium
```

This ensures:

* Consistent browser versions
* Stable execution
* Cross-platform compatibility

---

# API & UI Test Execution

## API Test Execution

API tests validate backend services and REST endpoints.

---

## UI Test Execution

UI tests validate end-to-end application workflows.

---

# Allure Report Generation

Allure Reports provide detailed execution visibility.

The CI pipeline:

* Collects Allure results
* Generates HTML reports
* Publishes artifacts

Generated reports include:

* Pass/fail trends
* Execution details
* Screenshots
* Logs
* Attachments

---

# Workflow Triggers

The CI workflow supports:

| Trigger           | Description                  |
| ----------------- | ---------------------------- |
| push              | Triggered on code push       |
| pull_request      | Triggered during PR creation |
| workflow_dispatch | Manual execution             |

---

# Branch Protection & PR Workflow

Branch protection rules help enforce code quality.

Recommended configuration:

* Require pull requests
* Require CI checks
* Require branch updates before merge

Typical workflow:

```text
Feature Branch → Pull Request → CI Validation → Review → Merge
```

---

# Dependabot Integration - Enhancement

Dependabot helps automate dependency updates.

---

# CI/CD Benefits

The implemented pipeline provides:

* Faster feedback cycles
* Automated validation
* Reduced manual effort
* Improved release confidence
* Better defect detection

---

# Failure Handling

The framework captures:

* Failed test screenshots
* Execution logs
* Allure attachments
* Pipeline diagnostics

These artifacts help accelerate root cause analysis.

---

# Security & Best Practices

Recommended practices:

* Use GitHub Secrets
* Enforce branch protection
* Keep workflows modular

---