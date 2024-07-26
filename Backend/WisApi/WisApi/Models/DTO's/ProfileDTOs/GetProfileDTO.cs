namespace WisApi.Models.DTO_s.ProfileDTOs
{
    public class GetProfileDTO
    {
        public string UserName { get; set; }

        public string Bio { get; set; }

        public string ImageName {  get; set; }

        public string ImageSrc { get; set; }

        public bool IsBlocked { get; set; }

    }
}
