import { Outlet, createRootRouteWithContext } from "@tanstack/react-router";
import { AuthContext } from "../hooks/useAuth.ts";
import { NavBar } from "../components/NavBar.tsx";
import { useForumApi } from "../api/ForumApi.ts";

type RouterContext = {
  authentication: AuthContext;
};

const { getTopics } = useForumApi();

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
