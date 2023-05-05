using news_feed_system.Entity;

namespace news_feed_system.Interface
{
    internal interface UserInterface
    {
        public void signup(string name, string email, string password, int phone_number, List<UserEntity> userEntities);
        public void follow(int userId, int followingId, List<UserEntity> userEntities, Dictionary<int, List<int>> follower);
        public UserEntity login(string email, string password, List<UserEntity> userEntities, List<SessionEntity> sessions);
    }
}
