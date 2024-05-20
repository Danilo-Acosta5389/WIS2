import { createFileRoute } from "@tanstack/react-router";
import MainView from "../../../components/forumComponents/mainView";

export const Route = createFileRoute("/forum/$topic/")({
  component: Topic,
});

function Topic() {
  return <MainView />;
}

export default Topic;
