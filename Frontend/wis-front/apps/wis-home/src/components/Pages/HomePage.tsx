import { Button } from "@repo/ui";
import { useEffect, useState } from "react";
import { useGlobalState } from "../../main";
import { useAuth } from "../../hooks/useAuth";






const HomePage = () => {
  const { globalState, setGlobalState } = useGlobalState();
  const [signedIn, setSignedIn] = useState(false);
  const {signOut} = useAuth();

  const handleSignOut = async () => {
    await signOut();
    setGlobalState(prevState => ({
      ...prevState,
      isLoggedIn: false,
      accessToken: "",
      userName: "",
      role: ""
      }));
    setSignedIn(globalState.isLoggedIn);
  }

  useEffect(() => {
    setSignedIn(globalState.isLoggedIn);
  }, [globalState])

    return(
        <>
        {signedIn ? 
        (
            <>
            <span className=" m-4 text-4xl font-extrabold leading-none tracking-tight md:text-5xl lg:text-6xl text-white">What <br/>Is<br/>Space</span>
        <Button className="text-sm font-semibold leading-6 text-black bg-white mx-4 hover:bg-gray-200"
            onClick={handleSignOut}>
            Sign out
        </Button>
            </>
        )
        : (
            <span className=" m-4 text-4xl font-extrabold leading-none tracking-tight md:text-5xl lg:text-6xl text-white">Sign in</span>
        ) }
        
        </>
    )
}

export default HomePage;