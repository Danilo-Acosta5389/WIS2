import { useAuth } from "./hooks/useAuth.ts";
import { RouterProvider, createRouter } from "@tanstack/react-router";
import { routeTree } from "./routeTree.gen.ts";
import { useGlobalState } from "./main.tsx";
import { JwtPayload, jwtDecode } from "jwt-decode";
import { useEffect, useRef } from "react";

const router = createRouter({
  routeTree,
  context: { authentication: undefined! },
});

declare module "@tanstack/react-router" {
  interface Register {
    router: typeof router;
  }
}

function App() {
  const { globalState, setGlobalState } = useGlobalState();
  const authentication = useAuth();
  const { refresh } = useAuth();
  const intercept = useRef(false);

  interface CustomJwtPayload extends JwtPayload {
    "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name": string;
    "http://schemas.microsoft.com/ws/2008/06/identity/claims/role": string;
    image: string;
  }

  useEffect(() => {
    if (intercept.current === false) {
      async function RefreshToken() {
        const response = await refresh();

        if (response.status === 200) {
          const data = await response.json();
          const decoded = jwtDecode<CustomJwtPayload>(data.token);
          setGlobalState((prevState) => ({
            ...prevState,
            isLoggedIn: true,
            accessToken: data.token,
            userName:
              decoded[
                "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name"
              ],
            role: decoded[
              "http://schemas.microsoft.com/ws/2008/06/identity/claims/role"
            ],
            image: decoded.image,
          }));
        }
      }
      RefreshToken();
      intercept.current = true;
      //console.log("intercept is: " + intercept.current);
    }
  }, []);

  useEffect(() => {}, [globalState]);

  //const authentication = useAuth();
  return <RouterProvider router={router} context={{ authentication }} />;
}

export default App;
