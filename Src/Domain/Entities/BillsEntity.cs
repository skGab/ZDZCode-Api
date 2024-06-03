namespace ZDZCode_Api.Src.Domain.Entities
{
    public class BillsEntity(string iD, string name, string value, DateTime date)
    {
        public string ID { get; set; } = iD;
        public string Name { get; set; } = name;
        public string Value { get; set; } = value;
        public DateTime Date { get; set; } = date;
    }
}