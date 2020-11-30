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
    public class DetailsModel : PageModel
    {
        private readonly Lab5.Data.TravelAgencyContext _context;

        public DetailsModel(Lab5.Data.TravelAgencyContext context)
        {
            _context = context;
        }

        public Tour Tour { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Tour = await _context.Tours.FirstOrDefaultAsync(m => m.ID == id);

            if (Tour == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
