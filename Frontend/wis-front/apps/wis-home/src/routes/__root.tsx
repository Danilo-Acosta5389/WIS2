import { Outlet, createRootRouteWithContext } from "@tanstack/react-router";
import { AuthContext } from "../hooks/useAuth";
import { NavBar } from "../components/NavBar";

type RouterContext = {
    authentication: AuthContext;
}



export const Route = createRootRouteWithContext<RouterContext>()({
    component: root
});


function root() {
    // const context = useAuth();
    // const [signedIn, setSignedIn] = useState(context.isLogged());
    // useEffect(() => {
    //     console.log(signedIn)
        
    // }, [])

    return (
        <>
        <NavBar />
        <Outlet />
        </>
    )
}