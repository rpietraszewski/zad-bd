using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using zad3.Data;
using zad3.Models;
using System.Linq;

namespace zad3.Pages
{
    public class OstatnieModel : PageModel
    {
        private readonly ILogger<OstatnieModel> _logger;
        private readonly PeopleContext _context;
        public OstatnieModel(ILogger<OstatnieModel> logger, PeopleContext context)
        {
            _logger = logger;
            _context = context;
        }
        public IList<Check> People2 { get; set; }
        public void OnGet()
        {
            People2 = _context.Check.Take(20).OrderByDescending(x => x.Now).ToList();
        }
    }
}
