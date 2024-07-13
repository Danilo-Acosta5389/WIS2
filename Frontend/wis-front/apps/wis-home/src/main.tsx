import React, {
  createContext,
  useState,
  useContext,
  FC,
  ReactNode,
} from "react";
import ReactDOM from "react-dom/client";
import "@repo/ui/main.css";
import App from "./App.tsx";

// MUST REFACT THIS, PUT CONTEXT HOOK IN SEPARATE FILE

// Define types for your global state
interface GlobalState {
  // Define your global state properties here
  isLoggedIn: boolean;
  accessToken: string;
  userName: string;
  role: string;
  image: string;
}

// Define context type
interface GlobalStateContextType {
  globalState: GlobalState;
  setGlobalState: React.Dispatch<React.SetStateAction<GlobalState>>;
}

// Define initial state
const initialState: GlobalState = {
  isLoggedIn: false,
  accessToken: "",
  userName: "",
  role: "",
  image: "",
};

// Create context
const GlobalStateContext = createContext<GlobalStateContextType | undefined>(
  undefined
);

// Custom hook to access global state
export const useGlobalState = () => {
  const context = useContext(GlobalStateContext);
  if (!context) {
    throw new Error("useGlobalState must be used within a GlobalStateProvider");
  }
  return context;
};

// Global state provider
export const GlobalStateProvider: FC<{ children: ReactNode }> = ({
  children,
}) => {
  const [globalState, setGlobalState] = useState<GlobalState>(initialState);

  return (
    <GlobalStateContext.Provider value={{ globalState, setGlobalState }}>
      {children}
    </GlobalStateContext.Provider>
  );
};

ReactDOM.createRoot(document.getElementById("root")!).render(
  <React.StrictMode>
    <GlobalStateProvider>
      <App />
    </GlobalStateProvider>
  </React.StrictMode>
);
