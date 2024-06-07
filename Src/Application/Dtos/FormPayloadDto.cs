namespace ZDZCode_Api.Src.Application.Dtos
{
    public class FormPayloadDto(string email, string password)
    {
        public string email { get; private set; } = email;
        public string password { get; private set; } = password;
    }
}
