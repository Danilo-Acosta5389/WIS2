import {
  Card,
  CardContent,
  CardDescription,
  CardFooter,
  CardHeader,
  ScrollArea,
  Separator,
  Textarea,
  Button,
  CardTitle,
  Label,
  Checkbox,
} from "@repo/ui";
import { Route } from "../../routes/forum/$topic/$postId";
import { CommentDetails, PostDetails, getComments } from "../../api/ForumApi";
import { useEffect, useState } from "react";
import { lucide } from "@repo/ui";
import { useNavigate } from "@tanstack/react-router";

function PostCard() {
  const { postId } = Route.useParams();
  const post: PostDetails[] = Route.useLoaderData();
  const [comments, setComments] = useState<CommentDetails[] | undefined>([]);
  const [showTextArea, setShowTextArea] = useState(false);

  const navigate = useNavigate({ from: "/forum/$topic/$postId" });
  //console.log(comments);
  useEffect(() => {
    const fetchComments = async () => {
      const response = await getComments(Number(postId));
      setComments(response);
    };
    fetchComments();
  }, []);
  return (
    <ScrollArea className="flex flex-col p-6 bg-black w-full">
      <lucide.ArrowLeft
        color="white"
        size={40}
        className=" cursor-pointer"
        onClick={() => {
          navigate({ to: "/forum/$topic" });
        }}
      />
      {post.map((p) => {
        if (p) {
          return (
            <div className=" m-4 text-white flex flex-col" key={p.id}>
              <span className="text-4xl font-extrabold leading-none tracking-tight md:text-5xl lg:text-6x">
                {p.title}
              </span>
              <span className=" mt-5">
                {p.subTitle != null ? (
                  <p className=" text-3xl mb-5">{p.subTitle}</p>
                ) : (
                  <p className=" text-3xl mb-5 sr-only"></p>
                )}
                <p>{p.text}</p>
              </span>
              <Separator className="mt-5 w-[90%] self-start" />
            </div>
          );
        }
        return null; // Or return a different component indicating no post found
      })}
      <div className=" max-w-[50rem] flex flex-col md:px-5 lg:px-7">
        {showTextArea ? (
          <div className="bg-black text-white flex flex-col p-5 m-5">
            <CardTitle>Comment</CardTitle>
            <Textarea
              rows={5}
              placeholder="Write your thoughts here..."
              className=" bg-slate-600 text-white max-w-[40rem] my-10 placeholder:text-slate-400"
            />
            <div className="flex flex-row justify-start">
              <Button
                onClick={() => {
                  setShowTextArea(false);
                }}
                className=" bg-slate-200 max-w-24 text-black hover:bg-slate-500 ml-5"
              >
                Submit
              </Button>
              <Checkbox className=" bg-slate-200 ml-8 size-5" />
              <Label className="text-white mx-2 text-sm">
                Do not display my username
              </Label>
            </div>
          </div>
        ) : (
          <Button
            onClick={() => {
              setShowTextArea(true);
            }}
            className=" bg-slate-200 max-w-min text-black hover:bg-slate-500 m-5"
          >
            <p className=" mr-1">Comment!</p>
            <lucide.StickyNote size={16} />
          </Button>
        )}
        {/* get better key, id is better */}
        {comments?.map((c) => (
          <Card
            key={c.userName}
            className="my-7 w-max text-white bg-black self-start"
          >
            <CardHeader>
              <CardDescription>
                {new Intl.DateTimeFormat("sv-SE").format(
                  new Date(c.createdAt.toString())
                )}
              </CardDescription>
            </CardHeader>
            <CardContent>
              <p>{c.comment}</p>
            </CardContent>
            <CardFooter className="">
              <p>{c.userName}</p>
            </CardFooter>
          </Card>
        ))}
      </div>
    </ScrollArea>
  );
}

export default PostCard;
