export const useUserApi = () => {
  async function GetUser(userName: string | undefined): Promise<UserDetails[]> {
    try {
      const response = await fetch(
        `https://localhost:7118/api/User/${userName}`
      );
      const data: UserDetails[] = await response.json();
      console.log(data);
      return data;
    } catch (err) {
      console.log(err);
      const data: UserDetails[] = [];
      return data;
    }
  }

  return {
    GetUser,
  };
};

export interface UserDetails {
  userName: string;
  bio: string;
  image: string;
}
