using System.ComponentModel.DataAnnotations;

namespace ZDZCode_Api.Src.Domain.Entities
{
    public class UserEntity(string id, string name, string email, int password)
    {
        [Key]
        public string id { get; set; } = id;
        public string email { get; set; } = email;
        public string name { get; set; } = name;
        public int password { get; set; } = password;

        public ICollection<BillsEntity>? bills { get; }
    }
}
