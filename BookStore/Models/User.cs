using System.ComponentModel.DataAnnotations;

namespace BookStore.Models
{
    public class User
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "O nome deve ser informado")]
        [MinLength(3, ErrorMessage = "O nome deve conter mínimo 3 caracteres")]
        public string Name { get; set; }
        [Required(ErrorMessage = "O campo Email é obrigatório.")]
        [EmailAddress(ErrorMessage = "O campo Email deve ser um endereço de email válido.")]
        [RegularExpression(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$", ErrorMessage = "O campo Email deve ser um endereço de email válido.")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Preencha a senha, com no minimo 4 caracteres")]
        [StringLength(12, MinimumLength = 4)]
        [DataType(DataType.Password)]
        public int Password { get; set; }
        public DateTime DataCadastro { get; set; }
    }
}
