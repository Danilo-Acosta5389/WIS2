import { Outlet, createRootRouteWithContext } from "@tanstack/react-router";
import { AuthContext } from "../hooks/useAuth";
import { NavBar } from "@repo/ui";

type RouterContext = {
    authentication: AuthContext;
}

//Navbar goes in Route

export const Route = createRootRouteWithContext<RouterContext>()({
    component: () => (
        <>
        <NavBar />
        <Outlet />
        </>
    )
});