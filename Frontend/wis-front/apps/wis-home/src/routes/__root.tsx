import { Outlet, createRootRouteWithContext } from "@tanstack/react-router";
import { AuthContext } from "../hooks/useAuth";
import { NavBar } from "../components/NavBar";
import { getTopics } from "../api/ForumApi";

type RouterContext = {
  authentication: AuthContext;
};

export const Route = createRootRouteWithContext<RouterContext>()({
  component: root,
  loader: getTopics,
});

function root() {
  return (
    <div className="w-screen h-screen bg-black">
      <NavBar />
      <Outlet />
      {/* <TanStackRouterDevtools /> */}
    </div>
  );
}
