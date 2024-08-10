using System.ComponentModel.DataAnnotations;

namespace WisApi.Models.DTO_s
{
    public class VerifyEmailRequestDTO
    {
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        public string Code { get; set; }
    }
}
