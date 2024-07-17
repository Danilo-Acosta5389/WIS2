import { ScrollArea, ScrollBar, Separator } from "@repo/ui";
import { Link } from "@tanstack/react-router";
import { Route } from "../../routes/__root.tsx";
import { useEffect, useState } from "react";
import { AddTopic } from "./addTopic.tsx";

function TopicsMenu() {
  const topics = Route.useLoaderData();
  const [rerender, setRerender] = useState(false);
  useEffect(() => {
    //console.log(rerender);
    setRerender(false);
  }, [rerender]);

  return (
    <>
      <div className=" hidden lg:flex h-full w-96 bg-gray-800 flex-col">
        <span className=" m-4 text-xl font-extrabold leading-none tracking-tight md:text-3xl lg:text-4xl text-white">
          Topics
        </span>
        <Separator className=" mt-5 w-11/12 self-center" />
        <AddTopic
          className={
            "text-white text-xl flex flex-row m-5 p-2 hover:bg-gray-500 cursor-pointer hover:font-bold hover:rounded-sm"
          }
          plusSize={28}
          plusColor={"white"}
        />
        <ScrollArea className=" pl-5">
          {topics.map((topic) => (
            <div
              key={topic.id}
              className=" text-white text-md cursor-pointer p-2 hover:bg-gray-500 hover:text-2xl hover:rounded-sm"
            >
              <Link
                className="block font-semibold text-white"
                to="/forum/$topic"
                params={{
                  topic: topic.title,
                }}
                activeProps={{
                  style: { fontWeight: "bold", fontSize: "1.5rem" },
                }}
              >
                {topic.title}
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
