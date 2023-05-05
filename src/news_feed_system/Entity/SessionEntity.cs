namespace news_feed_system.Entity
{
    public class SessionEntity
    {
        static int session_id = 1;
        public int Id { get; set; }
        public int UserId { get; set; }
        public DateTime expireTime { get; set; }

        public SessionEntity(int userId)
        {
            this.UserId = userId;
            this.expireTime = DateTime.Now.AddMinutes(60);
            this.Id = session_id;

            session_id++;
        }
    }
}
