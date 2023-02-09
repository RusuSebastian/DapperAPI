
namespace Data.Entities
{
    public class Message
    {
        public Guid MessageId { get; set; }
        public string MessageIdString
        {
            get { return MessageId.ToString("N"); }
            set { MessageIdString = value; }
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
        public List<Post> Posts { get; set; }
    }
}
