"use client";

import {
  z,
  useForm,
  zodResolver,
  Form,
  FormField,
  FormItem,
  FormControl,
  FormMessage,
  Button,
  Input,
  FormLabel,
  FormDescription,
} from "@repo/ui";
// import { useAuth } from '../../hooks/useAuth';
// import { useNavigate } from '@tanstack/react-router';
import { useGlobalState } from "../../main.tsx";
import { useAuth } from "../../hooks/useAuth.ts";
import { useEffect, useState } from "react";
import { JwtPayload, jwtDecode } from "jwt-decode";
import { useNavigate } from "@tanstack/react-router";

// For decoder
interface CustomJwtPayload extends JwtPayload {
  "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name": string;
  "http://schemas.microsoft.com/ws/2008/06/identity/claims/role": string;
  image: string;
}

//Login form component
const LoginForm = () => {
  const { setGlobalState } = useGlobalState();
  const navigate = useNavigate({ from: "/Login" });
  const [jwt, setJwt] = useState<string | undefined>(undefined);
  const { signIn } = useAuth();
  const [error, setError] = useState<boolean>(false);
  const [blocked, setBlocked] = useState(false);

  // zod form schema
  const formSchema = z.object({
    email: z.string().email({ message: "Please enter email" }),
    password: z.string().min(1, { message: "Please enter password" }),
    newPassword: z.string().optional(),
  });

  const form = useForm<z.infer<typeof formSchema>>({
    resolver: zodResolver(formSchema),
    defaultValues: {
      email: "",
      password: "",
      newPassword: "",
    },
  });

  async function onSubmit(values: z.infer<typeof formSchema>) {
    try {
      const login = await signIn({
        username: values.email,
        password: values.password,
      });
      //console.log(login === undefined ? "did not work" : "worked");
      if (login === "BLOCKED") {
        setBlocked(true);
        return;
      }
      if (login === undefined) {
        setError(true);
      } else {
        setJwt(login);
      }
    } catch (err) {
      console.log(err);
    }
  }

  useEffect(() => {}, [error]);

  useEffect(() => {
    if (jwt) {
      const decodedToken = jwtDecode<CustomJwtPayload>(jwt);
      //console.log(decodedToken);
      //Find a solution for this ✅
      const nameClaim =
        decodedToken[
          "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name"
        ];
      const roleClaim =
        decodedToken[
          "http://schemas.microsoft.com/ws/2008/06/identity/claims/role"
        ];
      const imageClaim = decodedToken["image"];

      setGlobalState((prev) => ({
        ...prev,
        isLoggedIn: true,
        accessToken: jwt,
        userName: nameClaim,
        role: roleClaim,
        image: imageClaim,
      }));
      navigate({ to: "/" });
    }
  }, [jwt]);

  return (
    <div className=" w-full max-w-80 pb-6 bg-black rounded-lg border  shadow-md  flex flex-col items-center justify-center text-white ">
      <div className=" h-16 border-b mb-6 w-full rounded-t-lg flex flex-row items-center justify-center ">
        <h3 className=" text-lg font-semibold ">Log in</h3>
      </div>
      {blocked ? (
        <>
          <p className=" w-full flex flex-wrap text-red-500 font-semibold text-lg p-5 m-2 text-center">
            This account has been blocked. Please contact admin to resolve this
            issue.
          </p>
        </>
      ) : (
        <Form {...form}>
          <form onSubmit={form.handleSubmit(onSubmit)} className="space-y-8">
            <FormField
              control={form.control}
              name="email"
              render={({ field }) => (
                <FormItem>
                  <FormLabel>Email</FormLabel>
                  <FormControl>
                    <Input {...field} className="bg-black text-white" />
                  </FormControl>
                  <FormDescription className="sr-only">
                    This is your email.
                  </FormDescription>
                </FormItem>
              )}
            />
            <FormField
              control={form.control}
              name="password"
              render={({ field }) => (
                <FormItem className="flex flex-col">
                  <FormLabel>Password</FormLabel>
                  <FormControl>
                    <Input type="password" className="bg-black" {...field} />
                  </FormControl>

                  <FormMessage />
                  {error && (
                    <p className=" text-red-500 font-semibold pt-2">
                      Wrong email or password
                    </p>
                  )}
                </FormItem>
              )}
            />
            <Button type="submit">Submit</Button>
          </form>
        </Form>
      )}
    </div>
  );
};

export default LoginForm;
