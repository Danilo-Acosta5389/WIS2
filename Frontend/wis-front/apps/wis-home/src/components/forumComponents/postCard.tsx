import { ScrollArea, Separator } from "@repo/ui";
import { topics } from "../../assets/data";
import { Route } from "../../routes/forum/$topic/$postId";

function PostCard() {
  const { topic, postId } = Route.useParams();

  // Filter topics based on the topic name
  const filteredTopics = topics.filter((t) => t.name === topic);

  return (
    <ScrollArea className="flex flex-col p-6 bg-black w-full">
      {/* <span className="m-4 text-4xl font-extrabold leading-none tracking-tight md:text-5xl lg:text-6xl text-white">
        {topic}
        <br></br>
        {postId}
      </span> */}
      {/* Map over the filtered topics */}
      {filteredTopics.map((topic) => {
        // Find the post with the matching postId
        const post = topic.posts.find((p) => p.id === parseInt(postId));

        // Return the card only if a matching post was found
        if (post) {
          return (
            <div className=" m-4 text-white flex flex-col" key={post.id}>
              <span className="text-4xl font-extrabold leading-none tracking-tight md:text-5xl lg:text-6x">
                {post.title}
              </span>
              <span className=" mt-5">
                <p className=" text-3xl mb-5">{post.post}</p>
                <p>{post.question}</p>
              </span>
              <Separator className="mt-5 w-[90%] self-start" />
            </div>
          );
        }
        // Optionally, handle the case where no post is found
        return null; // Or return a different component indicating no post found
      })}
    </ScrollArea>
  );
}

export default PostCard;
