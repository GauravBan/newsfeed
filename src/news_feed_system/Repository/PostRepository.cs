using news_feed_system.Entity;
using news_feed_system.Interface;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;

namespace news_feed_system.Repository
{
    public class PostRepository : PostInterface
    {
        public void downVote(int post_id, List<PostEntity> postEntities)
        {
            if (postEntities.Any(x => x.id == post_id))
            {
                postEntities[post_id - 1].downVotes_Count++;
            }
            else
            {
                Console.WriteLine("Post Not Found");
            }
        }

        public void post(string description, int userId, List<PostEntity> postEntities)
        {
            var post = new PostEntity(description, userId);
            Console.WriteLine($"Created Post with PostId:{post.id}");
            postEntities.Add(post);
        }

        public void upVote(int post_id, List<PostEntity> postEntities)
        {
            if (postEntities.Any(x => x.id == post_id))
            {
                postEntities[post_id-1].upVotes_Count++;
            }
            else
            {
                Console.WriteLine("Post Not Found");
            }
        }

        public List<OutPutPostEntity> shownewsfeed(int userId, int sortOption, List<PostEntity> postEntities, Dictionary<int, List<int>> follower, List<CommentEntity> commentEntities)
        {
            var postList = new List<OutPutPostEntity>();
            foreach (var post in postEntities)
            {
                var OutPutEntity = new OutPutPostEntity(post.id, post.description,
                    post.user_id, post.upVotes_Count, post.downVotes_Count,
                    DateTime.Now - post.createdDated, commentEntities.Where(x => x.post_id == post.id).ToList());
                postList.Add(OutPutEntity);
            }


            if (sortOption == 1)
            {
                if (!follower.ContainsKey(userId)||follower[userId].Count == 0)
                {
                    return postList.OrderByDescending(x => x.upVotes_Count - x.downVotes_Count).ToList();
                }
                var ordered = postList.Where(x => follower[userId].Contains(x.user_id)).ToList();
                var unorder = postList.Where(x => !follower[userId].Contains(x.user_id)).ToList();
                ordered.AddRange(unorder);
                return ordered;

            }
            else if (sortOption == 2)
            {
                return postList.OrderByDescending(x => x.upVotes_Count - x.downVotes_Count).ToList();
            }
            else if (sortOption == 3)
            {
                return postList.OrderByDescending(x=>x.comments.Count).ToList();
            }

            else if (sortOption == 4)
            {
                return postList.OrderBy(x => x.createdDated).ToList();
            }
            

            return postList;
        }
    }
}
