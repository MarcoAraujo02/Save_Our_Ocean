using System.ComponentModel.DataAnnotations;

namespace Save_Our_Ocean.DTOs
{
    public class CadastroAreaDTO
    {

        [Required]
        public string Cep {  get; set; }


        [Required]
        public string TipoPoluicao { get; set; }


        [Required]
        public string Descricao { get; set; }
    }
}
