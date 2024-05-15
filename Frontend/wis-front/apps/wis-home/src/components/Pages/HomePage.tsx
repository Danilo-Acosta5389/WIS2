import { Button } from "@repo/ui";
import { useEffect, useState } from "react";
import { useGlobalState } from "../../main";


const HomePage = () => {
  const { globalState, setGlobalState } = useGlobalState();
  const [signedIn, setSignedIn] = useState(false);

  const handleSignOut = () => {
    setGlobalState(prevState => ({
      ...prevState,
      isLoggedIn: false, // Toggle someProperty to true/false
      accessToken: "",
      userName: "",
      role: ""
      }));
    setSignedIn(globalState.isLoggedIn);
  }

  useEffect(() => {
    setSignedIn(globalState.isLoggedIn);
    //console.log(JSON.stringify(globalState))
  }, [handleSignOut])

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