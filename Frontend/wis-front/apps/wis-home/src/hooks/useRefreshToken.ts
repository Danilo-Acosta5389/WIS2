import { REFRESH } from "../api/urls.ts";

const useRefreshToken = async () => {
  const response = await fetch(REFRESH, {
    method: "POST",
    headers: {
      "Content-Type": "application/json",
    },
    credentials: "include",
  });

  return response;
};

export default useRefreshToken;
