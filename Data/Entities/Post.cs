
namespace Data.Entities
{
    public class Post
    {
        public Guid ID_Posts { get; set; }
        public string ID_PostsString
        {
            get { return ID_Posts.ToString("N"); }
            set { ID_Posts = new Guid(value); }
        }
        public Guid UserID { get; set; }
        public string UserIDString
        {
            get { return UserID.ToString("N"); }
            set { UserID = new Guid(value); }
        }
        public string Content { get; set; }
        public DateTime CreatedDate { get; set; }
        public User User { get; set; }
        public List<Message> Messages { get; set; }
    }
}
