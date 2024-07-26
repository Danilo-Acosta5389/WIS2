import {
  BLOCK_USER,
  EDIT_USER_PROFILE,
  getUserProfile,
  UNBLOCK_USER,
  UPGRADE_USER_ROLE,
} from "./urls.ts";

export const useUserApi = () => {
  async function GetUser(userName: string): Promise<UserDetails[]> {
    try {
      const response = await fetch(getUserProfile(userName));
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
      //console.log(formData);
      const response = await fetch(EDIT_USER_PROFILE, {
        method: "PUT",
        body: formData,
      });
      console.log(response.status);
    } catch (err) {
      console.log(err);
    }
  }

  async function UpgradeUserRole(params: UpgradeRoleDetails, token: string) {
    try {
      const response = await fetch(UPGRADE_USER_ROLE, {
        headers: {
          "Content-Type": "application/json",
          Authorization: `Bearer ${token}`,
        },
        method: "PUT",
        body: JSON.stringify(params),
      });
      console.log(response.status);
    } catch (err) {
      //Maybe RefreshToken and second try here

      console.log(err);
    }
  }

  async function blockUser({
    userName,
    token,
  }: {
    userName: string;
    token: string;
  }) {
    try {
      await fetch(BLOCK_USER, {
        headers: {
          "Content-Type": "application/json",
          Authorization: `Bearer ${token}`,
        },
        method: "PUT",
        body: JSON.stringify(userName),
      });
    } catch (err) {
      console.log(err);
    }
  }

  async function unBlockUser({
    userName,
    token,
  }: {
    userName: string;
    token: string;
  }) {
    try {
      await fetch(UNBLOCK_USER, {
        headers: {
          "Content-Type": "application/json",
          Authorization: `Bearer ${token}`,
        },
        method: "PUT",
        body: JSON.stringify(userName),
      });
    } catch (err) {
      console.log(err);
    }
  }

  return {
    GetUser,
    EditUser,
    UpgradeUserRole,
    blockUser,
    unBlockUser,
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
  isBlocked: boolean;
}

export interface UpdatedDetails {
  userName: string;
  bio: string;
  imageFile: File | undefined;
}
