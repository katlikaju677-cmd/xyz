using System.ComponentModel.DataAnnotations;

namespace MoneyExpenceTracker.Models;

public class TransactionEntry
{
    public Guid Id { get; set; } = Guid.NewGuid();

    [Required]
    [Display(Name = "Type")]
    public TransactionType Type { get; set; }

    [Required]
    [Range(0.01, 1000000)]
    public decimal Amount { get; set; }

    [Required]
    [StringLength(100)]
    public string Description { get; set; } = string.Empty;

    [DataType(DataType.Date)]
    public DateOnly Date { get; set; } = DateOnly.FromDateTime(DateTime.Today);
}
