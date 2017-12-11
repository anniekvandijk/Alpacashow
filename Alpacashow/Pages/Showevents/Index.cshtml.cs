using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Alpacashow.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Alpacashow.Models;

namespace Alpacashow.Pages.Showevents
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
