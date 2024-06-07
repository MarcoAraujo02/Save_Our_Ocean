using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Save_Our_Ocean.Models
{
    public class Area
    {


        [Key]
        public int Id { get; set; }



        [Required]
        public string Cep { get; set; }


        [Required]
        public string TipoPoluicao { get; set; }


        [Required]
        public string Descricao { get; set; }


        [Required]
        public string Status { get; set; } = "Sujo";

        [Required]
        public int VoluntarioId { get; set; }

        [ForeignKey("VoluntarioId")]
        public Voluntario? Voluntario { get; set; }
    }
}
