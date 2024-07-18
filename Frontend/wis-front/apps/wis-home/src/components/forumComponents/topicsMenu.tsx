import { ScrollArea, ScrollBar, Separator } from "@repo/ui";
import { Link } from "@tanstack/react-router";
import { Route } from "../../routes/__root.tsx";
import { useEffect, useState } from "react";
import { AddTopic } from "./addTopic.tsx";
import { useForumApi } from "../../api/ForumApi.ts";

function TopicsMenu() {
  const topics = Route.useLoaderData();
  const [topicsArr, setTopicsArr] = useState(topics);
  const { getTopics } = useForumApi();
  const [trigger, setTrigger] = useState(false);

  useEffect(() => {
    // Define an async function inside the useEffect
    async function fetchTopicsAndUpdateState() {
      try {
        const newTopicsList = await getTopics(); // Wait for the promise to resolve
        setTopicsArr(newTopicsList); // Then update the state with the fetched topics
      } catch (error) {
        console.error("Failed to fetch topics:", error);
        // Handle error (e.g., show an error message)
      }
    }

    fetchTopicsAndUpdateState(); // Call the async function
  }, [trigger]);

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
          topicsArr={topics}
          setTopicsArr={setTopicsArr}
          setTrigger={setTrigger}
        />
        <ScrollArea className=" pl-5">
          {topicsArr.map((topic) => (
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
