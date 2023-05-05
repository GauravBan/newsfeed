namespace news_feed_system.Entity
{
    public class PostEntity
    {
        static int global_Post_id = 1;
        public int id { get; set; }
        public string description { get; set; }
        public int user_id { get; set; }
        public int upVotes_Count { get; set; }
        public int downVotes_Count { get; set; }
        public DateTime createdDated { get; set; }

        public PostEntity(string text, int user_id)
        {
            this.id = global_Post_id;
            this.description = text;
            this.user_id = user_id;
            this.upVotes_Count = 0;
            this.downVotes_Count = 0;
            this.createdDated = DateTime.Now;

            global_Post_id++;
        }
    }
}
