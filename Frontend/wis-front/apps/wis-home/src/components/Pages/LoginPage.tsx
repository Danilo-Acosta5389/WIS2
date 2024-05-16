import { Button } from "@repo/ui";
import LoginForm  from "../authForms/LoginForm";




const LoginPage = () => {
  

    return(
      <div className=" w-screen h-screen flex items-center justify-center flex-col">
          <LoginForm />
          <Button className=" mt-10">Refresh</Button>
      </div>
        
    )
}

export default LoginPage;