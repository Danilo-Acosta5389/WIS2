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
  Separator,
} from "@repo/ui";
import { useState } from "react";
import { useAuth } from "../../hooks/useAuth.ts";

function SignUpForm() {
  const [success, setSuccess] = useState(false);
  const [errorMsg, setErrorMsg] = useState<string | undefined>("");
  const { registerUser } = useAuth();

  // zod form schema
  const formSchema = z.object({
    email: z.string().email({ message: "Please enter email" }),
    userName: z.string().min(5, {
      message: "Please enter a username that is at least 5 characters long",
    }),
    password: z
      .string()
      .regex(
        /^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{6,}$/,
        "Password must be at least 6 characters long and include special characters, alphanumerics, upper and lower case"
      ),
  });

  const form = useForm<z.infer<typeof formSchema>>({
    resolver: zodResolver(formSchema),
    defaultValues: {
      email: "",
      userName: "",
      password: "",
    },
  });

  async function onSubmit(values: z.infer<typeof formSchema>) {
    try {
      const data = await registerUser({
        email: values.email,
        userName: values.userName,
        password: values.password,
      });
      console.log(data);
      if (data?.message != "Success") {
        setErrorMsg(data?.message);
        return;
      }
    } catch (err) {
      console.log(err);
    }
    form.reset();
    console.log(values);
    setSuccess(true);
    setErrorMsg("");
  }
  return (
    <d.Dialog>
      <d.DialogTrigger className=" h-10 w-20 text-sm text-white font-semibold inline-flex items-center justify-center whitespace-nowrap rounded-md font-md ring-offset-background transition-colors focus-visible:outline-none focus-visible:ring-2 focus-visible:ring-ring focus-visible:ring-offset-2 disabled:pointer-events-none disabled:opacity-50 hover:bg-gray-500 bg-blue-600 mx-8 lg:mx-0">
        Sign up <span aria-hidden="true"></span>
      </d.DialogTrigger>
      <d.DialogContent className=" bg-black text-white w-full max-w-96">
        <d.DialogTitle>Sign up</d.DialogTitle>
        <Separator className=" w-full" />
        {!success ? (
          <Form {...form}>
            <form
              onSubmit={form.handleSubmit(onSubmit)}
              className="bg-black text-white flex flex-col my-5 max-w-[48rem]"
            >
              <FormField
                control={form.control}
                name="email"
                render={({ field }) => {
                  return (
                    <FormItem className="flex flex-col mb-5">
                      <FormLabel className="text-lg mx-2">Email</FormLabel>
                      <FormControl className="">
                        <Input
                          {...field}
                          placeholder="Enter your email here..."
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
                name="userName"
                render={({ field }) => {
                  return (
                    <FormItem className="flex flex-col mb-5">
                      <FormLabel className=" flex flex-row justify-between">
                        <span className="text-xl font-semibold mx-2">
                          Username
                        </span>
                      </FormLabel>
                      <FormControl className="">
                        <Input
                          {...field}
                          placeholder="Enter your username here..."
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
                name="password"
                render={({ field }) => {
                  return (
                    <FormItem className="flex flex-col mb-5">
                      <FormLabel className=" flex flex-row justify-between">
                        <span className="text-xl font-semibold mx-2">
                          Password
                        </span>
                      </FormLabel>
                      <FormControl className="">
                        <Input
                          {...field}
                          type="password"
                          placeholder="Enter your password here..."
                          className=" bg-slate-600 text-white max-w-[40rem] placeholder:text-slate-400"
                        />
                      </FormControl>
                      <FormMessage className=" text-lg pt-2 sm:mt-1 sm:ml-5 justify-self-end" />
                      {errorMsg != "" && (
                        <p className=" text-lg pt-2 font-semibold sm:mt-1 sm:ml-5 justify-self-end text-destructive">
                          {errorMsg}
                        </p>
                      )}
                    </FormItem>
                  );
                }}
              />
              <Button
                type="submit"
                className=" bg-slate-200 max-w-24 text-black hover:bg-slate-500 hover:text-slate-200 mt-5 ml-5 sm:z-10"
              >
                Submit
              </Button>
            </form>
          </Form>
        ) : (
          <>
            <d.DialogHeader>Register successful</d.DialogHeader>
            <d.DialogClose
              onClick={() => {
                setSuccess(false);
              }}
            >
              Continue
            </d.DialogClose>
          </>
        )}
      </d.DialogContent>
    </d.Dialog>
  );
}

export default SignUpForm;
