import { createFileRoute } from "@tanstack/react-router";
import ForumPage from "../components/Pages/ForumPage";

export const Route = createFileRoute("/forum")({
  component: ForumPage,
});
