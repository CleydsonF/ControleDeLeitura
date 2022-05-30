using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TestePV.Models
{
    public class Leitura
    {
        [Key]
        public int? LeiturasId { get; set; }

        [Required(ErrorMessage = "O Campo Leitor é de preenchimento obrigatório")]
        [Display(Name = "Leitor ")]
        [ForeignKey("LeitorId")]
        public int LeitorId { get; set; }
        public virtual Leitor Leitor { get; set; }

        [Required(ErrorMessage = "O Campo Livro é de preenchimento obrigatório")]
        [Display(Name = "Livro ")]
        [ForeignKey("LivroId")]
        public int LivroId { get; set; }
        public virtual Livro Livro { get; set; }

        [Required(ErrorMessage = "O Campo Status da Leitura é de preenchimento obrigatório")]
        [Display(Name = "Status da Leitura ")]
        public string Status { get; set; }


    }
}
