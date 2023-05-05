using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace news_feed_system.Entity
{
    public class OutPutPostEntity
    {
        public int id { get; set; }
        public string description { get; set; }
        public int user_id { get; set; }
        public int upVotes_Count { get; set; }
        public int downVotes_Count { get; set; }
        public TimeSpan createdDated { get; set; }

        public List<CommentEntity> comments { get; set; }

        public OutPutPostEntity(int id,string text, int user_id, int upVoteCount, int downVoteCount, TimeSpan timeSpan, List<CommentEntity> comments)
        {
            this.id = id;
            this.description = text;
            this.user_id = user_id;
            this.upVotes_Count = upVoteCount;
            this.downVotes_Count = downVoteCount;
            this.createdDated = timeSpan;
            this.comments = comments;
        }
    }
}
