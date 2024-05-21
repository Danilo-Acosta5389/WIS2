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
import { useEffect, useRef, useState } from "react";
import { Link } from "@tanstack/react-router";
import { Route } from "../../routes/forum/$topic";
import { Route as r } from "../../routes/__root";
import { PostDetails, getPosts } from "../../api/ForumApi";

function MainView() {
  const { topic } = Route.useParams();
  //To get selected id, temporary fix.
  const selected = r.useLoaderData().find((t) => t.title === topic)?.id;
  const [item, setItem] = useState(topic);
  const [id, setId] = useState(selected);
  const [posts, setPosts] = useState<PostDetails[] | undefined>();
  //console.log(posts);
  const intercept = useRef(false);

  useEffect(() => {
    // console.log("item is: " + item);
    // console.log("selected id is: " + id);

    if (intercept.current === true) {
      const fetchPosts = async () => {
        if (id !== undefined) {
          const postList = await getPosts(id);
          setPosts(postList);
        }
      };

      fetchPosts();
    }
    intercept.current = true;
  }, [item, id]);

  useEffect(() => {
    setItem(topic);
    setId(selected);
  }, [topic]);

  return (
    <ScrollArea className=" flex flex-col p-6 bg-black w-full">
      <span className=" m-4 text-4xl font-extrabold leading-none tracking-tight md:text-5xl lg:text-6xl text-white">
        {topic}
      </span>
      {posts?.map((p) => (
        <Link
          to={"/forum/$topic/$postId"}
          params={{
            topic: topic,
            postId: p.id.toString(),
          }}
          key={p.id}
        >
          <Card className=" cursor-pointer hover:bg-slate-800 my-7 w-10/12 self-center text-white bg-black">
            <CardHeader>
              <CardTitle>{p.title}</CardTitle>
              <CardDescription>{p.subTitle}</CardDescription>
            </CardHeader>
            <CardContent>
              <p>{p.text}</p>
            </CardContent>
            <CardFooter className=" sr-only">
              <p>Card Footer</p>
            </CardFooter>
          </Card>
          <Separator className=" mt-5 w-10/12 self-center" />
        </Link>
      ))}
    </ScrollArea>
  );
}

export default MainView;
