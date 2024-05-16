import { useAuth } from "./hooks/useAuth";
import { RouterProvider, createRouter } from "@tanstack/react-router";
import { routeTree } from "./routeTree.gen";
import { REFRESH } from "./api/urls";
import { useGlobalState } from "./main";
import { JwtPayload, jwtDecode } from "jwt-decode";
import { useEffect, useRef } from "react";


interface CustomJwtPayload extends JwtPayload {
  'http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name': string;
  'http://schemas.microsoft.com/ws/2008/06/identity/claims/role': string;
}

const router = createRouter({
  routeTree,
  context: { authentication: undefined! } });

declare module '@tanstack/react-router' {
  interface Register {
    router: typeof router;
  }
}

const useRefreshToken = async () => {
  const response = await fetch(REFRESH, {
        method: "POST",
        headers: {
          "Content-Type": "application/json",
        },
        credentials: 'include'
      });

  return response
};

function App() {
  const { setGlobalState } = useGlobalState();

  async function RefreshToken() {
    const refresh = await useRefreshToken();

    if (refresh.status === 200) {
        const data = await refresh.json();
        const decoded = jwtDecode<CustomJwtPayload>(data.token);
        setGlobalState(prevState => ({
          ...prevState,
          isLoggedIn: true,
          accessToken: data.token,
          userName: decoded['http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name'],
          role: decoded['http://schemas.microsoft.com/ws/2008/06/identity/claims/role'],
        }));
      } else {
        console.error('Failed to refresh token');
      }
  }
  

  const intercept = useRef(false);
  
  useEffect(() => {

    if (intercept.current === false) {
      RefreshToken();
      intercept.current = true;
    }
  }, []);

  const authentication = useAuth();
  return <RouterProvider router={router} context={{ authentication }} />;
}

export default App;
