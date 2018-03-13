using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using IntroToCore.Data;

namespace IntroToCore.Pages.BlogPosts
{
    public class DetailsModel : PageModel
    {
        private readonly IntroToCore.Data.ApplicationDbContext _context;

        public DetailsModel(IntroToCore.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public BlogPost BlogPost { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            BlogPost = await _context.BlogPost.SingleOrDefaultAsync(m => m.Id == id);

            if (BlogPost == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
