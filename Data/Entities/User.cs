namespace Data.Entities
{
    public class User
    {
        public Guid ID_User { get; set; }
        public string ID_UserString {
            get { return ID_User.ToString("N"); }
            set { ID_User = new Guid(value); }
        }
        public string FirstName { get; set; } =string.Empty;
        public string LastName { get; set; } = string.Empty;
        public int PhoneNumber { get; set; }
        public string Email { get; set; } = string.Empty;

        public ICollection<Post> Posts { get; set; }
        public ICollection<Message> Messages { get; set; }
    }
}
