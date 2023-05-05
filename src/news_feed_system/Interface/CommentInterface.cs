using news_feed_system.Entity;

namespace news_feed_system.Interface
{
    internal interface CommentInterface
    {
        public void reply(int user_id, int comment_id, string text, List<CommentEntity> commentEntities);
        public void upVote(int comment_id, List<CommentEntity> commentEntities);
        public void downVote(int comment_id, List<CommentEntity> commentEntities);

        public void comment(int user_id, int post_id, string text, List<CommentEntity> commentEntities);
    }
}
