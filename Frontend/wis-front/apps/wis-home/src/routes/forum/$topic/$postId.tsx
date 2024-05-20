import { createFileRoute } from "@tanstack/react-router";
import PostCard from "../../../components/forumComponents/postCard";

export const Route = createFileRoute("/forum/$topic/$postId")({
  component: PostCard,
});
