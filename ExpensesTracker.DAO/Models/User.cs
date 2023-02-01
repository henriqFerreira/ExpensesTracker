using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExpensesTracker.DAO.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string IdAspNetUser { get; set; }

        [Required(ErrorMessage = "O campo 'FirstName' é obrigatório.")]
        [StringLength(100, MinimumLength = 1, ErrorMessage = "O campo 'FirstName' deve ter entre 1 e 100 caracteres.")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "O campo 'LastName' é obrigatório.")]
        [StringLength(100, MinimumLength = 1, ErrorMessage = "O campo 'LastName' deve ter entre 1 e 100 caracteres.")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "O campo 'Email' é obrigatório.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "O campo 'Password' é obrigatório.")]
        [StringLength(100, MinimumLength = 1, ErrorMessage = "O campo 'Password' deve ter entre 1 e 100 caracteres..")]
        public string Password { get; set; }

        [ForeignKey("IdAspNetUser")]
        [InverseProperty("User")]
        public AspNetUser IdAspNetUserNavigation { get; set; }
    }
}
