namespace WisApi.Models.DTO_s.ReportDTO
{
    public class HandledReportDTO
    {
        public int Id { get; set; }

        public bool IsHandled { get; set; }

        public string? HandledBy { get; set; }

        public DateTime HandledTime { get; set; }
    }
}
