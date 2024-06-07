using System.ComponentModel.DataAnnotations;

namespace Save_Our_Ocean.DTOs
{
    public class CadastrarVoluntarioDTO
    {

        [Required]
        public string Nome { get; set; }

        [Required]

        public string Email { get; set;}


        [Required]
        public string Senha { get; set;}

        [Required]
        public string Sexo { get; set;}
    }
}
