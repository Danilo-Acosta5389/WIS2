import {
  Card,
  CardContent,
  CardDescription,
  CardFooter,
  CardHeader,
  CardTitle,
  ScrollArea,
  Separator,
  lucide,
  zodResolver,
  z,
  useForm,
  Button,
  Form,
  FormItem,
  FormLabel,
  FormControl,
  Checkbox,
  FormField,
  Textarea,
  FormMessage,
  Input,
  AlertDialog,
  DropdownMenu,
  DropdownMenuTrigger,
  DropdownMenuContent,
  DropdownMenuItem,
  AlertDialogTrigger,
  AlertDialogContent,
  AlertDialogHeader,
  AlertDialogTitle,
  AlertDialogDescription,
  AlertDialogFooter,
  AlertDialogCancel,
  AlertDialogAction,
} from "@repo/ui";
import { useEffect, useRef, useState } from "react";
import { Link } from "@tanstack/react-router";
import { Route } from "../../routes/forum/$topic/index.tsx";
import { Route as r } from "../../routes/__root.tsx";
import { useForumApi, CreatePost, PostDetails } from "../../api/ForumApi.ts";
import { useGlobalState } from "../../main.tsx";
import Report from "../reportComponent.tsx";

function MainView() {
  const { topic } = Route.useParams();
  //To get selected id, temporary fix.
  const selected = r.useLoaderData().find((t) => t.title === topic)?.id;
  const [item, setItem] = useState(topic);
  const [id, setId] = useState(selected);
  const [posts, setPosts] = useState<PostDetails[] | undefined>();
  const [showTextArea, setShowTextArea] = useState(false);
  //console.log(posts);
  const intercept = useRef(false);
  const { globalState } = useGlobalState();

  const { createPost, getPosts } = useForumApi();

  // zod form schema
  const formSchema = z.object({
    title: z.string().min(1, { message: "Please enter a title" }),
    subTitle: z.string(),
    text: z.string().min(1, { message: "Please write something" }),
    isAnonymous: z.boolean(),
  });

  const form = useForm<z.infer<typeof formSchema>>({
    resolver: zodResolver(formSchema),
    defaultValues: {
      title: "",
      subTitle: "",
      text: "",
      isAnonymous: false,
    },
  });

  const onSubmit = async (values: z.infer<typeof formSchema>) => {
    try {
      // console.log(JSON.stringify(values));
      const newPost: CreatePost = {
        title: values.title,
        subTitle: values.subTitle,
        text: values.text,
        createdAt: new Date(),
        userName: globalState.userName,
        topicId: Number(selected?.toString()),
        isAnonymous: values.isAnonymous,
      };

      //console.log(newPost);
      await createPost(newPost, globalState.accessToken);
      setShowTextArea(false);
      form.reset();
    } catch (err) {
      //console.log(err);
      setShowTextArea(false);
      form.reset();
    }
  };

  //Th useEffect hooks below are triggering the rerendering of the page.
  //Currently the postlist be fetched when component loads and when 'Create new post' textArea is opened and closed.
  //Might whant to change this to only fetch when textArea is closed to prevent too many requests.

  useEffect(() => {
    //console.log("item is: " + item);
    //console.log("selected id is: " + id);
    if (intercept.current === false) {
      const fetchPosts = async () => {
        if (id !== undefined) {
          const postList = await getPosts(id);
          setPosts(postList);
        }
      };
      fetchPosts();
      //console.log(intercept.current);
    }
    intercept.current = true;
  }, [item, id, showTextArea]);

  useEffect(() => {
    setItem(topic);
    setId(selected);
    intercept.current = false;
  }, [posts, topic, showTextArea]);

  return (
    <ScrollArea className=" flex flex-col p-6 bg-black w-full">
      <span className=" m-4 text-4xl font-extrabold leading-none tracking-tight md:text-5xl lg:text-6xl text-white">
        {topic}{" "}
        {globalState.isLoggedIn && (
          <ActionsDropdown
            type={"Topic"}
            role={globalState.role}
            title={topic}
            jwt={globalState.accessToken}
            id={id}
          />
        )}
      </span>

      {(globalState.role === "User" ||
        globalState.role === "Creator" ||
        globalState.role === "Admin" ||
        globalState.role === "Super") && (
        <>
          {showTextArea ? (
            <Form {...form}>
              <form
                onSubmit={form.handleSubmit(onSubmit)}
                className="bg-black text-white flex flex-col my-10 max-w-[48rem]"
              >
                <div
                  onClick={() => {
                    setShowTextArea(false);
                  }}
                  className=" flex flex-row text-lg hover:text-slate-400 cursor-pointer -mb-5 mr-5 md:mr-40 self-end z-10"
                >
                  <lucide.X size={22} />
                  <span className=" -m-[4px] ml-[1px]">close</span>
                </div>
                <FormField
                  control={form.control}
                  name="title"
                  render={({ field }) => {
                    return (
                      <FormItem className="flex flex-col mb-2">
                        <FormLabel className=" flex flex-row justify-between">
                          <span className="text-xl font-semibold mx-2">
                            Title
                          </span>
                        </FormLabel>
                        <FormControl className="">
                          {/* <CardTitle>Comment</CardTitle> */}
                          <Input
                            {...field}
                            placeholder="Write a title for your post here..."
                            className=" bg-slate-600 text-white max-w-[40rem] placeholder:text-slate-400"
                          />
                        </FormControl>
                        <FormMessage className=" text-lg sm:mt-1 sm:ml-5 justify-self-end" />
                      </FormItem>
                    );
                  }}
                />
                <FormField
                  control={form.control}
                  name="subTitle"
                  render={({ field }) => {
                    return (
                      <FormItem className="flex flex-col mb-2">
                        <FormLabel className=" flex flex-row justify-between">
                          <span className="text-xl font-semibold mx-2">
                            Subtitle
                          </span>
                        </FormLabel>
                        <FormControl className="my-15">
                          {/* <CardTitle>Comment</CardTitle> */}
                          <Input
                            {...field}
                            placeholder="Optional..."
                            className=" bg-slate-600 text-white max-w-[40rem] placeholder:text-slate-400"
                          />
                        </FormControl>
                        <FormMessage className=" text-lg sm:mt-1 sm:ml-5 justify-self-end" />
                      </FormItem>
                    );
                  }}
                />
                <FormField
                  control={form.control}
                  name="text"
                  render={({ field }) => {
                    return (
                      <FormItem className="flex flex-col">
                        <FormLabel className=" flex flex-row justify-between">
                          <span className="text-2xl font-semibold mx-2">
                            New post
                          </span>
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
                    );
                  }}
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
            <div
              onClick={() => {
                setShowTextArea(true);
              }}
              className=" text-white max-w-max text-xl flex flex-row m-5 p-2 hover:bg-gray-500 cursor-pointer hover:font-bold hover:rounded-sm"
            >
              <lucide.SquarePen size={28} color="white" />
              <span className=" ml-2">Create new post!</span>
            </div>
          )}
        </>
      )}

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
            <CardFooter className=" flex flex-row justify-end">
              <div className="flex flex-row font-semibold mt-4 mr-10 text-slate-400">
                <p>By "{p.userName}" - </p>
                <p className="ml-1">
                  {new Intl.DateTimeFormat("sv-SE").format(
                    new Date(p.createdAt.toString())
                  )}
                </p>
              </div>
            </CardFooter>
          </Card>
          <Separator className=" mt-5 w-10/12 self-center" />
        </Link>
      ))}
    </ScrollArea>
  );
}

export default MainView;

export const ActionsDropdown = (props: any) => {
  const [openDialog, setOpenDialog] = useState(false);
  const [option, setOption] = useState<"REPORT" | "INVISIBLE" | "">("");
  //console.log(props.id);
  return (
    <AlertDialog>
      <DropdownMenu open={openDialog}>
        {openDialog && (
          <div
            onClick={() => {
              setOpenDialog(!openDialog);
            }}
            className=" bg-black fixed top-0 bottom-0 left-0 right-0 z-50 pointer-events-auto opacity-55"
          ></div>
        )}
        <DropdownMenuTrigger
          onClick={() => {
            setOpenDialog(!openDialog);
          }}
          className=" hover:bg-slate-700 rounded relative bottom-1 md:bottom-2 md:mx-1 md:h-8"
        >
          <lucide.EllipsisVertical className=" m-0" color="lightgray" />
        </DropdownMenuTrigger>
        <DropdownMenuContent className=" bg-black text-white mr-3 relative top-2 ">
          <DropdownMenuItem className="cursor-pointer">
            <AlertDialogTrigger
              onClick={() => {
                setOption("REPORT");
                setOpenDialog(!openDialog);
              }}
              className=" text-white w-full text-start"
            >
              Report
            </AlertDialogTrigger>
          </DropdownMenuItem>
          {(props.role === "Admin" || props.role === "Super") && (
            <DropdownMenuItem className="cursor-pointer bg-red-600 focus:bg-red-700 focus:text-white">
              <AlertDialogTrigger
                onClick={() => setOption("INVISIBLE")}
                className=" text-white w-full text-start"
              >
                Make invisible
              </AlertDialogTrigger>
            </DropdownMenuItem>
          )}
        </DropdownMenuContent>
      </DropdownMenu>
      {option === "REPORT" && (
        <Report type={props.type} id={props.id} userName={""} jwt={props.jwt} />
      )}
      {option === "INVISIBLE" && (
        <Invisible
          type={props.type}
          title={props.title}
          jwt={props.jwt}
          id={props.id}
        />
      )}
    </AlertDialog>
  );
};

const Invisible = (props: any) => {
  let type = props.type;
  const { hideTopic, hidePost, hideComment } = useForumApi();

  function handleOption() {
    if (type === "Topic") {
      // console.log(props.title);
      hideTopic(props.title, props.jwt);
    }
    if (type === "Post") {
      // console.log(props.title);
      hidePost(props.id, props.jwt);
    }
    if (type === "Comment") {
      //console.log(props.title);
      hideComment(props.id, props.jwt);
    }
  }

  return (
    <AlertDialogContent>
      <AlertDialogHeader>
        <AlertDialogTitle>
          Are you absolutely sure about hiding {props.title}?
        </AlertDialogTitle>
        <AlertDialogDescription>
          This action cannot be undone. This will permanently delete your
          account and remove your data from our servers.
        </AlertDialogDescription>
      </AlertDialogHeader>
      <AlertDialogFooter>
        <AlertDialogCancel>Cancel</AlertDialogCancel>
        <AlertDialogAction onClick={handleOption}>Continue</AlertDialogAction>
      </AlertDialogFooter>
    </AlertDialogContent>
  );
};
