import { Avatar, AvatarFallback, AvatarImage } from "@repo/ui";
import { useGlobalState } from "../../main";

const ProfilePage = () => {
  const { globalState } = useGlobalState();
  return (
    <div className=" flex flex-col sm:flex-row p-6">
      <Avatar className=" h-40 w-40">
        <AvatarImage src="../../public/DefaultAvatar.jpg" />
        <AvatarFallback>CN</AvatarFallback>
      </Avatar>
      <div className="flex flex-col mt-8 sm:ml-8 sm:mt-0 text-white">
        <p className=" text-4xl font-semibold">{globalState.userName}</p>
        <p className=" text-xl font-medium">{globalState.role}</p>

        <p className=" mt-5 max-w-[500px]">
          Pioneering the fusion of creativity and mathematics, I translated and
          expanded on Babbage's Analytical Engine, writing the first algorithm.
          Envisioning a future of computing beyond calculations, my work laid
          the foundation for modern technology.
        </p>
      </div>
    </div>
  );
};

export default ProfilePage;
