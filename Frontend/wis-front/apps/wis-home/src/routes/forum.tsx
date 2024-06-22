import { createFileRoute } from "@tanstack/react-router";
import ForumPage from "../components/pages/ForumPage";

export const Route = createFileRoute("/forum")({
  component: ForumPage,
});
