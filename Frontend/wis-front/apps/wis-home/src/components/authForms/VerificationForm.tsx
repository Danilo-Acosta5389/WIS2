import {
  Button,
  Form,
  FormControl,
  FormDescription,
  FormField,
  FormItem,
  FormLabel,
  FormMessage,
  Input,
  useForm,
  z,
  zodResolver,
} from "@ui/components/index.ts";
import { useAuth } from "../../hooks/useAuth.ts";

function VerificationForm({
  email,
  setSignInState,
}: {
  email: string;
  setSignInState: React.Dispatch<
    React.SetStateAction<"NORMAL" | "BLOCKED" | "UNVERIFIED">
  >;
}) {
  const { verifyEmail } = useAuth();

  // zod form schema
  const formSchema = z.object({
    verificationCode: z.string(),
  });

  const form = useForm<z.infer<typeof formSchema>>({
    resolver: zodResolver(formSchema),
    defaultValues: {
      verificationCode: "",
    },
  });

  async function onSubmit(values: z.infer<typeof formSchema>) {
    const result = await verifyEmail({ email, code: values.verificationCode });
    if (result?.message === "VERIFIED") {
      console.log("Email verified");
      setSignInState("NORMAL");
    }
  }

  return (
    <Form {...form}>
      <form onSubmit={form.handleSubmit(onSubmit)} className="space-y-8">
        <FormField
          control={form.control}
          name="verificationCode"
          render={({ field }) => (
            <FormItem className="flex flex-col">
              <FormLabel className=" max-w-46 my-2 leading-4">
                Check your inbox
                <br />
                and/or junkmail
              </FormLabel>
              <FormDescription className="sr-only">
                <span>
                  A verification code has been sent to your email address.
                  <br />
                  If you cannot find it, please check junkmail.
                </span>
              </FormDescription>
              <FormControl>
                <Input
                  type="text"
                  placeholder="Verification code"
                  className="bg-black"
                  {...field}
                />
              </FormControl>
              <FormMessage />
            </FormItem>
          )}
        />
        <Button type="submit">Submit</Button>
      </form>
    </Form>
  );
}

export default VerificationForm;
