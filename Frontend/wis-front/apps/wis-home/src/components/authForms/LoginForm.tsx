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
// import { useAuth } from '../../hooks/useAuth';
// import { useNavigate } from '@tanstack/react-router';
import { useGlobalState } from '../../main';
import { useEffect, useState } from 'react';
import { jwtDecode } from 'jwt-decode';
import { SIGN_IN_URL } from '../../api/urls';



interface Credentials {
      username: String,
      password: String,
    };


// Login function
async function loginUser(credentials: Credentials)  {

  //SET credentials: "include" to work with server CORS policy ✅
  const response = await fetch(SIGN_IN_URL, {
    method: "POST",
    headers: {
      "Content-Type": "application/json",
    },
    credentials: 'include',
    body: JSON.stringify(credentials),
  });
  //const data = await response.json();
  //console.log(response)
  return response;
}


//Login form component
const LoginForm = () => {
  const { setGlobalState } = useGlobalState();
  //const navigate = useNavigate({ from: '/Login' });
  const [jwt, setJwt] = useState<string | undefined>(undefined);


  async function onSubmit(values: z.infer<typeof formSchema>) {
    
    try {
      const loginAttempt = await loginUser({username:values.email, password:values.password});

      console.log("api response: " + loginAttempt.status);
    
      if (loginAttempt.status === 200) {
        //console.log(loginAttempt)
        const data = await loginAttempt.json();
        console.log(data)
        setJwt(data.token);
        console.log("user logged in");
      
        //navigate({to:"/"})

      }
      else {
        console.log("Failed to log in")
      }
    }
    catch (error) {
      console.log("Could not log in: " + error )
    }
    
  }


  useEffect(() => {
    if (jwt) {

      const decodedToken = jwtDecode(jwt);
      //Find a solution for this
      const nameClaim = decodedToken['http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name'];
      const roleClaim = decodedToken['http://schemas.microsoft.com/ws/2008/06/identity/claims/role'];

      // console.log(decodedToken);
      // console.log(nameClaim);
      // console.log(roleClaim);

      setGlobalState(prevState => ({
      ...prevState,
      isLoggedIn: true, // Toggle someProperty to true/false
      accessToken: jwt,
      userName: nameClaim,
      role: roleClaim,
      }));
    }

  }, [jwt]);



  // zod form schema
  const formSchema = z.object({
  email: z.string().email( {message: "Please enter email"}),
  password: z.string().min(1, { message: "Please enter password" }),
  newPassword: z
    .string()
    .optional(),
});


  const form = useForm<z.infer<typeof formSchema>>({
    resolver: zodResolver(formSchema),
    defaultValues: {
      email: "",
      password: "",
      newPassword: "",
    },
  });


  
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