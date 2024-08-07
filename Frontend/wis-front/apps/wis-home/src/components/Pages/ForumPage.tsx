import { Outlet } from "@tanstack/react-router";
import TopicsMenu from "../forumComponents/topicsMenu.tsx";

function ForumPage() {
  return (
    <div className=" h-[89%] flex bg-black">
      <TopicsMenu />
      <Outlet />
    </div>
  );
}

export default ForumPage;
