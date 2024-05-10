import { createFileRoute } from "@tanstack/react-router";
import LoginPage from "../components/Pages/LoginPage";


export const Route = createFileRoute('/Login')({
  component: LoginPage,
});


// const Login = () => {
//   return(
//     <LoginPage />
//   );
// };

// export default Login;
