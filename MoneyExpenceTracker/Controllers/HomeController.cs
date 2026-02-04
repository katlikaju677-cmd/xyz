using Microsoft.AspNetCore.Mvc;
using MoneyExpenceTracker.Models;

namespace MoneyExpenceTracker.Controllers;

public class HomeController : Controller
{
    private readonly LedgerStore _ledger;

    public HomeController(LedgerStore ledger)
    {
        _ledger = ledger;
    }

    public IActionResult Index()
    {
        var viewModel = new LedgerViewModel
        {
            Entries = _ledger.Entries.OrderByDescending(entry => entry.Date).ToList(),
            TotalIncome = _ledger.TotalFor(TransactionType.Income),
            TotalExpense = _ledger.TotalFor(TransactionType.Expense),
            TotalSaving = _ledger.TotalFor(TransactionType.Saving),
            NewEntry = new TransactionEntry()
        };

        return View(viewModel);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Add(LedgerViewModel model)
    {
        if (!ModelState.IsValid)
        {
            model.Entries = _ledger.Entries.OrderByDescending(entry => entry.Date).ToList();
            model.TotalIncome = _ledger.TotalFor(TransactionType.Income);
            model.TotalExpense = _ledger.TotalFor(TransactionType.Expense);
            model.TotalSaving = _ledger.TotalFor(TransactionType.Saving);
            return View("Index", model);
        }

        _ledger.Add(model.NewEntry);
        return RedirectToAction(nameof(Index));
    }
}
