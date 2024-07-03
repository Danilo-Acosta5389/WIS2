export const useUserApi = () => {
  async function GetUser(userName: string | undefined): Promise<UserDetails[]> {
    try {
      const response = await fetch(
        `https://localhost:7118/api/User/${userName}`
      );
      const data: UserDetails[] = await response.json();
      //console.log(data);
      return data;
    } catch (err) {
      console.log(err);
      const data: UserDetails[] = [];
      return data;
    }
  }

  async function EditUser(formData: FormData) {
    try {
      console.log(formData);
      const response = await fetch("https://localhost:7118/api/User", {
        method: "PUT",
        body: formData,
      });
      console.log(response.status);
    } catch (err) {
      console.log(err);
    }
  }

  return {
    GetUser,
    EditUser,
  };
};

export interface UserDetails {
  userName: string;
  bio: string;
  imageName: string;
  imageSrc: string;
}

export interface UpdatedDetails {
  userName: string;
  bio: string;
  imageFile: File | undefined;
}
