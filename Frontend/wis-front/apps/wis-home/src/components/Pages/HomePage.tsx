import { useEffect, useState } from "react";
import { useGlobalState } from "../../main.tsx";

const HomePage = () => {
  const { globalState } = useGlobalState();
  const [signedIn, setSignedIn] = useState(false);

  useEffect(() => {
    setSignedIn(globalState.isLoggedIn);
  }, [globalState]);

  return (
    <div className=" w-[100vw] h-[29vh] flex flex-col justify-center items-center">
      {signedIn ? (
        <span className=" m-4 text-4xl font-extrabold leading-none tracking-tight md:text-5xl lg:text-6xl text-white">
          Welcome
        </span>
      ) : (
        <span className=" mt-4 text-4xl font-extrabold leading-none tracking-tight md:text-5xl lg:text-6xl text-white">
          Please sign in
        </span>
      )}
    </div>
  );
};

export default HomePage;
