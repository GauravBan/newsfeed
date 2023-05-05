
using news_feed_system.Entity;
using news_feed_system.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace news_feed_system.Repository
{
    public class CommentRepository : CommentInterface
    {
        public void comment(int user_id, int post_id, string text, List<CommentEntity> commentEntities)
        {
            var comment = new CommentEntity(text, post_id, user_id);
            Console.WriteLine($"Created Comment with CommentId:{comment.id}");
            commentEntities.Add(comment);
        }

        public void downVote(int comment_id, List<CommentEntity> commentEntities)
        {
            if (commentEntities.Any(x => x.id == comment_id))
            {
                commentEntities[comment_id - 1].downVotes_count++;
            }
            else
            {
                Console.WriteLine("Comment Not Found");
            }
        }

        public void reply(int user_id, int comment_id, string text, List<CommentEntity> commentEntities)
        {
            if(commentEntities.Any(x=>x.id == comment_id))
            {
                var post_id = commentEntities.Where(x => x.id == comment_id).Select(y => y.post_id).FirstOrDefault();
                var comment = new CommentEntity(text, post_id, user_id, comment_id);
                Console.WriteLine($"Created Comment with CommentId:{comment.id}");
                commentEntities.Add(comment);
            }
            else
            {
                Console.WriteLine("Comment Not Found");
            }
        }

        public void upVote(int comment_id, List<CommentEntity> commentEntities)
        {
            if (commentEntities.Any(x => x.id == comment_id))
            {
                commentEntities[comment_id-1].upVotes_count++;
            }
            else
            {
                Console.WriteLine("Comment Not Found");
            }
        }
    }
}
