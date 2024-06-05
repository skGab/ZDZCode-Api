namespace ZDZCode_Api.Src.Application.Dtos
{
    public class BillsDto(Guid id, string name, string value, DateTime date, string userID)
    {
        public Guid id { get; private set; } = id;
        public string name { get; private set; } = name;
        public string value { get; private set; } = value;
        public DateTime date { get; private set; } = date;
        public string userID { get; private set; } = userID;
    }

    public class BillsPayload(IEnumerable<BillsDto> bills, string message)
    {
        public IEnumerable<BillsDto> Bills { get; set; } = bills;
        public string Message { get; set; } = message;
    }
}
