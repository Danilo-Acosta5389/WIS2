namespace WisApi.Models.DTO_s.ProfileDTOs
{
    public class EditProfileDTO
    {
        public string UserName { get; set; }
        public string Bio {  get; set; }
        public IFormFile? ImageFile { get; set; }
    }
}
