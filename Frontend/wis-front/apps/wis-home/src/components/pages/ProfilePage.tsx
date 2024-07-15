"use client";

import {
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
  Select,
  SelectTrigger,
  SelectValue,
  SelectContent,
  SelectItem,
  Checkbox,
} from "@repo/ui";
import { useGlobalState } from "../../main.tsx";
import { Route } from "../../routes/user/$userName.tsx";
import {
  UserDetails,
  useUserApi,
  UpgradeRoleDetails,
} from "../../api/UserApi.ts";
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
    // image: z.instanceof(FileList),
  });

  const form = useForm<z.infer<typeof formSchema>>({
    resolver: zodResolver(formSchema),
    defaultValues: {
      bio: userDetails.bio,
    },
  });
  //console.log(userDetails.bio);
  //const fileRef = form.register("image");

  async function onSubmit(values: z.infer<typeof formSchema>) {
    setNewValues({ ...newValues, bio: values.bio });
    const formData = new FormData();
    formData.append("userName", globalState.userName);
    formData.append("bio", values.bio);
    formData.append("imageFile", ""); //change here eventually..
    await EditUser(formData);
    //console.log(JSON.stringify(edit));
    setEdit(false);
  }

  // const showPreview = (e: any) => {
  //   if (e.target.files && e.target.files[0]) {
  //     let imageFile = e.target.files[0];
  //     const reader = new FileReader();
  //     reader.onload = (x: any) => {
  //       setNewValues({
  //         ...newValues,
  //         imageSrc: x.target.result,
  //         imageFile,
  //       });
  //     };
  //     reader.readAsDataURL(imageFile);
  //   }
  // };

  useEffect(() => {
    console.log(edit);
  }, [edit]);
  return (
    <>
      {edit ? (
        <Form {...form}>
          <form
            onSubmit={form.handleSubmit(onSubmit)}
            className="bg-black text-white flex flex-col max-w-[48rem]"
          >
            <div className=" flex flex-col sm:flex-row p-6">
              {/* <FormField
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
              /> */}
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
        <div className=" flex flex-col sm:flex-col p-6">
          <div className="flex flex-col mt-8 sm:ml-8 sm:mt-0 text-white">
            <div className=" flex flex-row">
              <p className=" text-4xl font-semibold">{userDetails.userName}</p>
              {globalState.isLoggedIn && (
                <UserActions
                  targetUser={userDetails.userName}
                  jwt={globalState.accessToken}
                  role={globalState.role}
                  user={globalState.userName}
                  setEdit={setEdit}
                />
              )}
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
          <div className=" flex flex-col w-fit">
            {/* <Avatar className=" h-40 w-40">
              <AvatarImage
                className=" h-fit w-fit"
                src={
                  userDetails.imageSrc === newValues.imageSrc
                    ? newValues.imageSrc
                    : userDetails.imageSrc
                }
              />
              <AvatarFallback className=" text-7xl font-semibold">
                {userDetails.userName.charAt(0)}
              </AvatarFallback>
            </Avatar> */}
            {/* {globalState.isLoggedIn &&
              globalState.userName === userDetails.userName && (
                <Button
                  className=" w-fit mt-5 ml-5 self-center"
                  onClick={() => {
                    setEdit(!edit);
                  }}
                >
                  Edit profile
                </Button>
              )} */}
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
/*

We need:

UserAction should have info about the user and the targeted user
it needs: 
Logged in users JWT,
targeted users userName,
targeted users new Role



*/

const UserActions = (props: any) => {
  const [openDialog, setOpenDialog] = useState(false);
  const [option, setOption] = useState<"UPGRADE" | "REPORT" | "BLOCK" | "">("");

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
          {props.role !== "User" && props.user !== props.targetUser && (
            <>
              <DropdownMenuItem className="cursor-pointer">
                <AlertDialogTrigger
                  onClick={() => setOption("UPGRADE")}
                  className=" text-white w-full text-start"
                >
                  Upgrade
                </AlertDialogTrigger>
              </DropdownMenuItem>
              <DropdownMenuSeparator />
            </>
          )}
          {props.targetUser === props.user ? (
            <DropdownMenuItem
              onClick={() => props.setEdit(true)}
              className="cursor-pointer text-white w-full text-start"
            >
              Edit profile
            </DropdownMenuItem>
          ) : (
            <DropdownMenuItem className="cursor-pointer">
              <AlertDialogTrigger
                onClick={() => setOption("REPORT")}
                className=" text-white w-full text-start"
              >
                Report
              </AlertDialogTrigger>
            </DropdownMenuItem>
          )}
          {props.targetUser !== props.user &&
            (props.role === "Admin" || props.role === "Super") && (
              <DropdownMenuItem className="cursor-pointer bg-red-600 focus:bg-red-700 focus:text-white">
                <AlertDialogTrigger
                  onClick={() => setOption("BLOCK")}
                  className=" text-white w-full text-start"
                >
                  Block
                </AlertDialogTrigger>
              </DropdownMenuItem>
            )}
        </DropdownMenuContent>
      </DropdownMenu>

      {option === "BLOCK" && <Block />}
      {option === "REPORT" && <Report />}
      {option === "UPGRADE" && (
        <Upgrade
          targetUser={props.targetUser}
          jwt={props.jwt}
          role={props.role}
        />
      )}
    </AlertDialog>
  );
};

//#######    UPGRADE USER
function Upgrade(props: any) {
  const { UpgradeUserRole } = useUserApi();
  const [btnDisabled, setBtnDisabled] = useState(true);
  // const [roleOption, setRoleOptions] = useState<
  //   "Creator" | "Admin" | "Super" | ""
  // >("");

  const details: UpgradeRoleDetails = {
    targetUser: props.targetUser,
    newRole: "",
  };

  const formSchema = z.object({
    role: z.string({
      required_error: "Please select a role.",
    }),
  });

  const form = useForm<z.infer<typeof formSchema>>({
    resolver: zodResolver(formSchema),
    defaultValues: { role: props.role },
  });

  function handleUpgrade(newDetails: UpgradeRoleDetails) {
    console.log("UPGRADE USER " + JSON.stringify(newDetails));
    UpgradeUserRole(details, props.jwt);
    form.reset;
    setBtnDisabled(true);
  }

  function onSubmit(data: z.infer<typeof formSchema>) {
    console.log(data);
    details.newRole = data.role;
    handleUpgrade(details);
  }

  return (
    <AlertDialogContent>
      {props.role === "Creator" ? (
        <Form {...form}>
          <form
            onSubmit={form.handleSubmit(onSubmit)}
            className="w-2/3 space-y-6"
          >
            <AlertDialogHeader>
              <AlertDialogTitle>Change users role</AlertDialogTitle>
              <AlertDialogDescription>
                Change users role to Creator?
              </AlertDialogDescription>
              <FormField
                control={form.control}
                name="role"
                render={() => (
                  <FormItem className="flex flex-row mt-6 ml-5 sm:ml-0 sm:mr-[10rem]">
                    <FormControl className="">
                      <Checkbox
                        onCheckedChange={() => setBtnDisabled(false)}
                        className=" bg-slate-200 mt-2 size-5 mr-2"
                      />
                    </FormControl>
                    <FormLabel className="text-black flex-wrap">Yes</FormLabel>
                  </FormItem>
                )}
              />
            </AlertDialogHeader>
            <AlertDialogFooter>
              <AlertDialogCancel onClick={() => setBtnDisabled(true)}>
                Cancel
              </AlertDialogCancel>
              <AlertDialogAction disabled={btnDisabled} type="submit">
                Continue
              </AlertDialogAction>
            </AlertDialogFooter>
          </form>
        </Form>
      ) : (
        <Form {...form}>
          <form
            onSubmit={form.handleSubmit(onSubmit)}
            className="w-2/3 space-y-6"
          >
            <AlertDialogHeader>
              <AlertDialogTitle>Change users role</AlertDialogTitle>
              <AlertDialogDescription>Choose a role</AlertDialogDescription>
              <FormField
                control={form.control}
                name="role"
                render={({ field }) => (
                  <FormItem>
                    <Select
                      onValueChange={field.onChange}
                      onOpenChange={() => setBtnDisabled(false)}
                    >
                      <FormControl>
                        <SelectTrigger className="w-[180px]">
                          <SelectValue placeholder="Role" />
                        </SelectTrigger>
                      </FormControl>
                      <SelectContent>
                        {props.role === "Super" && (
                          <>
                            <SelectItem value="User">User</SelectItem>
                            <SelectItem value="Creator">Creator</SelectItem>
                            <SelectItem value="Admin">Admin</SelectItem>
                            <SelectItem value="Super">Super</SelectItem>
                          </>
                        )}
                        {props.role === "Admin" && (
                          <>
                            <SelectItem value="Creator">Creator</SelectItem>
                            <SelectItem value="Admin">Admin</SelectItem>
                          </>
                        )}
                      </SelectContent>
                    </Select>
                    <FormMessage />
                  </FormItem>
                )}
              />
            </AlertDialogHeader>
            <AlertDialogFooter>
              <AlertDialogCancel onClick={() => setBtnDisabled(true)}>
                Cancel
              </AlertDialogCancel>
              <AlertDialogAction disabled={btnDisabled} type="submit">
                Continue
              </AlertDialogAction>
            </AlertDialogFooter>
          </form>
        </Form>
      )}
    </AlertDialogContent>
  );
}

//REPORT USER
function Report() {
  function handleReport() {
    console.log("REPORT USER");
  }
  return (
    <AlertDialogContent>
      <AlertDialogHeader>
        <AlertDialogTitle>
          Are you absolutely sure about reporting this user?
        </AlertDialogTitle>
        <AlertDialogDescription>
          This action cannot be undone. This will permanently delete your
          account and remove your data from our servers.
        </AlertDialogDescription>
      </AlertDialogHeader>
      <AlertDialogFooter>
        <AlertDialogCancel>Cancel</AlertDialogCancel>
        <AlertDialogAction onClick={handleReport}>Continue</AlertDialogAction>
      </AlertDialogFooter>
    </AlertDialogContent>
  );
}

//BLOCK USER
function Block() {
  function handleBlock() {
    console.log("BLOCK USER");
  }
  return (
    <AlertDialogContent>
      <AlertDialogHeader>
        <AlertDialogTitle>
          Are you absolutely sure about blocking this user?
        </AlertDialogTitle>
        <AlertDialogDescription>
          This action cannot be undone. This will permanently delete your
          account and remove your data from our servers.
        </AlertDialogDescription>
      </AlertDialogHeader>
      <AlertDialogFooter>
        <AlertDialogCancel>Cancel</AlertDialogCancel>
        <AlertDialogAction onClick={handleBlock}>Continue</AlertDialogAction>
      </AlertDialogFooter>
    </AlertDialogContent>
  );
}
