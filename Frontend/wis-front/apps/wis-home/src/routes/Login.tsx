import { createFileRoute } from "@tanstack/react-router";
import LoginPage from "../components/pages/LoginPage.tsx";

export const Route = createFileRoute("/Login")({
  // beforeLoad: ({ context }) => {
  //   const {isLogged} = context.authentication;
  //   if(isLogged()) {
  //     throw redirect({
  //       to: '/'
  //     });
  //   }
  // },
  component: LoginPage,
});
