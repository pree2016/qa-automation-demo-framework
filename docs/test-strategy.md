# docs/test-strategy.md

# Test Strategy

## Overview

This framework follows a modern hybrid automation testing approach combining:

- UI Automation using Playwright (.NET)
- API Automation using RestSharp
- CI/CD execution using GitHub Actions
- Reporting using Allure Reports

The framework is designed to support scalable, maintainable, and production-style automation practices.

---

# Testing Pyramid

The framework aligns with the software testing pyramid:

| Layer | Purpose | Tools |
|---|---|---|
| Unit Tests | Validate isolated business logic | Future Scope |
| API Tests | Validate backend services quickly | RestSharp |
| UI Tests | Validate end-to-end workflows | Playwright |

API tests are prioritized for fast feedback while UI tests validate critical business flows.

---

# UI & API Coverage

## UI Automation Coverage

The UI automation suite validates:

- Login workflows
- Form interactions
- Navigation
- Element visibility

### Technology Used

- Playwright (.NET)
- NUnit
- Allure Reporting

---

## API Automation Coverage

The API automation suite validates:

- Status codes
- Response payloads
- Authentication
- Error handling
- Contract validations
- Negative scenarios

### Technology Used

- RestSharp
- NUnit
- JSON Assertions

---

# Smoke, Sanity & Regression Testing

## Smoke Testing

Smoke tests validate critical application functionality after deployment.

Examples:
- Application launch
- Login functionality
- Health endpoint availability

---

## Sanity Testing-TODO

Sanity tests validate specific functionality after minor changes.

---

## Regression Testing

Regression tests validate that existing functionality remains stable after changes.

---

# Playwright + RestSharp Hybrid Usage

The framework combines:

| Area | Tool |
|---|---|
| UI Testing | Playwright |
| API Testing | RestSharp |
| Assertions | NUnit |
| Reporting | Allure |

This hybrid approach provides:
- Faster feedback cycles
- Better coverage
- Reduced dependency on UI-only testing

---

# Parallel Execution

The framework supports assembly-level parallel execution using NUnit configuration attributes.

---

# Retry Strategy

The framework includes retry support using NUnit retry attributes to reduce flaky test failures

---

# Test Tagging Strategy

Tags enable selective execution of tests.

Examples:

| Tag | Purpose |
|---|---|
| smoke | Critical tests |
| regression | Full regression suite |
| api | API tests |
| ui | UI tests |

Example:

```bash
dotnet test --filter "Category=smoke"
```

---

# Headless & Headed Execution

The framework supports both execution modes.

## Headless Mode

Used in:

* CI/CD pipelines
* Faster execution
* Server environments

## Headed Mode

Used for:

* Local debugging
* Demo execution
* Visual validation

Execution mode can be controlled using environment variables.

---

# CI Integration

The framework integrates with GitHub Actions for continuous integration.

CI pipeline responsibilities:

* Build validation
* Dependency restore
* Test execution
* Allure artifact generation
* Reporting

---

# Allure Reporting

Allure Reports provide rich test reporting capabilities.

Features:

* Test execution trends
* Failure screenshots
* Categorized results
* Execution history
* Attachments and logs

Allure reports are generated automatically during CI execution.

---

# Best Practices

* Maintain stable locators
* Keep tests independent
* Avoid hardcoded waits
* Use reusable utilities
* Prefer API validation where applicable
* Maintain proper test tagging

---