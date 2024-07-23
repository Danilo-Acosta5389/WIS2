import { REFRESH, REGISTER, SIGN_IN, SIGN_OUT } from "../api/urls.ts";

export const useAuth = () => {
  interface Credentials {
    username: string;
    password: string;
  }

  interface Response {
    token?: string;
    message?: string;
  }

  // SignIn Function
  const signIn = async (creds: Credentials): Promise<Response | undefined> => {
    //localStorage.setItem("isAuthenticated", "true");
    try {
      const response = await fetch(SIGN_IN, {
        method: "POST",
        headers: {
          "Content-Type": "application/json",
        },
        credentials: "include",
        body: JSON.stringify(creds),
      });

      //console.log(response);
      //console.log("api response: " + response.status);
      const data: Response | undefined = await response.json();

      return data;

      // if (response.status === 200) {
      //   //console.log(loginAttempt)
      //   data = await response.json();
      //   //console.log(data);
      //   //setJwt(data.token);
      //   //console.log("user logged in");

      //   return data;
      // } else {
      //   data = await response.json();
      //   //console.log(data);
      //   //console.log("Failed to log in, response status: " + data.message);
      //   // if (data.message === "BLOCKED") {
      //   //   return data.message;
      //   // }
      // }
    } catch (err) {
      console.log("API ERROR: " + err);
    }
  };

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
