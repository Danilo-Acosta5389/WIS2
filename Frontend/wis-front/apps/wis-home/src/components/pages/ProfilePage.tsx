import { Avatar, AvatarFallback, AvatarImage } from "@repo/ui";
import { useGlobalState } from "../../main";
import { Route } from "../../routes/user/$userName";
import { UserDetails } from "../../api/UserApi";

const ProfilePage = () => {
  const { globalState } = useGlobalState();
  const userDetails: UserDetails = Route.useLoaderData();
  return (
    <div className=" flex flex-col sm:flex-row p-6">
      <Avatar className=" h-40 w-40">
        <AvatarImage
          className=" h-fit w-fit"
          src={"../../../public/" + userDetails.image}
        />
        <AvatarFallback className=" text-7xl font-semibold">
          {userDetails.userName.charAt(0)}
        </AvatarFallback>
      </Avatar>
      <div className="flex flex-col mt-8 sm:ml-8 sm:mt-0 text-white">
        <p className=" text-4xl font-semibold">{userDetails.userName}</p>
        <p className=" text-xl font-medium">{globalState.role}</p>

        <p className=" mt-5 max-w-[500px]">{userDetails.bio}</p>
      </div>
    </div>
  );
};

export default ProfilePage;
