namespace ZDZCode_Api.Src.Domain.Entities
{
    public class UserEntity(string iD, string name, string email, int password)
    {
        private string ID { get; set; } = iD;
        private string Name { get; set; } = name;
        private string Email { get; set; } = email;
        private int Password { get; set; } = password;
    }
}
