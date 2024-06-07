using System.ComponentModel.DataAnnotations;

namespace Save_Our_Ocean.DTOs
{
    public class LoginVoluntarioDTO
    {


        [Required]
        public string Email { get; set; }

        [Required]
        public string Senha { get; set; }
    }
}

