namespace WisApi.Models.DTO_s
{
    public class StatusMessageDTO
    {
        public StatusMessageDTO(string message)
        {
            Message = message;
        }
        public string Message { get; set; }
    }
}
