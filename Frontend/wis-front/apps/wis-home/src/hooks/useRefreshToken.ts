import { REFRESH_URL } from "../api/urls";
import { useGlobalState } from "../main";
import { jwtDecode } from "jwt-decode";



const requestToken = async () => {
  const response = await fetch(REFRESH_URL, {
        method: "POST",
        headers: {
          "Content-Type": "application/json",
        },
        credentials: 'include'
      });

  return response
};


const useRefreshToken = async () => {
  const { setGlobalState } = useGlobalState();

const refresh = await requestToken();

    if (refresh.status === 200) {
        const data = await refresh.json();
        const decoded = jwtDecode(data.token);
        setGlobalState(prevState => ({
          ...prevState,
          isLoggedIn: true,
          accessToken: data.token,
          userName: decoded['http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name'],
          role: decoded['http://schemas.microsoft.com/ws/2008/06/identity/claims/role'],
        }));
      } else {
        console.error('Failed to refresh token');
      }
  }

export default useRefreshToken;





// const useRefreshToken = () => {
//     const { globalState, setGlobalState } = useGlobalState();
//     const [decodedToken, setDecodedToken] = useState<JwtPayload>();

//     useEffect(() => {
//         if(globalState.isLoggedIn === true) {
//             const fetchAndSetToken = async () => {
//             const response = await fetch(REFRESH_URL, {
//                 method: "POST",
//                 headers: {
//                     "Content-Type": "application/json",
//                 },
//                 credentials: 'include'
//             });
//             if (response.status === 200) {
//                 const data = await response.json();
//                 //console.log("data: " + data.token)
//                 const decoded = jwtDecode(data.token);
//                 console.log(decoded)
//                 setDecodedToken(data);
//                 setGlobalState(prevState => ({
//                    ...prevState,
//                     isLoggedIn: true,
//                     accessToken: data.token,
//                     userName: decoded['http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name'],
//                     role: decoded['http://schemas.microsoft.com/ws/2008/06/identity/claims/role'],
//                 }));
//             } else {
//                 console.error('Failed to refresh token');
//             }
//         };
//         fetchAndSetToken();
//         }
//         console.log("run")
//     }, []);

//     return decodedToken;
// };

// export default useRefreshToken;