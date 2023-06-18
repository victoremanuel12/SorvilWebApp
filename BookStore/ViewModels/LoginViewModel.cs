﻿using System.ComponentModel.DataAnnotations;

namespace BookStore.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "O campo Email é obrigatório.")]
        [EmailAddress(ErrorMessage = "O campo Email deve ser um endereço de email válido.")]
        [RegularExpression(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$", ErrorMessage = "O campo Email deve ser um endereço de email válido.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Preencha a senha, com no minimo 4 caracteres")]
        [MinLength(4)]
        [DataType(DataType.Password)]
        public string Senha { get; set; }
    }
}
