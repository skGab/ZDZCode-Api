using System.ComponentModel.DataAnnotations;

namespace ZDZCode_Api.Src.Domain.Entities
{
    public class UserEntity
    {
        public Guid id { get; set; } = Guid.NewGuid();

        [Key]
        public string email { get; set; }
        public string password { get; set; }
        public ICollection<BillsEntity>? bills { get; }

        // Constructor with parameters
        public UserEntity(string email, string password)
        {
            this.email = email;
            this.password = password;
        }
    }
}
