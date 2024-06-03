namespace ZDZCode_Api.Entities
{
    public class UserEntity
    {
        private string ID { get; set; }
        private string Name { get; set; }
        private string Email { get; set; }
        private int Password { get; set; }

        public UserEntity(string iD, string name, string email, int password)
        {
            ID = iD;
            Name = name;
            Email = email;
            Password = password;
        }
    }
}
