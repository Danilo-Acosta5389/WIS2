"use client";

import {
  Avatar,
  AvatarFallback,
  AvatarImage,
  Button,
  Form,
  FormControl,
  FormField,
  FormItem,
  FormMessage,
  Textarea,
  useForm,
  z,
  zodResolver,
  lucide,
  FormLabel,
  Input,
  DropdownMenu,
  DropdownMenuTrigger,
  DropdownMenuContent,
  DropdownMenuItem,
  DropdownMenuSeparator,
  AlertDialog,
  AlertDialogTrigger,
  AlertDialogContent,
  AlertDialogHeader,
  AlertDialogTitle,
  AlertDialogDescription,
  AlertDialogFooter,
  AlertDialogCancel,
  AlertDialogAction,
} from "@repo/ui";
import { useGlobalState } from "../../main";
import { Route } from "../../routes/user/$userName";
import { UserDetails, useUserApi } from "../../api/UserApi";
import { useEffect, useState } from "react";

const ProfilePage = () => {
  const { globalState } = useGlobalState();
  const userDetails: UserDetails = Route.useLoaderData();
  //console.log("userDetails: " + JSON.stringify(userDetails));
  const initialState = {
    userName: userDetails.userName,
    bio: userDetails.bio,
    imageSrc: globalState.image,
    imageFile: undefined,
  };
  //console.log("initialState" + JSON.stringify(initialState));

  //const [setImageSrc] = useState(globalState.image);
  const [edit, setEdit] = useState(false);
  const [newValues, setNewValues] = useState(initialState);
  const { EditUser } = useUserApi();

  //console.log("values" + JSON.stringify(newValues));

  const formSchema = z.object({
    bio: z.string().max(250, "Max 250 characters"),
    image: z.instanceof(FileList),
  });

  const form = useForm<z.infer<typeof formSchema>>({
    resolver: zodResolver(formSchema),
    defaultValues: {
      bio: userDetails.bio,
    },
  });
  //console.log(userDetails.bio);
  const fileRef = form.register("image");

  async function onSubmit(values: z.infer<typeof formSchema>) {
    setNewValues({ ...newValues, bio: values.bio });
    const formData = new FormData();
    formData.append("userName", globalState.userName);
    formData.append("bio", values.bio);
    formData.append("imageFile", values.image[0]);
    await EditUser(formData);
    //console.log(JSON.stringify(edit));
    setEdit(false);
  }

  const showPreview = (e: any) => {
    if (e.target.files && e.target.files[0]) {
      let imageFile = e.target.files[0];
      const reader = new FileReader();
      reader.onload = (x: any) => {
        setNewValues({
          ...newValues,
          imageSrc: x.target.result,
          imageFile,
        });
      };
      reader.readAsDataURL(imageFile);
    }
  };

  useEffect(() => {}, [edit]);
  return (
    <>
      {edit ? (
        <Form {...form}>
          <form
            onSubmit={form.handleSubmit(onSubmit)}
            className="bg-black text-white flex flex-col max-w-[48rem]"
          >
            <div className=" flex flex-col sm:flex-row p-6">
              <FormField
                control={form.control}
                name="image"
                render={() => {
                  return (
                    <FormItem>
                      <div className=" h-fit w-fit flex flex-col">
                        <Avatar className=" h-40 w-40">
                          <AvatarImage
                            className=" h-fit w-fit"
                            src={newValues.imageSrc}
                          />
                          <AvatarFallback className=" text-7xl font-semibold text-black">
                            {userDetails.userName.charAt(0)}
                          </AvatarFallback>
                        </Avatar>
                        <lucide.ImagePlus
                          className=" z-10 absolute self-end top-[14rem] left-[9rem] bg-black rounded-md p-[2px]"
                          color="#FFFFFF"
                          size={28}
                        />
                        <FormControl className="absolute z-20  cursor-pointer">
                          <Input
                            className=" h-40 w-44 opacity-0"
                            {...fileRef}
                            type="file"
                            accept="image/png, image/jpeg"
                            onChange={showPreview}
                          />
                        </FormControl>
                      </div>
                    </FormItem>
                  );
                }}
              />
              <div className="flex flex-col mt-8 sm:ml-8 sm:mt-0 text-white">
                <p className=" text-4xl font-semibold">
                  {userDetails.userName}
                </p>
                <p className=" text-xl font-medium">{globalState.role}</p>
                <FormField
                  control={form.control}
                  name="bio"
                  render={({ field }) => {
                    //console.log(userDetails.bio);
                    return (
                      <FormItem className="flex flex-col">
                        <FormLabel className="text-base italic mx-2 text-slate-400">
                          Bio
                        </FormLabel>
                        <FormControl className="">
                          <Textarea
                            {...field}
                            placeholder="Write a bio!"
                            rows={6}
                            cols={50}
                            className=" bg-slate-600 text-white text-base max-w-[40rem] placeholder:text-slate-400 "
                          />
                        </FormControl>
                        <FormMessage className=" text-lg sm:mt-1 sm:ml-5 justify-self-end" />
                      </FormItem>
                    );
                  }}
                />

                <div className=" flex flex-row justify-between">
                  <Button
                    type="submit"
                    className=" bg-slate-200 max-w-20 text-black hover:bg-slate-500 hover:text-slate-200 mt-4 sm:z-10"
                  >
                    Submit
                  </Button>
                  <div
                    onClick={() => {
                      setEdit(false);
                    }}
                    className=" flex flex-row text-base hover:text-slate-400 cursor-pointer mr-5 mt-4 border-2 border-white hover:border-slate-400 p-2 rounded"
                  >
                    <lucide.X size={20} />
                    <span className=" -m-[2px] mx-[1px]">Cancel</span>
                  </div>
                </div>
              </div>
            </div>
          </form>
        </Form>
      ) : (
        <div className=" flex flex-col sm:flex-row p-6">
          <div className=" flex flex-col w-fit">
            <Avatar className=" h-40 w-40">
              <AvatarImage
                className=" h-fit w-fit"
                src={
                  userDetails.imageSrc === newValues.imageSrc
                    ? userDetails.imageSrc
                    : newValues.imageSrc
                }
              />
              <AvatarFallback className=" text-7xl font-semibold">
                {userDetails.userName.charAt(0)}
              </AvatarFallback>
            </Avatar>
            {globalState.isLoggedIn &&
              globalState.userName === userDetails.userName && (
                <Button
                  className=" w-fit mt-5 self-center"
                  onClick={() => {
                    setEdit(!edit);
                  }}
                >
                  Edit profile
                </Button>
              )}
          </div>
          <div className="flex flex-col mt-8 sm:ml-8 sm:mt-0 text-white">
            <div className=" flex flex-row">
              <p className=" text-4xl font-semibold">{userDetails.userName}</p>
              {/* <div className=" m-1 relative bottom-1 pt-1 pb-1 rounded hover:bg-slate-700 cursor-pointer max-w-fit"></div> */}
              <UserActions />
            </div>
            {globalState.isLoggedIn &&
              globalState.userName === userDetails.userName && (
                <p className=" text-xl font-medium">{globalState.role}</p>
              )}

            <p className=" mt-5 max-w-[500px]">
              {userDetails.bio === newValues.bio
                ? userDetails.bio
                : newValues.bio}
            </p>
          </div>
        </div>
      )}
      {/* <button
        onClick={() => {
          setOpenDialog(!openDialog);
        }}
        className=" z-60 text-white"
      >
        Open
      </button> */}
    </>
  );
};

export default ProfilePage;

const UserActions = () => {
  const [openDialog, setOpenDialog] = useState(false);
  return (
    <AlertDialog>
      <DropdownMenu open={openDialog}>
        {openDialog && (
          <div
            onClick={() => {
              setOpenDialog(!openDialog);
            }}
            className=" bg-black fixed top-0 bottom-0 left-0 right-0 z-50 pointer-events-auto opacity-55"
          ></div>
        )}
        <DropdownMenuTrigger
          onClick={() => {
            setOpenDialog(!openDialog);
          }}
          className=" hover:bg-slate-700 rounded relative bottom-1 mx-1 h-8"
        >
          <lucide.EllipsisVertical
            className="p-0 m-0"
            size={20}
            color="lightgray"
          />
        </DropdownMenuTrigger>
        <DropdownMenuContent className=" bg-black text-white mr-3 ">
          {/* <DropdownMenuLabel className=" font-bold">
                    Interactions
                  </DropdownMenuLabel>
                  <DropdownMenuSeparator /> */}
          <DropdownMenuItem className="cursor-pointer">
            Upgrade
          </DropdownMenuItem>
          <DropdownMenuSeparator />
          <DropdownMenuItem className="cursor-pointer">Report</DropdownMenuItem>
          <DropdownMenuItem className="cursor-pointer bg-red-600 focus:bg-red-700 focus:text-white">
            {/* <BlockUser
                      name={"Block"}
                      desc="This action cannot be undone. This will permanently delete your
              account and remove your data from our servers."
                    /> */}
            <AlertDialogTrigger className=" text-white w-full text-start">
              Block
            </AlertDialogTrigger>
          </DropdownMenuItem>
        </DropdownMenuContent>
      </DropdownMenu>
      <AlertDialogContent>
        <AlertDialogHeader>
          <AlertDialogTitle>Are you absolutely sure?</AlertDialogTitle>
          <AlertDialogDescription>
            This action cannot be undone. This will permanently delete your
            account and remove your data from our servers.
          </AlertDialogDescription>
        </AlertDialogHeader>
        <AlertDialogFooter>
          <AlertDialogCancel>Cancel</AlertDialogCancel>
          <AlertDialogAction>Continue</AlertDialogAction>
        </AlertDialogFooter>
      </AlertDialogContent>
    </AlertDialog>
  );
};
