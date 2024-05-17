import { Outlet, createRootRouteWithContext } from "@tanstack/react-router";
import { AuthContext } from "../hooks/useAuth";
import { NavBar } from "../components/NavBar";

type RouterContext = {
    authentication: AuthContext;
}

export const Route = createRootRouteWithContext<RouterContext>()({
    component: root
});


function root() {
    return (
        <>
        <NavBar />
        <Outlet />
        </>
    )
}