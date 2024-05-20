import { ScrollArea, ScrollBar, Separator } from "@repo/ui";
import { Link } from "@tanstack/react-router";
import { topics } from "../../assets/data.ts";

function TopicsMenu() {
  //const pokemons = Route.useLoaderData();

  return (
    <>
      <div className=" hidden lg:flex h-full w-96 bg-gray-800 flex-col">
        <span className=" m-4 text-xl font-extrabold leading-none tracking-tight md:text-3xl lg:text-4xl text-white">
          Topics
        </span>
        <Separator className=" mt-5 w-11/12 self-center" />
        <ScrollArea className=" my-10 px-5">
          {topics.map((topic) => (
            <div
              key={topic.id}
              className=" text-white text-md my-5 cursor-pointer hove:bg-slate-200 hover:bg-gray-500"
            >
              <Link
                className="block font-semibold text-white"
                to="/forum/$topic"
                params={{
                  topic: topic.name,
                }}
                activeProps={{
                  style: { fontWeight: "bold", fontSize: "1.5rem" },
                }}
              >
                {topic.name}
              </Link>
            </div>
          ))}
          <ScrollBar orientation="vertical" />
        </ScrollArea>
      </div>
    </>
  );
}

export default TopicsMenu;
