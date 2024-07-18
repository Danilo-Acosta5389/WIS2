namespace WisApi.Models.DTO_s
{
    public class statusMessageDTO
    {
        public statusMessageDTO(string message)
        {
            Message = message;
        }
        public string Message { get; set; }
    }
}
