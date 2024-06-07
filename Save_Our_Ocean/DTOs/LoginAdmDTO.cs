using System.ComponentModel.DataAnnotations;

namespace Save_Our_Ocean.DTOs
{
    public class LoginAdmDTO
    {

        [Required]

        public string Nome { get; set; }


        [Required]

        public string Senha { get; set; }
    }
}
