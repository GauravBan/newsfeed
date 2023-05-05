using news_feed_system.Interface;

namespace news_feed_system.Entity
{
    
    public class UserEntity
    {

        static int global_id = 1;
        /// <summary>
        /// 
        /// </summary>
        public int id { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string name { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string email { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string password { get; set; }
        public int? Phone_Number { get; set; }


        public UserEntity(string name, string email, string pwd, int phone) 
        {
            this.id = global_id;
            this.name = name;
            this.email = email;
            this.password = pwd;
            this.Phone_Number = phone;

            global_id++;
        }

        public UserEntity()
        { }
    }
}
