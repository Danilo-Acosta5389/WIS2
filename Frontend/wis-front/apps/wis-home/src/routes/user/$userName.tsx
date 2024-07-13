import { createFileRoute } from "@tanstack/react-router";
import ProfilePage from "../../components/pages/ProfilePage.tsx";
import { useUserApi } from "../../api/UserApi.ts";

const { GetUser } = useUserApi();

export const Route = createFileRoute("/user/$userName")({
  component: ProfilePage,
  loader: async ({ params }) => await GetUser(params.userName),
});
