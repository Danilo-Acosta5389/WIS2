namespace WisApi.Models
{
    public class ReportModel
    {
        public int Id { get; set; }

        public string Url { get; set; }

        public string User { get; set; }

        public string Message { get; set; }

        public DateTime Created { get; set; }

        public string Ip {  get; set; }

        public bool IsHandled { get; set; }

        public string HandledBy { get; set; }

        public DateTime HandledTime { get; set; }
    }
}
