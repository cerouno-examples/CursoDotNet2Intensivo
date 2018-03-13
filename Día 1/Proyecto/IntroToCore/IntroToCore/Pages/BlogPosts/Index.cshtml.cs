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
    public class IndexModel : PageModel
    {
        private readonly IntroToCore.Data.ApplicationDbContext _context;

        public IndexModel(IntroToCore.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<BlogPost> BlogPost { get;set; }

        public async Task OnGetAsync()
        {
            BlogPost = await _context.BlogPost.ToListAsync();
        }
    }
}
