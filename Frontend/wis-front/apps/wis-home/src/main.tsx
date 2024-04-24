import React from 'react'
import ReactDOM from 'react-dom/client'
import "@repo/ui/main.css";
import {
  createRootRoute,
  createRoute,
  createRouter,
  RouterProvider,
} from "@tanstack/react-router";
import Home from "./routes/Home.tsx";
import Login from "./routes/Login.tsx";


// Create root route object, this chandles the whole routing
const rootRoute = createRootRoute();

// Index routes are base routes of each route which includes, HomePage for now /
const indexRoute = createRoute({
  getParentRoute: () => rootRoute,
  path: "/",
  component: Home,
});

// Perhaps have landing page route of an authenticated user


const loginRoute = createRoute({
  getParentRoute: () => rootRoute,
  path: "login",
  component: Login,
});


// Tanstack router creates a router tree object using all the routes
const routeTree = rootRoute.addChildren([
  indexRoute,
  loginRoute,
]);

// Create the router object which will be passed to the Router provider
const router = createRouter({ routeTree });

declare module "@tanstack/react-router" {
  interface Register {
    // This infers the type of our router and registers it across your entire project
    router: typeof router;
  }
}

ReactDOM.createRoot(document.getElementById('root')!).render(
  <React.StrictMode>
    <body className=" h-screen bg-black text-white flex flex-col">
      <RouterProvider router={router} />
    </body>
  </React.StrictMode>,
)
