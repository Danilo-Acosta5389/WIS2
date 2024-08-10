import {
  REFRESH,
  REGISTER,
  SIGN_IN,
  SIGN_OUT,
  VERIFY_EMAIL,
} from "../api/urls.ts";

export const useAuth = () => {
  interface Credentials {
    username: string;
    password: string;
  }

  interface LoginResponse {
    token?: string;
    message?: string;
  }

  // SignIn Function
  async function signIn(
    creds: Credentials
  ): Promise<LoginResponse | undefined> {
    try {
      const response = await fetch(SIGN_IN, {
        method: "POST",
        headers: {
          "Content-Type": "application/json",
        },
        credentials: "include",
        body: JSON.stringify(creds),
      });

      const data = await response.json();

      return data;
    } catch (err) {
      console.log("API ERROR: " + err);
      if (err instanceof TypeError && err.message.includes("Failed to fetch")) {
        console.error(
          "Fetch failed - check network, CORS policy, and server status."
        );
      }
    }
  }

  //Verify email
  interface VerifyResponse {
    message: string;
  }
  interface VerifyRequest {
    email: string;
    code: string;
  }
  async function verifyEmail(
    params: VerifyRequest
  ): Promise<VerifyResponse | undefined> {
    try {
      const response = await fetch(VERIFY_EMAIL, {
        method: "POST",
        headers: {
          "Content-Type": "application/json",
        },
        body: JSON.stringify(params),
      });

      const data = await response.json();
      return data;
    } catch (err) {
      console.log(err);
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

  // Check if authenticated - NOT IN USE
  // const isLogged = () => localStorage.getItem("isAuthenticated") === "true";

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

  interface RegisterResponse {
    message: string;
  }

  const registerUser = async (
    params: RegisterForm
  ): Promise<RegisterResponse | undefined> => {
    const response = await fetch(REGISTER, {
      method: "POST",
      headers: {
        "Content-Type": "application/json",
      },
      body: JSON.stringify(params),
    });
    console.log(response);

    const data = await response.json();

    return data;
  };

  return { signIn, signOut, refresh, registerUser, verifyEmail };
};

export type AuthContext = ReturnType<typeof useAuth>;
