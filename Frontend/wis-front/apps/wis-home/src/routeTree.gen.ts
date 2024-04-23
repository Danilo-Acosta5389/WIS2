/* prettier-ignore-start */

/* eslint-disable */

// @ts-nocheck

// noinspection JSUnusedGlobalSymbols

// This file is auto-generated by TanStack Router

// Import Routes

import { Route as rootRoute } from './routes/__root'
import { Route as LoginImport } from './routes/Login'
import { Route as HomeImport } from './routes/Home'

// Create/Update Routes

const LoginRoute = LoginImport.update({
  path: '/Login',
  getParentRoute: () => rootRoute,
} as any)

const HomeRoute = HomeImport.update({
  path: '/Home',
  getParentRoute: () => rootRoute,
} as any)

// Populate the FileRoutesByPath interface

declare module '@tanstack/react-router' {
  interface FileRoutesByPath {
    '/Home': {
      preLoaderRoute: typeof HomeImport
      parentRoute: typeof rootRoute
    }
    '/Login': {
      preLoaderRoute: typeof LoginImport
      parentRoute: typeof rootRoute
    }
  }
}

// Create and export the route tree

export const routeTree = rootRoute.addChildren([HomeRoute, LoginRoute])

/* prettier-ignore-end */