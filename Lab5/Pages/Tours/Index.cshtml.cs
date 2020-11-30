using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Lab5.Data;
using Lab5.Models;

namespace Lab5.Pages.Tours
{
    public class IndexModel : PageModel
    {
        private readonly Lab5.Data.TravelAgencyContext _context;

        public IndexModel(Lab5.Data.TravelAgencyContext context)
        {
            _context = context;
        }

        public IList<Tour> Tour { get;set; }

        public async Task OnGetAsync()
        {
            Tour = await _context.Tours.ToListAsync();
        }
    }
}
