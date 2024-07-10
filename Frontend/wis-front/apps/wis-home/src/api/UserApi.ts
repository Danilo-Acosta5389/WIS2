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

  // Needs to send bearer token
  async function EditUser(formData: FormData) {
    try {
      console.log(formData);
      const response = await fetch(
        "https://localhost:7118/api/User/UpdateProfile",
        {
          method: "PUT",
          body: formData,
        }
      );
      console.log(response.status);
    } catch (err) {
      console.log(err);
    }
  }

  async function UpgradeUserRole(params: UpgradeRoleDetails, token: string) {
    try {
      const response = await fetch(
        "https://localhost:7118/api/User/upgradeRole",
        {
          headers: {
            "Content-Type": "application/json",
            Authorization: `Bearer ${token}`,
          },
          method: "PUT",
          body: JSON.stringify(params),
        }
      );
      console.log(response.status);
    } catch (err) {
      //Maybe RefreshToken and second try here

      console.log(err);
    }
  }

  return {
    GetUser,
    EditUser,
    UpgradeUserRole,
  };
};

export interface UpgradeRoleDetails {
  targetUser: string;
  newRole: string;
}

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
