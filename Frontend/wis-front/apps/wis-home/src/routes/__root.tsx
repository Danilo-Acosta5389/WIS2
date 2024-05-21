import { Outlet, createRootRouteWithContext } from "@tanstack/react-router";
import { AuthContext } from "../hooks/useAuth";
import { NavBar } from "../components/NavBar";
import { useForumApi } from "../api/ForumApi";

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
