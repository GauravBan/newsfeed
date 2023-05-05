// See https://aka.ms/new-console-template for more information
using news_feed_system.Entity;
using news_feed_system.Repository;
using System;
using System.Text.Json.Serialization;

var UserList = new List<UserEntity>();
var PostList = new List<PostEntity>();
var SessionList = new List<SessionEntity>();
var CommentList = new List<CommentEntity>();
var Followers = new Dictionary<int, List<int>>();
var exit = false;
var userRepoObject = new UserReposistory();
var postRepoObject = new PostRepository();
var commentRepoObject = new CommentRepository();
UserEntity tempUserEntity = new UserEntity();

while (!exit)
{
    Console.WriteLine("\nOperations Options Available");
    Console.WriteLine("signup \nlogin \npost \nnewsfeed \nupVote \ndownVote \nfollow \ncomment \nreply \nupVoteComment \ndownVoteComment");
    Console.Write("\nEnter Operation to be performed:");
    var input = Console.ReadLine();
    switch (input)
    {
        case "signup":
            Console.Write("\nEnter UserName:");
            var name = Console.ReadLine();
            Console.Write("Enter Email:");
            var email = Console.ReadLine();
            Console.Write("Enter Password:");
            var password = Console.ReadLine();
            Console.Write("Enter Phone Number:");
            var phone = Convert.ToInt32(Console.ReadLine());

            userRepoObject.signup(name.ToLower(), email.ToLower(), password.ToLower(), phone, UserList);
            break;
        case "login":
            Console.Write("\nEnter Email:");
            email = Console.ReadLine();
            Console.Write("Enter Password:");
            password = Console.ReadLine();
            tempUserEntity = userRepoObject.login(email, password, UserList, SessionList);
            break;
        case "post":
            if (tempUserEntity != null && !userRepoObject.checkSession(SessionList, tempUserEntity.id))
            {
                Console.Write("\nEnter Post Description:");
                var desc = Console.ReadLine();
                postRepoObject.post(desc, tempUserEntity.id, PostList);
            }
            else
            {
                Console.WriteLine("User login expired relogin");
            }
            break;
        case "newsfeed":
            if (tempUserEntity != null && !userRepoObject.checkSession(SessionList, tempUserEntity.id))
            {
                var sort = 1;
                
                Console.WriteLine("Following sort options are available\r\n" +
                    "1 - Followed users: posts by followed users appear first.\r\n" +
                    "2 - Score (= upvotes - downvotes): higher the better.\r\n" +
                    "3 - The number of comments: higher the better.\r\n" +
                    "4 - Timestamp: more recent the better");
                Console.Write("\nEnter Sort Option:");
                var temp = Convert.ToInt32(Console.ReadLine());
                if (temp != 0)
                {
                    sort = temp;
                }
                var tempPost = postRepoObject.shownewsfeed(tempUserEntity.id, sort, PostList, Followers, CommentList);
                foreach(var post in tempPost)
                {
                    var time = "";
                    if (post.createdDated.Days > 365)
                    {
                        var years = ((int)(post.createdDated.TotalDays / 365));
                        if (post.createdDated.Days % 365 != 0)
                            years += 1;
                        time = string.Format("about {0} {1} ago", years, years == 1 ? "year" : "years");
                    }
                    else if (post.createdDated.Days > 30)
                    {
                        int months = (post.createdDated.Days / 30);
                        if (post.createdDated.Days % 31 != 0)
                            months += 1;
                        time = String.Format("about {0} {1} ago", months, months == 1 ? "month" : "months");
                    }
                    else if (post.createdDated.Days > 0)
                        time = String.Format("about {0} {1} ago", post.createdDated.Days, post.createdDated.Days == 1 ? "day" : "days");
                    else if (post.createdDated.Hours > 0)
                        time = String.Format("about {0} {1} ago", post.createdDated.Hours, post.createdDated.Hours == 1 ? "hour" : "hours");
                    else if (post.createdDated.Minutes > 0)
                        time = String.Format("about {0} {1} ago", post.createdDated.Minutes, post.createdDated.Minutes == 1 ? "minute" : "minutes");
                    else
                    {
                        time = "just now";
                    }
                    Console.WriteLine($"ID:{post.id} Description:{post.description} PostedBy:{post.user_id} " +
                        $"UpVoteCount:{post.upVotes_Count} DownVoteCount:{post.downVotes_Count} created {time}");
                    if (post.comments.Count > 0)
                    {
                        Console.WriteLine("Comments:");
                        foreach(var com in post.comments)
                        {
                            Console.WriteLine($"CommentId:{com.id} Comment:{com.text} UserId:{com.user_id} " +
                                $"UpVoteCount:{com.upVotes_count} DownVoteCount:{com.downVotes_count}");
                        }
                    }
                }
            }
            else
            {
                Console.WriteLine("User login expired relogin");
            }
            break;
        case "follow":
            if (tempUserEntity != null && !userRepoObject.checkSession(SessionList, tempUserEntity.id))
            {
                Console.Write("\nEnter UserId to Follow:");
                var followId = Convert.ToInt32(Console.ReadLine());

                userRepoObject.follow(tempUserEntity.id, followId, UserList, Followers);
            }
            else
            {
                Console.WriteLine("User login expired relogin");
            }
            break;
        case "comment":
            if (tempUserEntity != null && !userRepoObject.checkSession(SessionList, tempUserEntity.id))
            {
                Console.Write("\nEnter PostId:");
                var postId = Convert.ToInt32(Console.ReadLine());
                Console.Write("Enter Comment text:");
                var text = Console.ReadLine();
                commentRepoObject.comment(tempUserEntity.id, postId, text, CommentList);
            }
            else
            {
                Console.WriteLine("User login expired relogin");
            }
            break;
        case "reply":
            if (tempUserEntity != null && !userRepoObject.checkSession(SessionList, tempUserEntity.id))
            {
                Console.Write("\nEnter CommentId to reply:");
                var commentId = Convert.ToInt32(Console.ReadLine());
                Console.Write("Enter Comment text:");
                var text = Console.ReadLine();
                commentRepoObject.reply(tempUserEntity.id, commentId, text, CommentList);
            }
            else
            {
                Console.WriteLine("User login expired relogin");
            }
            break;
        case "upVoteComment":
            if (tempUserEntity != null && !userRepoObject.checkSession(SessionList, tempUserEntity.id))
            {
                Console.Write("\nEnter CommentId to UpVote:");
                var commentId = Convert.ToInt32(Console.ReadLine());
                commentRepoObject.upVote(commentId, CommentList);
            }
            else
            {
                Console.WriteLine("User login expired relogin");
            }
            break;
        case "downVoteComment":
            if (tempUserEntity != null && !userRepoObject.checkSession(SessionList, tempUserEntity.id))
            {
                Console.Write("\nEnter CommentId to downVote:");
                var commentId = Convert.ToInt32(Console.ReadLine());
                commentRepoObject.downVote(commentId, CommentList);
            }
            else
            {
                Console.WriteLine("User login expired relogin");
            }
            break;
        case "upVote":
            if (tempUserEntity != null && !userRepoObject.checkSession(SessionList, tempUserEntity.id))
            {
                Console.Write("\nEnter PostId to UpVote:");
                var postId = Convert.ToInt32(Console.ReadLine());
                postRepoObject.upVote(postId, PostList);
            }
            else
            {
                Console.WriteLine("User login expired relogin");
            }
            break;
        case "downVote":
            if (tempUserEntity != null && !userRepoObject.checkSession(SessionList, tempUserEntity.id))
            {
                Console.Write("\nEnter CommentId to downVote:");
                var postId = Convert.ToInt32(Console.ReadLine());
                postRepoObject.downVote(postId, PostList);
            }
            else
            {
                Console.WriteLine("User login expired relogin");
            }
            break;
        default:
            exit = true;
            break;
    }
}

