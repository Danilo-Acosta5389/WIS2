import { createFileRoute } from "@tanstack/react-router";
import HomePage from "../components/Pages/HomePage";


export const Route = createFileRoute('/')({
  component: HomePage,
});