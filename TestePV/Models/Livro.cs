using System.ComponentModel.DataAnnotations;

namespace TestePV.Models
{
    public class Livro
    {
        [Key]
        public int? LivroId { get; set; }

        [Required(ErrorMessage = "O Campo Título do Livro é de preenchimento obrigatório")]
        [Display(Name = "Título do Livro ")]
        public string LivroNome { get; set; }

        [Required(ErrorMessage = "O Campo Autor é de preenchimento obrigatório")]
        public string Autor { get; set; }

        [Required(ErrorMessage = "O Campo Editora é de preenchimento obrigatório")]
        public string Editora { get; set; }

        [Display(Name = "Data da Publicação ")]
        public string LivroAnoPublicacao { get; set; }

        [Required(ErrorMessage = "O Campo Gênero é de preenchimento obrigatório")]
        [Display(Name = "Gênero ")]
        public string Genero { get; set; }

        [Display(Name = "Nº de Páginas")]
        public string Paginas { get; set; }
        public string Sinopse { get; set; }

    }
}
