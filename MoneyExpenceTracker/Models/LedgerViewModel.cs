using System.ComponentModel.DataAnnotations;

namespace MoneyExpenceTracker.Models;

public class LedgerViewModel
{
    public List<TransactionEntry> Entries { get; set; } = [];

    public decimal TotalIncome { get; set; }

    public decimal TotalExpense { get; set; }

    public decimal TotalSaving { get; set; }

    [Required]
    public TransactionEntry NewEntry { get; set; } = new();
}
