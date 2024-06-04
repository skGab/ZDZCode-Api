namespace ZDZCode_Api.Src.Domain.Entities
{
    [Serializable]
    public class BillsEntity(string name, string value, string userID)
    {
        public Guid id { get; private set; } = Guid.NewGuid();
        public string name { get; private set; } = name;
        public string value { get; private set; } = value;
        public DateTime date { get; init; } = DateTime.Now;

        public string userID { get; private set; } = userID;
        public virtual UserEntity? user { get;  private set; }
    }
}