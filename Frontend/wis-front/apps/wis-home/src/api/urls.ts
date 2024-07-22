export const BASE_URL = "https://localhost:7118"; //API on development
//export const BASE_URL = "https://api.whatisspace.online"; //API on server
//export const BASE_URL = "http://localhost:5000"; //API on development

//AUTH
export const SIGN_IN = BASE_URL + "/api/Auth/Login";

export const REFRESH = BASE_URL + "/api/Auth/RefreshToken";

export const SIGN_OUT = BASE_URL + "/api/Auth/SignOut";

export const REGISTER = BASE_URL + "/api/Auth/Register";

//TOPICS
export const GET_TOPICS = BASE_URL + "/api/Topic/Topics";

export const CREATE_TOPIC = BASE_URL + "/api/Topic/Create";

export const HIDE_TOPIC = BASE_URL + "/api/Topic/invisible";

//POSTS
export const getPostsByTopicId = (Id: number) => {
  return BASE_URL + `/api/Post/byTopic/${Id}`;
};

export const getSinglePostById = (id: number) => {
  return BASE_URL + `/api/Post/${id}`;
};

export const CREATE_POST = BASE_URL + "/api/Post/Create";

export const HIDE_POST = BASE_URL + "/api/Post/invisible";

//COMMENTS
export const getCommentsByPostId = (id: number) => {
  return BASE_URL + `/api/Comment/${id}`;
};

export const CREATE_COMMENT = BASE_URL + "/api/Comment/Create";

export const HIDE_COMMENT = BASE_URL + "/api/Comment/invisible";

//USER / PROFILE
export const getUserProfile = (userName: string) => {
  return BASE_URL + `/api/User/${userName}`;
};

export const EDIT_USER_PROFILE = BASE_URL + "/api/User/UpdateProfile";

export const UPGRADE_USER_ROLE = BASE_URL + "/api/User/upgradeRole";

//REPORT
export const CREATE_REPORT = BASE_URL + "/api/Report";
