# Build .NET Applications with C# Assignment

## 📌 Overview
This project contains:
- An ASP.NET Core Web API for managing pizzas (CRUD operations)
- A console application that generates a sales summary report from text files

---

## 🍕 Part 1: Web API (Pizza API)

Built using .NET 8 and ASP.NET Core Minimal API.

### ✔ Evidence: GET /pizza

**Status Code:** 200 OK

```json
[
  {
    "id": 1,
    "name": "Classic Italian",
    "isGlutenFree": false
  },
  {
    "id": 2,
    "name": "Veggie",
    "isGlutenFree": true
  },
  {
    "id": 3,
    "name": "Meat Lovers",
    "isGlutenFree": false
  },
  {
    "id": 4,
    "name": "BBQ Chicken",
    "isGlutenFree": false
  }
]