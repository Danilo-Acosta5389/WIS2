import { REFRESH, REGISTER, SIGN_IN, SIGN_OUT } from "../api/urls.ts";

export const useAuth = () => {
  interface Credentials {
    username: string;
    password: string;
  }

  // interface LoginResponse {
  //   token?: string;
  //   message?: string;
  // }

  // SignIn Function
  async function signIn(creds: Credentials): Promise<Response | undefined> {
    try {
      const response = await fetch(SIGN_IN, {
        method: "POST",
        headers: {
          "Content-Type": "application/json",
        },
        credentials: "include",
        body: JSON.stringify(creds),
      });

      //console.log("Response in signIn(): " + response);
      // const data = await response.json();
      // console.log("Data in signIn(): " + data);
      return response;
    } catch (err) {
      console.log("API ERROR: " + err);
      if (err instanceof TypeError && err.message.includes("Failed to fetch")) {
        console.error(
          "Fetch failed - check network, CORS policy, and server status."
        );
      }
    }
  }

  // SignOut Function
  const signOut = async () => {
    localStorage.removeItem("isAuthenticated");
    const response = await fetch(SIGN_OUT, {
      method: "GET",
      headers: {
        "Content-Type": "application/json",
      },
      credentials: "include",
    });

    return response;
  };

  // Check if authenticated
  const isLogged = () => localStorage.getItem("isAuthenticated") === "true";

  // get refresh token
  const refresh = async () => {
    const response = await fetch(REFRESH, {
      method: "POST",
      headers: {
        "Content-Type": "application/json",
      },
      credentials: "include",
    });
    //console.log(response);
    return response;
  };

  interface RegisterForm {
    email: string;
    userName: string;
    password: string;
  }

  const registerUser = async (
    params: RegisterForm
  ): Promise<RegisterForm | undefined> => {
    const response = await fetch(REGISTER, {
      method: "POST",
      headers: {
        "Content-Type": "application/json",
      },
      body: JSON.stringify(params),
    });

    const data = await response.json();
    return data;
  };

  return { signIn, signOut, isLogged, refresh, registerUser };
};

export type AuthContext = ReturnType<typeof useAuth>;
