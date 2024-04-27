using System.ComponentModel.DataAnnotations;

namespace WisApi.Models.DTO_s
{

    #nullable disable

    public class LoginRequestDTO
    {
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Username { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
