using System.ComponentModel.DataAnnotations;

namespace WisApi.Models.DTO_s
{
    #nullable disable

    public class RegisterRequestDTO
    {
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        //public string[] Roles { get; set; }
    }
}
