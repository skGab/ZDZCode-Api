namespace ZDZCode_Api.Src.Application.Dtos
{
    public class UpdateBillDto(string name, string value)
    {
        public string name { get; private set; } = name;
        public string value { get; private set; } = value;
    }
}
