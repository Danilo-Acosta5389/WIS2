import { useAuth } from "./hooks/useAuth";
import { RouterProvider, createRouter } from "@tanstack/react-router";
import { routeTree } from "./routeTree.gen";
import useRefresh from "./hooks/useRefresh";
// import { useGlobalState } from "./main";


const router = createRouter({
  routeTree,
  context: { authentication: undefined! } });

declare module '@tanstack/react-router' {
  interface Register {
    router: typeof router;
  }
}


function App() {
  //const { globalState } = useGlobalState();
  //console.log(JSON.stringify(globalState.accessToken))
  
  try {
    useRefresh();
  }
  catch (err) {
    console.log(err)
  }
  

  // useEffect(() => {
  //   try {
  //   refreshToken
  // }
  // catch (error) {
  //   console.log("error:" + error)
  // }

  // },[]);

  const authentication = useAuth();
  return <RouterProvider router={router} context={{ authentication }} />;
}

export default App;
