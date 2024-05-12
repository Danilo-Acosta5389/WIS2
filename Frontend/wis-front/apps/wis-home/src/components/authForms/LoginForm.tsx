"use client"

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
    FormDescription
} from '@repo/ui';
import { useAuth } from '../../hooks/useAuth';
import { useNavigate } from '@tanstack/react-router';
import { useGlobalState } from '../../main';
import { useEffect } from 'react';



interface Credentials {
      username: String,
      password: String,
    };

async function loginUser(credentials: Credentials)  {
  const response = await fetch("https://localhost:7118/api/Auth/Login", {
    method: "POST",
    headers: {
      "Content-Type": "application/json",
    },
    body: JSON.stringify(credentials),
  }).then((data) => data.json());
  return response;
}


const formSchema = z.object({
  email: z.string().email( {message: "Please enter email"}),
  password: z.string().min(1, { message: "Please enter password" }),
  newPassword: z
    .string()
    .optional(),
});




const LoginForm = () => {
  const context = useAuth();
  const navigate = useNavigate({ from: '/Login' })
  const { globalState, setGlobalState } = useGlobalState();

  const form = useForm<z.infer<typeof formSchema>>({
    resolver: zodResolver(formSchema),
    defaultValues: {
      email: "",
      password: "",
      newPassword: "",
    },
  });


  async function onSubmit(values: z.infer<typeof formSchema>) {
    
    const loginAttempt = await loginUser({username:values.email, password:values.password});
    console.log(loginAttempt.isLoggedIn);
    
    if (loginAttempt.isLoggedIn) {
      context.signIn();

      setGlobalState(prevState => ({
      ...prevState,
      isLoggedIn: !prevState.isLoggedIn // Toggle someProperty to true/false
      }));

      console.log("user logged in");
      
      
      navigate({to:"/"})

    }
    else {
      console.log("Failed to log in")
    }
    
  }

  useEffect((() => {
    console.log("global state is: " + globalState.isLoggedIn );
  }), [globalState.isLoggedIn])


  
    return(
      <div className='w-80 pb-6 bg-black rounded-lg border  shadow-md  flex flex-col items-center justify-center text-white '>
        <div className=" h-16 border-b mb-6 w-full rounded-t-lg flex flex-row items-center justify-center ">
          <h3 className=" text-lg font-semibold ">Login</h3>
        </div>
        <Form {...form}>
      <form onSubmit={form.handleSubmit(onSubmit)} className="space-y-8">
        <FormField
          control={form.control}
          name="email"
          render={({ field }) => (
            <FormItem>
              <FormLabel>Email</FormLabel>
              <FormControl>
                <Input {...field} className='bg-black text-white' />
              </FormControl>
              <FormDescription className='sr-only'>
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
                  <Input type='password' className='bg-black'
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
      </div>
    )
}

export default LoginForm;