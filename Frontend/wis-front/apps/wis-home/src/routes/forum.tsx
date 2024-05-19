import { createFileRoute } from "@tanstack/react-router";
import ForumPage from "../components/Pages/ForumPage";
import { getPokemonList } from "../api/testData";

export const Route = createFileRoute("/forum")({
  component: ForumPage,
  loader: getPokemonList,
});
