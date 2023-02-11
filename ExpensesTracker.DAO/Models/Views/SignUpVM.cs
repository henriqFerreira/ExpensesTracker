using System.ComponentModel.DataAnnotations;

namespace ExpensesTracker.DAO.Models.Views
{
    public class SignUpVM
    {
        [Required(ErrorMessage = "O campo {0} é obrigatório!")]
        [StringLength(35, MinimumLength = 1, ErrorMessage = "Deve conter entre 1 e 35 caracteres.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório!")]
        [StringLength(50, MinimumLength = 1, ErrorMessage = "Deve conter entre 1 e 50 caracteres.")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório!")]
        [EmailAddress(ErrorMessage = "O email digitado não é válido!")]
        public string Email { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório!")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
