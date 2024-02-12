using System.Linq;
using Microsoft.AspNetCore.Mvc;
using YourNamespace.Models;

public class InsureeController : Controller
{
    private readonly YourDbContext _context;

    public InsureeController(YourDbContext context)
    {
        _context = context;
    }

    public IActionResult Index()
    {
        // Add any necessary logic for the Index action
        return View();
    }

    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create(Insuree insuree)
    {
        if (ModelState.IsValid)
        {
            decimal quote = 50;

            // ... (add the quote calculation logic here)

            insuree.Quote = quote;
            _context.Insurees.Add(insuree);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        return View(insuree);
    }

    public IActionResult Admin()
    {
        var allQuotes = _context.Insurees
            .Select(i => new { i.FirstName, i.LastName, i.Email, i.Quote })
            .ToList();

        return View(allQuotes);
    }
}
