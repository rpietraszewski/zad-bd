using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using zad3.Models;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using zad3.Data;

namespace zad3.Pages
{
    public class IndexModel : PageModel
    {
        
        private readonly ILogger<IndexModel> _logger;
        private readonly PeopleContext _context;
        [BindProperty]
        public Check Check { get; set; }
        public IList<Check> People { get; set; }
        public IList<Check> People2 { get; set; }

        public IndexModel(ILogger<IndexModel> logger, PeopleContext context)
        {
            _logger = logger;
            _context = context;
        }

        public void OnGet()
        {
            
            
        }
        public IActionResult OnPost()
        {
            (ViewData["Message"], ViewData["MessageClass"]) = Check.getOutput();
            People2 = _context.Check.ToList();
            if (ModelState.IsValid)
            {
                var Data = HttpContext.Session.GetString("Data");
                if (Data != null)
                {
                    People = JsonConvert.DeserializeObject<List<Check>>(Data);
                }
                if (People == null)
                    People = new List<Check>();
                People.Add(Check);
                HttpContext.Session.SetString("Data",
                JsonConvert.SerializeObject(People));
                
            }

            _context.Check.Add(Check);
            _context.SaveChanges();
            return RedirectToPage("./Index");
        }

    }
}