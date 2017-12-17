using System.Threading.Tasks;
using Alpacashow.Data.Context;
using Alpacashow.Data.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Alpacashow.Mvc.Pages.Showevents
{
    public class DeleteModel : PageModel
    {
        private readonly AlpacashowContext _context;

        public DeleteModel(AlpacashowContext context)
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ShowEvent = await _context.ShowEvents.FindAsync(id);

            if (ShowEvent != null)
            {
                _context.ShowEvents.Remove(ShowEvent);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
