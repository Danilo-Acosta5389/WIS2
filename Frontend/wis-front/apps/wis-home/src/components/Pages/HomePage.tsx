import { Button } from "@repo/ui";
import { useAuth } from "../../hooks/useAuth";
import { useEffect, useState } from "react";
import { useGlobalState } from "../../main";


const HomePage = () => {
    const { globalState, setGlobalState } = useGlobalState();
    const [signedIn, setSignedIn] = useState(globalState.isLoggedIn);
    const context = useAuth();
    

    const handleSignOut = () => {
        context.signOut();
        setGlobalState(prevState => ({
      ...prevState,
      isLoggedIn: !prevState.isLoggedIn // Toggle someProperty to true/false
      }));
      setSignedIn(globalState.isLoggedIn)
    }

    console.log("global state is: " + globalState.isLoggedIn );
    
    useEffect(() => {
        console.log(context.isLogged());
        setSignedIn(globalState.isLoggedIn)
    }, [handleSignOut, globalState.isLoggedIn])

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