namespace Bai1
{
    public class User
    {
        string id;
        string username;
        string pasword;
        string fullname;
        string role;

        public User()
        {
        }

        public User(string id, string username, string pasword, string fullname, string role)
        {
            this.Id = id;
            this.Username = username;
            this.Pasword = pasword;
            this.Fullname = fullname;
            this.role = role;
        }

        public string Id
        {
            get; set;
        }
        public string Username { get; set; }
        public string Pasword { get; set; }
        public string Fullname { get; set; }
        public string Role { get; set; }
    }
}
