import {
  AlertDialogAction,
  AlertDialogCancel,
  AlertDialogContent,
  AlertDialogDescription,
  AlertDialogFooter,
  AlertDialogHeader,
  AlertDialogTitle,
  Form,
  FormControl,
  FormField,
  FormItem,
  FormMessage,
  Textarea,
  useForm,
  z,
  zodResolver,
} from "@ui/components/index.ts";
import { CreateReportDetails, useReportApi } from "../api/ReportApi.ts";

const Report = ({
  id,
  userName,
  type,
  jwt,
}: {
  id: number;
  userName: string;
  type: string;
  jwt: string;
}) => {
  const { createReport } = useReportApi();
  const formSchema = z.object({
    message: z
      .string()
      .max(250, { message: "Max length is 250 characters" })
      .optional(),
  });

  const form = useForm<z.infer<typeof formSchema>>({
    resolver: zodResolver(formSchema),
    defaultValues: { message: "" },
  });

  // function handleUpgrade(reportDetails) {
  //   console.log("UPGRADE USER " + JSON.stringify(newDetails));
  //   form.reset;
  // }

  function onSubmit(data: z.infer<typeof formSchema>) {
    const reportDetails: CreateReportDetails = {
      itemId: id,
      userName: userName,
      url: window.location.href,
      type: type,
      message: data.message,
    };
    //console.log(JSON.stringify(reportDetails) + " " + jwt);
    createReport(reportDetails, jwt);
    form.reset();
  }
  return (
    <AlertDialogContent>
      <AlertDialogHeader>
        <AlertDialogTitle>Are you sure about reporting?</AlertDialogTitle>
        <AlertDialogDescription>
          Help us by motivating why you are reporting this {type.toLowerCase()}.
          Leave blank if you don't want to.
        </AlertDialogDescription>
      </AlertDialogHeader>
      <Form {...form}>
        <form
          onSubmit={form.handleSubmit(onSubmit)}
          className=" text-black flex flex-col max-w-[48rem]"
        >
          <FormField
            control={form.control}
            name="message"
            render={({ field }) => (
              <FormItem className="flex flex-col mb-6">
                {/* <FormLabel className=" flex flex-row justify-between">
                    <span className="text-2xl font-semibold mx-2">
                      Description
                    </span>
                  </FormLabel> */}
                <FormControl className="my-15">
                  {/* <CardTitle>Comment</CardTitle> */}
                  <Textarea
                    rows={5}
                    placeholder="Reason for report is optional."
                    className=" bg-slate-600 text-white max-w-[40rem] placeholder:text-slate-400"
                    {...field}
                  />
                </FormControl>
                <FormMessage className=" text-lg sm:mt-1 sm:ml-5 justify-self-end" />
              </FormItem>
            )}
          />
          {/* <Button
            type="submit"
            className=" bg-slate-200 max-w-24 text-black hover:bg-slate-500 mt-5 sm:-mt-6 ml-5 sm:z-10"
          >
            Submit
          </Button> */}
          <AlertDialogFooter>
            <AlertDialogCancel>Cancel</AlertDialogCancel>
            <AlertDialogAction type="submit">Submit</AlertDialogAction>
          </AlertDialogFooter>
        </form>
      </Form>
    </AlertDialogContent>
  );
};

export default Report;
