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
  Separator,
  Textarea,
  useForm,
  z,
  zodResolver,
} from "@repo/ui";
import { lucide } from "@repo/ui";
import { useGlobalState } from "../../main.tsx";
import { CreateTopic } from "../../api/ForumApi.ts";
import { useState } from "react";
import { useForumApi } from "../../api/ForumApi.ts";

type AddTopicPorps = {
  className: string;
  plusSize: number;
  plusColor: string;
};

export function AddTopic({ className, plusSize, plusColor }: AddTopicPorps) {
  const { globalState } = useGlobalState();
  const [successful, setSuccessful] = useState(false);
  const { createTopic } = useForumApi();

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

      await createTopic(newPost, globalState.accessToken);

      form.reset();
      console.log(newPost);
      setSuccessful(true);
    } catch (err) {
      console.log(err);
      setSuccessful(true);
      form.reset();
    }
  };

  return (
    <>
      {(globalState.role === "Super" ||
        globalState.role === "Creator" ||
        globalState.role === "Admin") && (
        <d.Dialog>
          <d.DialogTrigger className={className}>
            <lucide.Plus
              className=" self-center"
              size={plusSize}
              color={plusColor}
            />
            <span>Add topic</span>
          </d.DialogTrigger>
          <d.DialogContent className=" bg-black text-white">
            <d.DialogTitle>Add new topic</d.DialogTitle>
            <Separator />
            {!successful ? (
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
                        <FormItem className="flex flex-col mb-6">
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
                        <FormItem className="flex flex-col mb-6">
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
                  <Button
                    type="submit"
                    className=" bg-slate-200 max-w-24 text-black hover:bg-slate-500 mt-5 sm:-mt-6 ml-5 sm:z-10"
                  >
                    Submit
                  </Button>
                </form>
              </Form>
            ) : (
              <>
                <d.DialogHeader>Topic was successfully added!</d.DialogHeader>
                <p>Please refresh the page</p>
                <d.DialogClose onClick={() => setSuccessful(false)}>
                  Continue
                </d.DialogClose>
              </>
            )}
          </d.DialogContent>
        </d.Dialog>
      )}
    </>
  );
}
