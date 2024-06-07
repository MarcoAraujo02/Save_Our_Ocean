using System.ComponentModel.DataAnnotations;

namespace Save_Our_Ocean.Models
{
    public class Voluntario
    {


        [Key]
        public int Id { get; set; }

        [Required]
        public string Nome { get; set; }

        [Required]

        public string Email { get; set; }

        [Required]
        public string Senha { get; set; }

        [Required]

        public string sexo { get; set; }


        public ICollection<Area> Area { get; set; }

    }
}
