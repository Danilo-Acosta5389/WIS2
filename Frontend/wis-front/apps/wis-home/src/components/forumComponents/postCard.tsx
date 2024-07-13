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
  Checkbox,
  z,
  zodResolver,
  useForm,
  Form,
  FormField,
  FormLabel,
  FormControl,
  FormItem,
  FormMessage,
} from "@repo/ui";
import { Route } from "../../routes/forum/$topic/$postId.tsx";
import {
  CommentDetails,
  CreateComment,
  PostDetails,
  useForumApi,
} from "../../api/ForumApi.ts";
import { useEffect, useState } from "react";
import { lucide } from "@repo/ui";
import { useNavigate } from "@tanstack/react-router";
import { useGlobalState } from "../../main.tsx";
import { ActionsDropdown } from "./mainView.tsx";

function PostCard() {
  const { postId } = Route.useParams();
  const post: PostDetails[] = Route.useLoaderData();
  const [comments, setComments] = useState<CommentDetails[] | undefined>([]);
  const [showTextArea, setShowTextArea] = useState(false);
  const navigate = useNavigate({ from: "/forum/$topic/$postId" });
  const { globalState } = useGlobalState();
  //console.log(globalState.accessToken);
  const { createComment, getComments } = useForumApi();

  // zod form schema
  const formSchema = z.object({
    textarea: z.string().min(1, { message: "Please write something" }),
    isAnonymous: z.boolean(),
  });

  const form = useForm<z.infer<typeof formSchema>>({
    resolver: zodResolver(formSchema),
    defaultValues: {
      textarea: "",
      isAnonymous: false,
    },
  });

  // Some issue with how the json is sent, it still works but not perfectly
  const onSubmit = async (values: z.infer<typeof formSchema>) => {
    try {
      // console.log(JSON.stringify(values));
      const comment: CreateComment = {
        userName: globalState.userName,
        comment: values.textarea,
        createdAt: new Date(),
        isAnonymous: values.isAnonymous,
        postId: parseInt(postId),
      };
      // console.log(comment);
      await createComment(comment, globalState.accessToken);
      setShowTextArea(false);
      form.reset();
    } catch (err) {
      console.log(err);
      setShowTextArea(false);
      form.reset();
    }
  };

  useEffect(() => {
    const fetchComments = async () => {
      const response = await getComments(Number(postId));
      // console.log(response);
      setComments(response);
    };
    fetchComments();
    // console.log(showTextArea);
  }, [showTextArea]);

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
                {p.title}{" "}
                {globalState.isLoggedIn && (
                  <ActionsDropdown
                    type={"POST"}
                    title={p.title}
                    role={globalState.role}
                    jwt={globalState.accessToken}
                    id={p.id}
                  />
                )}
              </span>
              <span className=" mt-5">
                {p.subTitle != null ? (
                  <p className=" text-3xl mb-5">{p.subTitle}</p>
                ) : (
                  <p className=" text-3xl mb-5 sr-only"></p>
                )}
                <p>{p.text}</p>
              </span>
              <div className="flex flex-row font-semibold mt-4 mr-10 self-end text-slate-400">
                <p>By "{p.userName}" - </p>
                <p className="ml-1">
                  {new Intl.DateTimeFormat("sv-SE").format(
                    new Date(p.createdAt.toString())
                  )}
                </p>
              </div>
              <Separator className="mt-5 w-[90%] self-start" />
            </div>
          );
        }
        return null; // Or return a different component indicating no post found
      })}
      <div className=" max-w-[50rem] flex flex-col md:px-5 lg:px-7">
        {globalState.isLoggedIn && (
          <>
            {showTextArea ? (
              <Form {...form}>
                <form
                  onSubmit={form.handleSubmit(onSubmit)}
                  className="bg-black text-white flex flex-col my-10"
                >
                  <FormField
                    control={form.control}
                    name="textarea"
                    render={({ field }) => (
                      <FormItem className="flex flex-col">
                        <FormLabel className=" flex flex-row justify-between mb-2">
                          <span className="text-2xl font-semibold mx-2">
                            Comment
                          </span>

                          <div
                            onClick={() => {
                              setShowTextArea(false);
                            }}
                            className=" flex flex-row text-lg hover:text-slate-400 cursor-pointer mr-20 md:mr-40"
                          >
                            <lucide.X size={22} />
                            <span className=" -m-[4px] ml-[1px]">close</span>
                          </div>
                        </FormLabel>
                        <FormControl className="my-15">
                          {/* <CardTitle>Comment</CardTitle> */}
                          <Textarea
                            {...field}
                            rows={5}
                            placeholder="Write your thoughts here..."
                            className=" bg-slate-600 text-white max-w-[40rem] placeholder:text-slate-400"
                          />
                        </FormControl>
                        <FormMessage className=" text-lg sm:mt-1 sm:ml-5 justify-self-end" />
                      </FormItem>
                    )}
                  />
                  <FormField
                    control={form.control}
                    name="isAnonymous"
                    render={({ field }) => (
                      <FormItem className="flex flex-row sm:justify-end mt-6 ml-5 sm:ml-0 sm:mr-[10rem]">
                        <FormControl className="">
                          <Checkbox
                            checked={field.value}
                            onCheckedChange={field.onChange}
                            className=" bg-slate-200 mt-2 size-5 mr-2"
                          />
                        </FormControl>
                        <FormLabel className="text-white text-md flex-wrap">
                          Do not display my username
                        </FormLabel>
                      </FormItem>
                    )}
                  />
                  <Button
                    type="submit"
                    className=" bg-slate-200 max-w-24 text-black hover:bg-slate-500 mt-5 sm:-mt-6 ml-5 sm:z-10"
                  >
                    Submit
                  </Button>
                </form>
              </Form>
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
          </>
        )}
        {/* get better key, id is better */}
        {comments?.map((c) => (
          <Card
            key={c.id}
            className="my-7 w-full text-white bg-black self-start"
          >
            <CardHeader className=" flex flex-row justify-between">
              <CardDescription>
                {new Intl.DateTimeFormat("sv-SE").format(
                  new Date(c.createdAt.toString())
                )}
              </CardDescription>
              {globalState.isLoggedIn && (
                <ActionsDropdown
                  type={"COMMENT"}
                  title={"comment"}
                  role={globalState.role}
                  jwt={globalState.accessToken}
                  id={c.id}
                />
              )}
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
