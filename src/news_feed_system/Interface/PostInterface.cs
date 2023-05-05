using news_feed_system.Entity;

namespace news_feed_system.Interface
{
    internal interface PostInterface
    {
        public void post(string description, int userId, List<PostEntity> postEntities);
        public void upVote(int post_id, List<PostEntity> postEntities);
        public void downVote(int post_id, List<PostEntity> postEntities);
        List<OutPutPostEntity> shownewsfeed(int userId, int sortOption, List<PostEntity> postEntities, Dictionary<int, List<int>> follower, List<CommentEntity> commentEntities);

    }
}
