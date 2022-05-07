#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using zad3.Data;
using zad3.Models;

namespace zad3.Pages
{
    public class UsuwanieModel : PageModel
    {
        private readonly zad3.Data.PeopleContext _context;

        public UsuwanieModel(zad3.Data.PeopleContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Check Check { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Check = await _context.Check.FirstOrDefaultAsync(m => m.Id == id);

            if (Check == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Check = await _context.Check.FindAsync(id);

            if (Check != null)
            {
                _context.Check.Remove(Check);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
