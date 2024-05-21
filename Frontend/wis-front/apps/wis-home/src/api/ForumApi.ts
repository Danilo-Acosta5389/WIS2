interface Topics {
  id: number;
  title: string;
  description: string;
  userName: string;
  createdAt: Date;
  updatedAt: Date;
}

export async function getTopics(): Promise<Topics[]> {
  const response = await fetch("https://localhost:7118/api/Topic/Topics");
  const data = await response.json();
  //   console.log(data);

  return data;
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

export async function getPosts(id: number | undefined): Promise<PostDetails[]> {
  const response = await fetch(`https://localhost:7118/api/Post/byTopic/${id}`);
  const data = await response.json();
  //   console.log(data);

  return data;
}

export async function getSinglePost(
  id: number | undefined
): Promise<PostDetails[]> {
  const response = await fetch(`https://localhost:7118/api/Post/${id}`);
  const data = await response.json();
  //console.log(data[0]);
  return data;
}

interface CommentDetails {
  userName: string;
  comment: string;
  createdAt: Date;
  updatedAt: Date;
  isAnonymous: boolean;
  postId: number;
}

export async function getComments(
  postId: number | undefined
): Promise<CommentDetails[]> {
  const response = await fetch(`https://localhost:7118/api/Comment/${postId}`);
  const data = await response.json();

  return data;
}
