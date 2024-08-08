namespace WisApi.Models.DTO_s
{
    public class RegisterResultDTO
    {
        public RegisterResultDTO(string result)
        {
            Result = result;
        }

        public RegisterResultDTO() { }

        public string Result { get; set; }
    }
}
