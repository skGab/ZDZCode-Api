namespace ZDZCode_Api.Entities
{
    public class BillsEntity
    {
        private string ID;
        private string Name;
        private string Value;
        private DateTime Date;

        public BillsEntity(string iD, string name, string value, DateTime date)
        {
            ID = iD;
            Name = name;
            Value = value;
            Date = date;
        }
    }
}
