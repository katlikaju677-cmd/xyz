namespace MoneyExpenceTracker.Models;

public class LedgerStore
{
    private readonly List<TransactionEntry> _entries =
    [
        new TransactionEntry { Type = TransactionType.Income, Amount = 3200, Description = "Salary", Date = DateOnly.FromDateTime(DateTime.Today.AddDays(-7)) },
        new TransactionEntry { Type = TransactionType.Expense, Amount = 450, Description = "Groceries", Date = DateOnly.FromDateTime(DateTime.Today.AddDays(-5)) },
        new TransactionEntry { Type = TransactionType.Saving, Amount = 300, Description = "Emergency fund", Date = DateOnly.FromDateTime(DateTime.Today.AddDays(-2)) }
    ];

    public IReadOnlyList<TransactionEntry> Entries => _entries;

    public void Add(TransactionEntry entry)
    {
        _entries.Add(entry);
    }

    public decimal TotalFor(TransactionType type)
    {
        return _entries.Where(entry => entry.Type == type).Sum(entry => entry.Amount);
    }
}
