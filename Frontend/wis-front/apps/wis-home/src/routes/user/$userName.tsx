import { createFileRoute } from "@tanstack/react-router";
import ProfilePage from "../../components/pages/ProfilePage";
import { useUserApi } from "../../api/UserApi";

const { GetUser } = useUserApi();

export const Route = createFileRoute("/user/$userName")({
  component: ProfilePage,
  loader: async ({ params }) => await GetUser(params.userName),
});
