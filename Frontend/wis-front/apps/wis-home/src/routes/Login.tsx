import { createFileRoute, redirect } from "@tanstack/react-router";
import LoginPage from "../components/Pages/LoginPage";


export const Route = createFileRoute('/Login')({
  beforeLoad: ({ context }) => {
    const {isLogged} = context.authentication;
    if(isLogged()) {
      throw redirect({
        to: '/'
      });
    }
  },
  component: LoginPage,
});
