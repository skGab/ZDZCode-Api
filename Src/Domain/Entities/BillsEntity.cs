using System.ComponentModel.DataAnnotations;

namespace ZDZCode_Api.Src.Domain.Entities
{
    [Serializable]
    public class BillsEntity(string name, string value, string userEmail)
    {
        [Key]
        public Guid id { get; private set; } = Guid.NewGuid();
        public string name { get; set; } = name;
        public string value { get; set; } = value;
        public DateTime date { get; init; } = DateTime.Now;

        public string userEmail { get; private set; } = userEmail;
        public virtual UserEntity? user { get;  private set; }
    }
}