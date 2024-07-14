import {
  CREATE_COMMENT,
  CREATE_POST,
  CREATE_TOPIC,
  GET_TOPICS,
  getCommentsByPostId,
  getPostsByTopicId,
  getSinglePostById,
  HIDE_COMMENT,
  HIDE_POST,
  HIDE_TOPIC,
} from "./urls.ts";

export const useForumApi = () => {
  async function getTopics(): Promise<Topics[]> {
    try {
      const response = await fetch(GET_TOPICS);
      const data: Topics[] = await response.json();

      return data;
    } catch (err) {
      console.log(err);
      const data: Topics[] = [];
      return data;
    }
  }

  async function getPosts(id: number): Promise<PostDetails[]> {
    const response = await fetch(getPostsByTopicId(id));
    const data = await response.json();
    //   console.log(data);
    return data;
  }

  async function getSinglePost(id: number): Promise<PostDetails[]> {
    const response = await fetch(getSinglePostById(id));
    const data = await response.json();
    //console.log(data[0]);
    return data;
  }

  async function getComments(postId: number): Promise<CommentDetails[]> {
    const response = await fetch(getCommentsByPostId(postId));
    const data = await response.json();

    return data;
  }

  async function createComment(
    params: CreateComment,
    token: string
  ): Promise<CreateComment | undefined> {
    // console.log(token);
    const response = await fetch(CREATE_COMMENT, {
      method: "POST",
      headers: {
        "Content-Type": "application/json",
        Authorization: `Bearer ${token}`,
      },
      credentials: "include",
      body: JSON.stringify(params),
    });
    const data = await response.json();
    return data;
  }

  async function createPost(
    params: CreatePost,
    token: string
  ): Promise<CreatePost | undefined> {
    const response = await fetch(CREATE_POST, {
      method: "POST",
      headers: {
        "Content-Type": "application/json",
        Authorization: `Bearer ${token}`,
      },
      credentials: "include",
      body: JSON.stringify(params),
    });
    //console.log(response);
    const data = await response.json();
    // console.log(data);
    return data;
  }

  async function createTopic(
    params: CreateTopic,
    token: string
  ): Promise<CreateTopic | undefined> {
    const response = await fetch(CREATE_TOPIC, {
      method: "POST",
      headers: {
        "Content-Type": "application/json",
        Authorization: `Bearer ${token}`,
      },
      credentials: "include",
      body: JSON.stringify(params),
    });

    const data = response.json();
    // console.log(data);
    return data;
  }

  async function hideTopic(title: string, jwt: string) {
    try {
      const response = await fetch(HIDE_TOPIC, {
        method: "PUT",
        headers: {
          "Content-Type": "application/json",
          Authorization: `Bearer ${jwt}`,
        },
        credentials: "include",
        body: JSON.stringify(title),
      });
      console.log(response.status);
    } catch (err) {
      console.log(err);
    }
  }

  async function hidePost(id: number, jwt: string) {
    try {
      console.log(id);
      const response = await fetch(HIDE_POST, {
        method: "PUT",
        headers: {
          "Content-Type": "application/json",
          Authorization: `Bearer ${jwt}`,
        },
        credentials: "include",
        body: JSON.stringify(id),
      });
      console.log(response.status);
    } catch (err) {
      console.log(err);
    }
  }

  async function hideComment(id: number, jwt: string) {
    try {
      const response = await fetch(HIDE_COMMENT, {
        method: "PUT",
        headers: {
          "Content-Type": "application/json",
          Authorization: `Bearer ${jwt}`,
        },
        credentials: "include",
        body: JSON.stringify(id),
      });
      console.log(response.status);
    } catch (err) {
      console.log(err);
    }
  }

  return {
    getComments,
    createComment,
    getPosts,
    getSinglePost,
    createPost,
    getTopics,
    createTopic,
    hideTopic,
    hidePost,
    hideComment,
  };
};

export interface CreateTopic {
  userName: string;
  title: string;
  description: string;
  createdAt: Date;
  isAnonymous: boolean;
}

export interface CreatePost {
  title: string;
  subTitle: string;
  text: string;
  createdAt: Date;
  userName: string;
  topicId: number;
  isAnonymous: boolean;
}

export interface CreateComment {
  userName: string;
  comment: string;
  createdAt: Date;
  isAnonymous: boolean;
  postId: number;
}

export interface CommentDetails {
  id: number;
  userName: string;
  comment: string;
  createdAt: Date;
  updatedAt: Date;
  isAnonymous: boolean;
  postId: number;
}

export interface PostDetails {
  id: number;
  title: string;
  subTitle: string;
  text: string;
  createdAt: Date;
  updatedAt: Date;
  userName: string;
}

export interface Topics {
  id: number;
  title: string;
  description: string;
  userName: string;
  createdAt: Date;
  updatedAt: Date;
}
