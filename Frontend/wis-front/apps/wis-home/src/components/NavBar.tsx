import { Fragment, useEffect, useState } from "react";
import {
  ChevronDownIcon,
  Dialog,
  Disclosure,
  Popover,
  ScrollArea,
  ScrollBar,
  Transition,
  lucide,
} from "@repo/ui";
import { Bars3Icon, XMarkIcon } from "@repo/ui";
import {
  Button,
  DropdownMenu,
  DropdownMenuContent,
  DropdownMenuItem,
  DropdownMenuLabel,
  DropdownMenuSeparator,
  DropdownMenuTrigger,
} from "@repo/ui";
import { Link } from "@tanstack/react-router";
import { useGlobalState } from "../main.tsx";
import { useAuth } from "../hooks/useAuth.ts";
import { Route } from "../routes/__root.tsx";
import SignUpForm from "./authForms/SignUpForm.tsx";
import { AddTopic } from "./forumComponents/addTopic.tsx";
import { useForumApi } from "../api/ForumApi.ts";

const NavBar = () => {
  const { globalState, setGlobalState } = useGlobalState();
  const [mobileMenuOpen, setMobileMenuOpen] = useState(false);
  const [signedIn, setSignedIn] = useState(false);
  const { signOut } = useAuth();
  const [showPopover, setShowPopover] = useState<boolean>();
  const topics = Route.useLoaderData();
  const [topicsArr, setTopicsArr] = useState(topics);
  const { getTopics } = useForumApi();
  const [trigger, setTrigger] = useState(false);

  const handleSignOut = async () => {
    const response = await signOut();
    if (response.status === 200) {
      setGlobalState((prevState) => ({
        ...prevState,
        isLoggedIn: false,
        accessToken: "",
        userName: "",
        role: "",
        image: "",
      }));
      setSignedIn(globalState.isLoggedIn);
    }
  };

  useEffect(() => {
    setSignedIn(globalState.isLoggedIn);
  }, [globalState]);

  useEffect(() => {
    // Define an async function inside the useEffect
    async function fetchTopicsAndUpdateState() {
      try {
        const newTopicsList = await getTopics(); // Wait for the promise to resolve
        setTopicsArr(newTopicsList); // Then update the state with the fetched topics
      } catch (error) {
        console.error("Failed to fetch topics:", error);
        // Handle error (e.g., show an error message)
      }
    }

    fetchTopicsAndUpdateState(); // Call the async function
  }, [trigger]);

  return (
    <header className=" bg-white ">
      {showPopover && (
        <div
          onClick={() => setShowPopover(!showPopover)}
          className=" bg-black fixed top-0 bottom-0 left-0 right-0 z-10 pointer-events-auto opacity-55"
        ></div>
      )}
      <nav
        onClick={() => setShowPopover(false)}
        className="mx-auto flex max-w-full items-center justify-between p-6 lg:px-8 text-lg font-semibold"
        aria-label="Global"
      >
        <div className="flex lg:flex-1">
          <a href="#" className="-m-1.5 p-1.5">
            <span className="sr-only">The website name</span>
          </a>
        </div>
        <div className="flex lg:hidden">
          {!signedIn && <SignUpForm />}
          <button
            type="button"
            className="-m-2.5 inline-flex items-center justify-center rounded-md p-2.5 text-gray-700"
            onClick={() => setMobileMenuOpen(true)}
          >
            <span className="sr-only">Open main menu</span>
            <Bars3Icon className="h-6 w-6" aria-hidden="true" />
          </button>
        </div>
        <Popover.Group className="hidden lg:flex lg:gap-x-12">
          <Link to="/" className=" leading-6 text-gray-900 p-1">
            Home
          </Link>
          <Popover className="relative">
            <Popover.Button
              onClick={() => setShowPopover(!showPopover)}
              className="flex items-center gap-x-1 leading-6 text-gray-900 p-1"
            >
              Forum
              <ChevronDownIcon
                className="h-5 w-5 flex-none text-gray-400"
                aria-hidden="true"
              />
            </Popover.Button>

            <Transition
              show={showPopover}
              as={Fragment}
              enter="transition ease-out duration-200"
              enterFrom="opacity-0 translate-y-1"
              enterTo="opacity-100 translate-y-0"
              leave="transition ease-in duration-150"
              leaveFrom="opacity-100 translate-y-0"
              leaveTo="opacity-0 translate-y-1"
            >
              <Popover.Panel className="absolute -left-44 top-full z-10 mt-10 w-screen max-w-md overflow-hidden rounded-xl bg-white shadow-lg ring-1 ring-gray-900/5">
                <div className="p-4">
                  <div className=" flex justify-between p-2">
                    <span className=" font-semibold">Topics</span>
                    {/* <Link
                      to={"/forum/$topic"}
                      params={{
                        topic: "General",
                      }}
                      className=" font-medium text-blue-700"
                    >
                      see all &rarr;
                    </Link> */}
                  </div>
                  <ScrollArea className=" flex flex-col max-h-96">
                    {topicsArr.map((item) => (
                      <div
                        key={item.id}
                        className="group relative flex items-center gap-x-6 rounded-lg p-4 text-sm leading-6 hover:bg-gray-50 cursor-pointer"
                      >
                        <Link
                          to={"/forum/$topic"}
                          params={{ topic: item.title }}
                          className="flex-auto"
                        >
                          <div className="block font-semibold text-gray-900">
                            {item.title}
                            <span className="absolute inset-0" />
                          </div>
                          <p className="mt-1 text-gray-600">
                            {item.description}
                          </p>
                        </Link>
                      </div>
                    ))}
                    <ScrollBar orientation="vertical" />
                  </ScrollArea>
                </div>
              </Popover.Panel>
            </Transition>
          </Popover>
          <Link to={"/"} className="leading-6 text-gray-900 p-1">
            Blog
          </Link>
        </Popover.Group>
        {signedIn ? (
          <div className="hidden lg:flex lg:flex-1 lg:justify-end">
            <DropdownMenu>
              <DropdownMenuTrigger>
                <lucide.User />
                {/* <Avatar>
                  <AvatarImage src={globalState.image} />
                  <AvatarFallback className=" text-xl font-semibold">
                    {globalState.userName.charAt(0)}
                  </AvatarFallback>
                </Avatar> */}
              </DropdownMenuTrigger>
              <DropdownMenuContent className=" mr-3 ">
                <DropdownMenuLabel>{globalState.userName}</DropdownMenuLabel>
                <DropdownMenuSeparator />
                <DropdownMenuItem className="cursor-pointer">
                  <Link
                    to={"/user/$userName"}
                    params={{
                      userName: globalState.userName,
                    }}
                  >
                    Profile
                  </Link>
                </DropdownMenuItem>
                {/* <DropdownMenuItem className="cursor-pointer">
                  Messages
                </DropdownMenuItem> */}
                <DropdownMenuItem className="cursor-pointer">
                  Settings
                </DropdownMenuItem>
                <DropdownMenuSeparator />
                <DropdownMenuItem
                  className="text-sm font-semibold leading-6 text-black bg-white hover:bg-gray-200 cursor-pointer"
                  onClick={() => {
                    handleSignOut();
                  }}
                >
                  Sign out
                </DropdownMenuItem>
              </DropdownMenuContent>
            </DropdownMenu>
          </div>
        ) : (
          <div className="hidden lg:flex lg:flex-1 lg:justify-end">
            <Button className=" text-base font-semibold leading-6 text-black bg-white mx-4 hover:bg-gray-200">
              <Link to="/Login">
                Log in <span aria-hidden="true"></span>
              </Link>
            </Button>
            <SignUpForm />
          </div>
        )}
      </nav>
      <Dialog
        as="div"
        className="lg:hidden"
        open={mobileMenuOpen}
        onClose={setMobileMenuOpen}
      >
        <div className="fixed inset-0 z-10" />
        <Dialog.Panel className="fixed inset-y-0 right-0 z-10 w-full overflow-y-auto bg-white px-6 py-6 sm:max-w-sm sm:ring-1 sm:ring-gray-900/10">
          <div className="flex items-center justify-between">
            <div className="-m-1.5 p-1.5">
              {signedIn && (
                <div className=" flex">
                  {/* <Avatar className="mt-1">
                    <AvatarImage src={globalState.image} />
                    <AvatarFallback className=" text-xl font-semibold">
                      {globalState.userName.charAt(0)}
                    </AvatarFallback>
                  </Avatar> */}
                  <div className="flex flex-col mt-0">
                    <p className=" text-lg text-black font-semibold">
                      {globalState.userName}
                    </p>
                    <p className=" text-base font-medium">{globalState.role}</p>
                  </div>
                </div>
              )}
            </div>
            <div className="flex">
              {!signedIn && <SignUpForm />}
              <button
                type="button"
                className="-m-2.5 rounded-md p-2.5 text-gray-700"
                onClick={() => setMobileMenuOpen(false)}
              >
                <span className="sr-only">Close menu</span>
                <XMarkIcon className="h-6 w-6" aria-hidden="true" />
              </button>
            </div>
          </div>
          <div className="mt-6 flow-root">
            <div className="-my-6 divide-y divide-gray-500/10">
              {signedIn && (
                <div className="space-y-2 py-6">
                  <Link
                    to={"/user/$userName"}
                    params={{
                      userName: globalState.userName,
                    }}
                    className="-mx-3 block rounded-lg px-3 py-2 text-base font-semibold leading-7 text-gray-900 hover:bg-gray-50"
                    onClick={() => {
                      setMobileMenuOpen(false);
                    }}
                  >
                    Profile
                  </Link>
                  {/* <Link
                    to={"/"}
                    className="-mx-3 block rounded-lg px-3 py-2 text-base font-semibold leading-7 text-gray-900 hover:bg-gray-50"
                    onClick={() => {
                      setMobileMenuOpen(false);
                    }}
                  >
                    Messages
                  </Link> */}
                  <Link
                    to={"/"}
                    className="-mx-3 block rounded-lg px-3 py-2 text-base font-semibold leading-7 text-gray-900 hover:bg-gray-50"
                    onClick={() => {
                      setMobileMenuOpen(false);
                    }}
                  >
                    Settings
                  </Link>
                </div>
              )}
              <div className="space-y-2 py-6">
                <Link
                  to="/"
                  className="-mx-3 block rounded-lg px-3 py-2 text-base font-semibold leading-7 text-gray-900 hover:bg-gray-50"
                  onClick={() => {
                    setMobileMenuOpen(false);
                  }}
                >
                  Home
                </Link>
                <Disclosure as="div" className="-mx-3">
                  {({ open }) => (
                    <>
                      <Disclosure.Button className="flex w-full items-center justify-between rounded-lg py-2 pl-3 pr-3.5 text-base font-semibold leading-7 text-gray-900 hover:bg-gray-50">
                        Forum
                        <ChevronDownIcon
                          className={
                            open
                              ? "rotate-180 h-5 w-5 flex-none"
                              : "h-5 w-5 flex-none"
                          }
                          aria-hidden="true"
                        />
                      </Disclosure.Button>
                      <Disclosure.Panel className="mt-2 space-y-2">
                        <div className=" flex justify-between m-5">
                          <span className=" font-bold">Topics</span>
                          {/* <Link
                            to={"/forum/$topic"}
                            params={{
                              topic: topics[0].title,
                            }}
                            className=" font-medium text-blue-700"
                            onClick={() => {
                              setMobileMenuOpen(false);
                            }}
                          >
                            see all &rarr;
                          </Link> */}
                          <AddTopic
                            className={
                              " text-black text-lg flex flex-row hover:border-black hover:border-2 cursor-pointer hover:font-bold hover:rounded-sm pr-2"
                            }
                            plusSize={18}
                            plusColor={"black"}
                            topicsArr={topicsArr}
                            setTopicsArr={setTopicsArr}
                            setTrigger={setTrigger}
                          />
                        </div>
                        {[...topicsArr].map((item) => (
                          <Disclosure.Button
                            key={item.id}
                            className="block rounded-lg py-2 pl-6 pr-3 text-sm font-semibold leading-7 text-gray-900 hover:bg-gray-50"
                          >
                            <Link
                              to={"/forum/$topic"}
                              params={{ topic: item.title }}
                              onClick={() => {
                                setMobileMenuOpen(false);
                              }}
                            >
                              {item.title}
                            </Link>
                          </Disclosure.Button>
                        ))}
                      </Disclosure.Panel>
                    </>
                  )}
                </Disclosure>
              </div>
              <div className="py-4">
                {signedIn ? (
                  <Link
                    to="/"
                    onClick={handleSignOut}
                    className=" block rounded-lg py-2.5 text-base font-semibold leading-7 text-gray-900 hover:bg-gray-50"
                  >
                    Sign out &rarr;
                  </Link>
                ) : (
                  <Link
                    to="/Login"
                    className=" block rounded-lg py-2.5 text-base font-semibold leading-7 text-gray-900 hover:bg-gray-50"
                    onClick={() => {
                      setMobileMenuOpen(false);
                    }}
                  >
                    Log in &rarr;
                  </Link>
                )}
              </div>
            </div>
          </div>
        </Dialog.Panel>
      </Dialog>
    </header>
  );
};

export { NavBar };
