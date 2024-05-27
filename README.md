# Online Forum

## Overview

This project is a Single Page Application (SPA) that serves as an online forum. It is built using a monorepo architecture with Turborepo, React, and Vite, along with component libraries and Tanstack Router for routing. The frontend is written in TypeScript.

The backend consists of a RESTful web API, written in C# with .NET 8, and uses a SQL database.

## Main Functionality

- Default forum functions such as fetching topics, posts, and comments.
- Posting topics, posts, and comments.
- Authentication and authorization with JWT tokens.
- Sign in, sign out, and persistence of the signed-in state with refresh tokens and HttpOnly cookies.
- User roles that modify forum functionality based on whether the user is a regular user or has a higher role.

## Requirements

- Node.js >= 18
- pnpm 9.0.4 (may be altered in the `package.json` file)
- .NET 8
- Microsoft SQL Server

## Tech Stack

### Frontend

- Turborepo
- React with Vite
- Shadcn/ui
- TailwindCSS
- Tanstack Router

### Backend

- .NET 8
- Microsoft SQL Server
- Entity Framework

### NuGet Packages

- `microsoft.entityframeworkcore` 8.0.5
- `microsoft.entityframeworkcore.sqlserver` 8.0.5
- `swashbuckle.aspnetcore` 6.6.1
- `swashbuckle.aspnetcore.filters` 8.0.2
- `microsoft.identity.client` 4.61.0
- `microsoft.aspnetcore.identity.entityframeworkcore` 8.0.5
- `microsoft.aspnetcore.authentication.jwtbearer` 8.0.5
- `microsoft.entityframeworkcore.tools` 8.0.5

## How to Run

1. Clone the repository.
2. Open the solution (`.sln`) file in the backend project with Visual Studio.
   1. Set up the connection string in `appsettings.json` (there are two connection strings for separating databases).
3. Open the Package Manager Console.
   1. Run `Update-Database -Context "AuthDbContext"`.
   2. Run `Update-Database -Context "ApplicationDbContext"`.
4. Build and run the backend project. Ensure the backend project is running when running the frontend project.
5. Open the frontend project.
6. In the terminal, run `pnpm install`. All dependencies should install fine.
7. Run the command `pnpm run dev`.
8. Behold your running application.
