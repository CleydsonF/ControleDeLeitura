using System.ComponentModel.DataAnnotations;

namespace TestePV.Models
{
    public class Leitor
    {

        [Key]
        public int? LeitorId { get; set; }


        [Required(ErrorMessage = "O Campo Nome é de preenchimento obrigatório")]
        [Display(Name = "Nome ")]
        public string LeitorNome { get; set; }


        [Required(ErrorMessage = "O Campo CPF é de preenchimento obrigatório")]
        [Display(Name = "CPF: ")]
        public string CPF { get; set; }


        [Required(ErrorMessage = "O Campo Data de Nascimento é de preenchimento obrigatório")]
        [Display(Name = "Data de Nascimento ")]
        public string DataNascimento { get; set; }


        [Required(ErrorMessage = "O Campo E-mail é de preenchimento obrigatório")]
        [Display(Name = "E-mail ")]
        public string Email { get; set; }

        [Required(ErrorMessage = "O Campo Telefone é de preenchimento obrigatório")]
        public string Telefone { get; set; }



        public string Rua { get; set; }

        [Display(Name = "Número ")]
        public string Numero { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string UF { get; set; }

    }
}
