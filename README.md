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


## Some pictures of the app

![first-page](https://github.com/Danilo-Acosta5389/WIS2/assets/113366808/90711056-6077-4d6c-86a9-3b33c3209300)
Landing page.

![menu-desktop](https://github.com/Danilo-Acosta5389/WIS2/assets/113366808/938127a7-ef84-4e67-b689-c1203be7fe08)
Cool TailwindUI navbar and dropdown.

![register-modal](https://github.com/Danilo-Acosta5389/WIS2/assets/113366808/4df2edbc-5313-4b69-ab99-e32510e78926)
Register modal.

![sign-in-page](https://github.com/Danilo-Acosta5389/WIS2/assets/113366808/d1809eea-c959-41f7-8b8a-1b7360063f58)
Sign in screen.

![signed-in-user-drop-down](https://github.com/Danilo-Acosta5389/WIS2/assets/113366808/2062bcd7-3c82-45f5-930a-35c69737c152)
Signed in state in forum.


![new-post](https://github.com/Danilo-Acosta5389/WIS2/assets/113366808/82ff939c-f53a-4a4d-8937-c4ae47308003)
Create new post.

![comment-post](https://github.com/Danilo-Acosta5389/WIS2/assets/113366808/d79c5231-ffab-4ce5-a297-06a37abb4a63)
Add comment.

![different-role-may-add-topic](https://github.com/Danilo-Acosta5389/WIS2/assets/113366808/544e915e-d519-42fa-b8e5-18d2e0cd4690)
Signed in as different role, may add new topics.

![new-topic-modal](https://github.com/Danilo-Acosta5389/WIS2/assets/113366808/5a29c874-dfd6-4c3f-a378-51222ef7cbdc)
Create new topic.

![forum-mobile-view](https://github.com/Danilo-Acosta5389/WIS2/assets/113366808/f39e7d44-b7d3-4b60-80f2-8c29d5bd6143)

Mobile friendly.

![mobile-menu](https://github.com/Danilo-Acosta5389/WIS2/assets/113366808/dfbd3edd-e124-4bd5-80dd-5d32dfd2a2d2)

Mobile menu.
