using System.ComponentModel.DataAnnotations;

namespace Save_Our_Ocean.Models
{
    public class Administrador
    {

        [Key]
        public int Id { get; set; }

        [Required]
        public string Nome { get; set; }

        [Required]
        public string Senha { get; set; }
    }
}
