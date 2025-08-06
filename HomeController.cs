using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using sample1.Models;
using Microsoft.EntityFrameworkCore;

namespace sample1.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly RfqDbContext _context;

        public HomeController(ILogger<HomeController> logger, RfqDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Rfq()
        {
            var rfqList = _context.Rfqs.ToList();
            return View(rfqList);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Rfq(Rfq rfq)
        {
            if (ModelState.IsValid)
            {
                _context.Rfqs.Add(rfq);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(rfq);
        }

        
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rfq = await _context.Rfqs.FindAsync(id);
            if (rfq == null)
            {
                return NotFound();
            }
            return View(rfq);
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Rfq rfq)
        {
            if (ModelState.IsValid)
            {
                _context.Update(rfq);
                await _context.SaveChangesAsync();
                return RedirectToAction("Rfq");
            }
            return View(rfq);
        }

        
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var rfq = await _context.Rfqs.FindAsync(id);
            if (rfq != null)
            {
                _context.Rfqs.Remove(rfq);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction("Rfq");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}