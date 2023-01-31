using System.ComponentModel.DataAnnotations;

namespace ExpensesTracker.DAO.Models
{
    public class Transaction
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [StringLength(50, MinimumLength = 1, ErrorMessage = "Campo {0}: Apenas de 1 a 50 caracteres.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        public decimal Value { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        public DateTime Date { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        public byte Type { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        public byte Category { get; set; }

    }
}
