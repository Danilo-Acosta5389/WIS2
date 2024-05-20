import { createFileRoute } from "@tanstack/react-router";
import { getPokemonList } from "../api/testData";
import ForumPage from "../components/Pages/ForumPage";

export const Route = createFileRoute("/forum")({
  component: ForumPage,
  loader: getPokemonList,
});
