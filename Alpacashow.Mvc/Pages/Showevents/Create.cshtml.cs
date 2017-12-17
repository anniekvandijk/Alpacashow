using System.Threading.Tasks;
using Alpacashow.Data.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Alpacashow.Data.Models;

namespace Alpacashow.Mvc.Pages.Showevents
{
    public class CreateModel : PageModel
    {
        private readonly AlpacashowContext _context;

        public CreateModel(AlpacashowContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public ShowEvent ShowEvent { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.ShowEvents.Add(ShowEvent);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}