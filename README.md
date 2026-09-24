# RegisterWeb

A simple registration web application built with **ASP.NET Core** and **Angular**.

## Features

- Register personal information
- Select occupation
- Select gender
- Save registration data to SQLite
- Display the generated registration ID after successful registration

## Technologies

### Backend

- C#
- ASP.NET Core
- SQLite
- Microsoft.Data.Sqlite

### Frontend

- Angular
- TypeScript
- HTML
- CSS

## Development Environment

### Backend

- .NET 10
- ASP.NET Core

### Frontend

- Node.js 22.22.3
- npm 11.20.0
- Angular 21.x

## Project Structure

```text
RegisterWeb/
├── Controllers/
├── Models/
├── Repositories/
├── ViewModels/
├── Data/
│   └── Database.sql
├── ClientApp/
│   ├── src/
│   ├── package.json
│   └── proxy.conf.json
└── Program.cs
```

## How to Run

### 1. Run Backend

From the project root:

```bash
dotnet run
```

Backend:

```text
https://localhost:7265
```

### 2. Run Frontend

Open another terminal:

```bash
cd ClientApp
npm install
npm start
```

Frontend:

```text
http://localhost:4200
```

Open:

```text
http://localhost:4200/register
```

## API

### Register

```http
POST /api/register
```

The API saves the registration data to the SQLite database and returns the generated registration ID.

Example response:

```json
{
  "id": 1
}
```

## Database

The application uses SQLite for data storage.

Database schema and initial occupation data:

```text
Data/Database.sql
```

The local SQLite database file is excluded from Git using `.gitignore`.