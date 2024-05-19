import {
  Card,
  CardContent,
  CardDescription,
  CardFooter,
  CardHeader,
  CardTitle,
  ScrollArea,
  Separator,
} from "@repo/ui";
import { useEffect, useState } from "react";
import { topics } from "../../assets/data";

function MainView(params: any) {
  const [item] = useState(topics[0].name);

  useEffect(() => {
    console.log("item is: " + item);
  }, [item]);
  return (
    <ScrollArea className=" flex flex-col p-6 bg-black w-full">
      <span className=" m-4 text-4xl font-extrabold leading-none tracking-tight md:text-5xl lg:text-6xl text-white">
        {params.name}
      </span>
      {topics
        .filter((topic) => topic.name === params.name)
        .map((topic) =>
          topic.posts.map((p) => (
            <>
              <Card className=" cursor-pointer hover:bg-slate-800 my-7 w-10/12 self-center text-white bg-black">
                <CardHeader>
                  <CardTitle>{p.title}</CardTitle>
                  <CardDescription>{p.post}</CardDescription>
                </CardHeader>
                <CardContent>
                  <p>{p.question}</p>
                </CardContent>
                <CardFooter>
                  <p>Card Footer</p>
                </CardFooter>
              </Card>
              <Separator className=" mt-5 w-10/12 self-center" />
            </>
          ))
        )}
    </ScrollArea>
  );
}

export default MainView;
