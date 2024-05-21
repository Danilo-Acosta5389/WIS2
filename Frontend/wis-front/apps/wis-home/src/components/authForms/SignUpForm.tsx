import {
  Button,
  Form,
  FormControl,
  FormField,
  FormItem,
  FormLabel,
  FormMessage,
  Input,
  d,
  z,
  zodResolver,
  useForm,
} from "@repo/ui";

function SignUpForm() {
  // zod form schema
  const formSchema = z.object({
    email: z.string().email({ message: "Please enter email" }),
    userName: z.string().min(5, {
      message: "Please enter a userName that's at least 5 characters long",
    }),
    password: z.string().min(4, { message: "Please enter password" }),
    newPassword: z.string().optional(),
  });

  const form = useForm<z.infer<typeof formSchema>>({
    resolver: zodResolver(formSchema),
    defaultValues: {
      email: "",
      userName: "",
      password: "",
      newPassword: "",
    },
  });

  async function onSubmit(values: z.infer<typeof formSchema>) {
    console.log(values);
  }
  return (
    <d.Dialog>
      <d.DialogTrigger className=" h-10 w-20 text-sm text-white font-semibold inline-flex items-center justify-center whitespace-nowrap rounded-md font-md ring-offset-background transition-colors focus-visible:outline-none focus-visible:ring-2 focus-visible:ring-ring focus-visible:ring-offset-2 disabled:pointer-events-none disabled:opacity-50 hover:bg-gray-500 bg-blue-600 mx-8 lg:mx-0">
        Sign up <span aria-hidden="true"></span>
      </d.DialogTrigger>
      <d.DialogContent className=" bg-black text-white">
        <Form {...form}>
          <form
            onSubmit={form.handleSubmit(onSubmit)}
            className="bg-black text-white flex flex-col my-10 max-w-[48rem]"
          >
            <FormField
              control={form.control}
              name="email"
              render={({ field }) => {
                return (
                  <FormItem className="flex flex-col mb-2">
                    <FormLabel className=" flex flex-row justify-between">
                      <span className="text-xl font-semibold mx-2">Title</span>
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
            <d.DialogClose asChild className="">
              <Button
                type="submit"
                className=" bg-slate-200 max-w-24 text-black hover:bg-slate-500 mt-5 sm:-mt-6 ml-5 sm:z-10"
              >
                Submit
              </Button>
            </d.DialogClose>
          </form>
        </Form>
      </d.DialogContent>
    </d.Dialog>
  );
}

export default SignUpForm;
