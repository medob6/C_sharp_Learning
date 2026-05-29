# 🛠️ .NET & C# — Platform Overview

> Part of the **C# Learning** repository for the **Topoease** project.  
> This file covers the .NET platform fundamentals before writing any code.

---

## 1. Environment Setup

Before writing any C#, the development environment needs to be configured.  
All setup instructions and tooling details are documented separately in this repository under `/setup`.

---

## 2. How .NET Works — The Compilation Pipeline

.NET supports three official languages:

- **C#** — most widely used, best community support
- **F#** — functional-first language
- **Visual Basic** — legacy, rarely used in new projects

All three follow the same compilation pipeline:

```
Source Code  →  Intermediate Language (IL)  →  Machine Code
     ↑                      ↑                        ↑
 C# / F# / VB          .NET Compiler            CLR + JIT
```

### Step-by-step:

1. **Source code** is written in C#, F#, or VB
2. The **.NET compiler** compiles it into **Intermediate Language (IL)** — a platform-neutral bytecode
3. The **JIT (Just-In-Time) compiler** converts IL into native machine code at runtime
4. The **CLR (Common Language Runtime)** manages the execution of that machine code

> **Note for C/C++ developers:** Unlike C/C++ which compiles directly to machine code,  
> .NET compiles to IL first. The JIT handles the final step at runtime — similar in concept  
> to how a C program goes through assembly, but managed by the runtime.

---

## 3. Why C#

C# is the dominant language in the .NET ecosystem for several reasons:

- Largest community and ecosystem
- Most tooling, libraries, and official documentation
- Primary language used professionally for .NET projects
- Only language that can use the full .NET compiler toolchain

Since .NET projects are built exclusively using the .NET compiler,  
everyone working in this ecosystem is typically referred to as a **.NET developer**,  
regardless of which of the three languages they use.

---

## 4. What is the .NET Framework

The .NET framework is a **complete development platform** built on two core components:

| Component | Full Name | Role |
|---|---|---|
| **CLR** | Common Language Runtime | Executes IL, manages memory, garbage collection |
| **BCL** | Base Class Library | Built-in types, collections, I/O, math, networking, etc. |

Think of it the same way as any other framework — it is the **set of tools, libraries,  
conventions, and workflow** that .NET developers build on top of.

You do not build from scratch. You build on what .NET provides.

---

## 5. .NET History — Why "Core" and What We Use

Understanding the naming is important because you will see `.NET Framework`, `.NET Core`, and `.NET` used interchangeably online, and they are **not the same thing**.

### The Three Eras

| Era | Name | Years | Platform |
|---|---|---|---|
| Legacy | **.NET Framework** | 2002 – 2019 | Windows only |
| Transition | **.NET Core** | 2016 – 2019 | Cross-platform |
| Modern | **.NET 5, 6, 7, 8, 9, 10...** | 2020 – now | Cross-platform |

### What Happened

- The original **.NET Framework** was Windows-only and tightly coupled to Windows APIs
- Microsoft rebuilt .NET from scratch as **.NET Core** — open source, cross-platform (Windows, Linux, macOS)
- Starting with **.NET 5**, Microsoft dropped the "Core" name and unified everything under just **.NET** with version numbers
- **.NET Framework** still exists but is in **maintenance mode** — no new features, only security patches

### What We Use — .NET 6

We are using **.NET 6**, which is:

- A **Long Term Support (LTS)** release — 3 years of official support
- Fully cross-platform — runs on Windows, Linux, macOS
- The foundation of modern ASP.NET Core, Blazor, MAUI, and class libraries
- What the book *C# 14 and .NET 10* builds on conceptually, just a newer version

> **Practical note:** Code written in .NET 6 is almost identical to .NET 8, 9, or 10.  
> The core C# language and BCL APIs are stable — only newer features get added on top.  
> So learning with .NET 6 is completely valid and transfers directly.

### .NET vs .NET Framework — Key Differences

| Feature | .NET Framework | .NET 6+ |
|---|---|---|
| Platform | Windows only | Cross-platform |
| Open source | No | Yes |
| Performance | Slower | Significantly faster |
| Future updates | No new features | Actively developed |
| Use for new projects | ❌ No | ✅ Yes |

---

## 7. Summary Diagram

```
┌─────────────────────────────────────────────┐
│              .NET Framework                 │
│                                             │
│   ┌─────────────────────────────────────┐   │
│   │         BCL (Base Class Library)    │   │
│   │  Collections · I/O · Math · Linq   │   │
│   └─────────────────────────────────────┘   │
│                                             │
│   ┌─────────────────────────────────────┐   │
│   │    CLR (Common Language Runtime)    │   │
│   │   Memory · GC · JIT · Execution     │   │
│   └─────────────────────────────────────┘   │
└─────────────────────────────────────────────┘
          ↑
   Your C# Code (compiled to IL)
```

---

## 8. Related Files in This Repo

| File | Description |
|---|---|
| `/setup/README.md` | Environment setup & tooling |
| `/fundamentals/` | C# syntax, types, control flow |
| `/oop/` | Classes, interfaces, inheritance |
| `/cad-math/` | Geometry & math in C# for Topoease |

---

*This document is part of the C# learning path for the Topoease CAD engine project.*