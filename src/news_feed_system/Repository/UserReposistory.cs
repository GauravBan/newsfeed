using news_feed_system.Entity;
using news_feed_system.Interface;

namespace news_feed_system.Repository
{
    public class UserReposistory : UserInterface
    {
        public void follow(int userId, int followingId, List<UserEntity> userEntities, Dictionary<int, List<int>> follower)
        {
            var followed = userEntities.Any(x=>x.id==followingId);
            var user = userEntities.Any(x => x.id == userId);

            if (user && followed)
            {
                if (follower.ContainsKey(userId))
                {
                    var tempList = follower[userId];
                    if (tempList.Contains(followingId))
                    {
                        Console.WriteLine("User Already Following User");
                    }
                    else
                    {
                        tempList.Add(followingId);
                        follower[userId] = tempList;
                    }
                }
                else
                {
                    follower.Add(userId, new List<int>() { followingId });
                }
            }
            else
            {
                Console.WriteLine("User doesn't exists");
            }
        }

        public bool checkSession(List<SessionEntity> sessions, int userId)
        {
            return sessions.Any(x => x.UserId == userId && x.expireTime <= DateTime.Now);
        }

        public UserEntity login(string email, string password, List<UserEntity> userEntities, List<SessionEntity> sessions)
        {
            
            if (userEntities.Any(x => x.email == email && x.password == password))
            {
                UserEntity user = userEntities.Where(x => x.email == email && x.password == password).First();
                if (sessions.Any(x => x.UserId == user.id && x.expireTime < DateTime.Now) || !sessions.Any(x => x.UserId == user.id))
                {
                    var tempSessoion = new SessionEntity(user.id);
                    sessions.Add(tempSessoion);

                }
                Console.WriteLine("User login successed");
                return user;

            }
            else
            {
                Console.WriteLine("User not found");
                return null;
            }
        }

        public void signup(string name, string email, string password, int phone_number, List<UserEntity> userEntities)
        {
            if(userEntities.Any(x => x.email == email))
            {
                Console.WriteLine("User with same email already exists");
                return;
            }

            var UserObject = new UserEntity(name, email, password, phone_number);
            Console.WriteLine("User signeup complete");
            userEntities.Add(UserObject);
        }
    }
}
