# LeaveFlow - Workflow-Driven Leave Management System

![Static Badge](https://img.shields.io/badge/semver-0.0.1--skeleton-green)

**Status**: ONGOING
**Live Demo**: TBD
**Deep Dive**: TBD

---

## The Purpose

Most leave systems track status. This system treats **process as the source of truth**—enabling audit trails by design, dynamic approval chains without code changes, and guaranteed consistency under concurrent modification.

**Workflow-driven** means the approval process exists as **data, not code**. A JSON-defined state machine controls execution: who must approve, in what order, under what conditions, and what happens on timeout. HR modifies rules; engineers don't redeploy.

**Why this matters**: Hard-coded `if/else` approval logic breaks when policies change. Mutable status fields erase history. Race conditions double-approve when two managers click simultaneously. This system solves those production failures through event sourcing, distributed locking, and operational observability.

Built to demonstrate that a solo developer can ship systems with enterprise-grade reliability through architectural discipline, not infrastructure complexity.

---

## What It Does

| Capability                   | How It Works                                          | Why It Matters                                      |
| ---------------------------- | ----------------------------------------------------- | --------------------------------------------------- |
| Configurable Approval Chains | JSON-defined workflows with expression-based routing  | HR modifies processes without engineering tickets   |
| Concurrent Safety            | PostgreSQL advisory locks + optimistic concurrency    | Zero double-approvals under race conditions         |
| Audit by Design              | Event-sourced persistence (append-only)               | Compliance-ready history, no retroactive alteration |
| Failure Resilience           | Outbox pattern, idempotent operations                 | Survives crashes without lost approvals             |
| Operational Visibility       | Structured logging, Prometheus metrics, health probes | Know before users complain                          |

**Core Flow**: Employee submits → Rules engine evaluates → Manager notified → Approval received → State advances or escalates on timeout

---

## Technical Stack

Intentionally minimal. Solves technical problems, not organizational ones.

| Layer           | Technology                                      | Rationale                                            |
| --------------- | ----------------------------------------------- | ---------------------------------------------------- |
| Backend         | [ASP.NET](http://asp.net/) Core 8, Minimal APIs | Performance, dependency clarity                      |
| Frontend        | HTMX + Alpine.js                                | Server-rendered reliability, modern interactivity    |
| Database        | PostgreSQL 15                                   | Row-Level Security, JSONB rules, advisory locks      |
| Caching/Locks   | Redis                                           | Distributed idempotency, session backing             |
| Background Jobs | Hangfire + PostgreSQL                           | Exactly-once execution, no additional infrastructure |
| Observability   | Serilog, Prometheus, Grafana                    | Structured logs, measurable SLOs                     |

**Absent by Design**: Kubernetes, microservices, message brokers, React/SPA

---

## Project Structure

```
src/
├── LeaveFlow.Domain/          Aggregates, events, value objects (no deps)
├── LeaveFlow.Application/     Use cases, ports (interfaces)
├── LeaveFlow.Infrastructure/  Adapters: EF Core, Redis, Hangfire, Email
├── LeaveFlow.Web/             HTMX frontend, middleware, health checks
└── LeaveFlow.Worker/          Background service (Hangfire processor)

tests/
├── Unit/                      Domain logic, 100% branch coverage
├── Integration/               Database, API contracts, concurrency
└── Load/                      k6 scenarios, 1000 RPS validation

docs/
├── ADR/                       Architecture Decision Records
├── OPERATIONS.md              Runbooks, incident response
└── THREAT-MODEL.md            Security analysis
```

**Pattern**: Clean Architecture / Ports and Adapters. Domain knows nothing of HTTP, database, or email. Infrastructure is replaceable.

---

## System Design

LeaveFlow uses **Clean Architecture** to ensure testability and maintainability.

- **Core Principle**: Business logic depends on nothing.
- **Documentation**: See [Architecture Overview](docs/ARCHITECTURE.md) for dependency rules and diagrams.

---

## Contact

Built by Allan Jericho Bargamento as deliberate practice in system design.

- Architecture questions: Open an issue
- Security concerns: security@leaveflow.dev (PGP key in repo)
- Hiring inquiries: [LinkedIn](https://linkedin.com/in/allan-jericho)
