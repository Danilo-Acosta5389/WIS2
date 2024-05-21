import {
  Button,
  Checkbox,
  d,
  Form,
  FormControl,
  FormField,
  FormItem,
  FormLabel,
  FormMessage,
  Input,
  ScrollArea,
  ScrollBar,
  Separator,
  Textarea,
  useForm,
  z,
  zodResolver,
} from "@repo/ui";
import { Link } from "@tanstack/react-router";
import { Route } from "../../routes/__root";
import { lucide } from "@repo/ui";
import { useGlobalState } from "../../main";
import { createTopic, CreateTopic } from "../../api/ForumApi";
import { useEffect, useState } from "react";

function TopicsMenu() {
  //const pokemons = Route.useLoaderData();
  const topics = Route.useLoaderData();
  const { globalState } = useGlobalState();
  const [rerender, setRerender] = useState(false);

  // zod form schema
  const formSchema = z.object({
    title: z.string().min(1, { message: "Please enter a title" }),
    description: z.string().min(1, { message: "Please write something" }),
    isAnonymous: z.boolean(),
  });

  const form = useForm<z.infer<typeof formSchema>>({
    resolver: zodResolver(formSchema),
    defaultValues: {
      title: "",
      description: "",
      isAnonymous: false,
    },
  });

  const onSubmit = async (values: z.infer<typeof formSchema>) => {
    try {
      // console.log(JSON.stringify(values));
      const newPost: CreateTopic = {
        title: values.title,
        description: values.description,
        createdAt: new Date(),
        userName: globalState.userName,
        isAnonymous: values.isAnonymous,
      };

      await createTopic(newPost);

      form.reset();
      console.log(newPost);
      setRerender(true);
    } catch (err) {
      console.log(err);
    }
  };

  useEffect(() => {
    console.log(rerender);
    setRerender(false);
  }, [rerender]);

  return (
    <>
      <div className=" hidden lg:flex h-full w-96 bg-gray-800 flex-col">
        <span className=" m-4 text-xl font-extrabold leading-none tracking-tight md:text-3xl lg:text-4xl text-white">
          Topics
        </span>
        <Separator className=" mt-5 w-11/12 self-center" />
        <d.Dialog>
          <d.DialogTrigger className=" text-white text-xl flex flex-row m-5 p-2 hover:bg-gray-500 cursor-pointer hover:font-bold hover:rounded-sm">
            <lucide.Plus size={28} color="white" />
            <span>Add topic</span>
          </d.DialogTrigger>
          <d.DialogContent className=" bg-black text-white">
            <Form {...form}>
              <form
                onSubmit={form.handleSubmit(onSubmit)}
                className="bg-black text-white flex flex-col my-10 max-w-[48rem]"
              >
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
                          <Input
                            {...field}
                            placeholder="The name of this topic..."
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
                  name="description"
                  render={({ field }) => {
                    return (
                      <FormItem className="flex flex-col">
                        <FormLabel className=" flex flex-row justify-between">
                          <span className="text-2xl font-semibold mx-2">
                            Description
                          </span>
                        </FormLabel>
                        <FormControl className="my-15">
                          {/* <CardTitle>Comment</CardTitle> */}
                          <Textarea
                            {...field}
                            rows={5}
                            placeholder="What is this topic about?"
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
                    <FormItem className="flex flex-row sm:justify-end items-center mt-6 ml-5">
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
                <d.DialogClose type="submit" asChild>
                  <Button className=" bg-slate-200 max-w-24 text-black hover:bg-slate-500 mt-5 sm:-mt-6 ml-5 sm:z-10">
                    Submit
                  </Button>
                </d.DialogClose>
              </form>
            </Form>
          </d.DialogContent>
        </d.Dialog>
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
