import { createFileRoute } from "@tanstack/react-router";
import PostCard from "../../../components/forumComponents/postCard";
import { getSinglePost } from "../../../api/ForumApi";

//Will fix type any
export const Route = createFileRoute("/forum/$topic/$postId")({
  component: PostCard,
  loader: async ({ params }) => await getSinglePost(Number(params.postId)),
});
