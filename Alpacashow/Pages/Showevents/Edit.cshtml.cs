using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Alpacashow.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Alpacashow.Models;

namespace Alpacashow.Pages.Showevents
{
    public class EditModel : PageModel
    {
        private readonly AlpacashowContext _context;

        public EditModel(AlpacashowContext context)
        {
            _context = context;
        }

        [BindProperty]
        public ShowEvent ShowEvent { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ShowEvent = await _context.ShowEvents.SingleOrDefaultAsync(m => m.ShowEventId == id);

            if (ShowEvent == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(ShowEvent).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ShowEventExists(ShowEvent.ShowEventId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool ShowEventExists(int id)
        {
            return _context.ShowEvents.Any(e => e.ShowEventId == id);
        }
    }
}
