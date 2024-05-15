import { REFRESH_URL } from "../api/urls";


const useRefresh = async () => {
    const response = await fetch(REFRESH_URL, {
        method: "POST",
        headers: {
        "Content-Type": "application/json",
        },
        credentials: 'include'
    });
    const data = await response.json();
    console.log(data.token);
    return response;
}
export default useRefresh;