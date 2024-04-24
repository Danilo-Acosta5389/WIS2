import { NavBar } from "@repo/ui"
import LoginForm  from "../auth/LoginForm";

const LoginPage = () => {
    return(
      <>
      <NavBar />
      <div className=" w-screen h-screen flex items-center justify-center flex-col">
          <LoginForm />
        </div>
      </>
        
    )
}

export default LoginPage;