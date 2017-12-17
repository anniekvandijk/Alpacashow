using System.Collections.Generic;
using System.Threading.Tasks;
using Alpacashow.Data.Context;
using Alpacashow.Data.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Alpacashow.Mvc.Pages.Showevents
{
    public class IndexModel : PageModel
    {
        private readonly AlpacashowContext _context;

        public IndexModel(AlpacashowContext context)
        {
            _context = context;
        }

        public IList<ShowEvent> ShowEvent { get;set; }

        public async Task OnGetAsync()
        {
            ShowEvent = await _context.ShowEvents.ToListAsync();
        }
    }
}
