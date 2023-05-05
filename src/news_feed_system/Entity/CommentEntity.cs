namespace news_feed_system.Entity
{
    public class CommentEntity
    {
        static int global_Comment_id = 1;
        public int id { get; set; }
        public string text { get; set; }
        public int post_id { get; set; }
        public int user_id { get; set; }
        public int upVotes_count { get; set; }
        public int downVotes_count { get; set; }
        public int? replied_Comment { get; set; }
        public DateTime createdDate { get; set; }

        public CommentEntity(string text, int post_id, int user_id, int? replied_Comment=null)
        {
            this.id = global_Comment_id;
            this.text = text;
            this.post_id = post_id;
            this.user_id = user_id;
            this.upVotes_count = 0;
            this.downVotes_count = 0;
            this.replied_Comment = replied_Comment;
            this.createdDate = DateTime.Now;

            global_Comment_id++;
        }
    }
}
