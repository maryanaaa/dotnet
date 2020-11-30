using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Lab5.Data;
using Lab5.Models;

namespace Lab5.Pages.Trips
{
    public class DetailsModel : PageModel
    {
        private readonly Lab5.Data.TravelAgencyContext _context;

        public DetailsModel(Lab5.Data.TravelAgencyContext context)
        {
            _context = context;
        }

        public Trip Trip { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Trip = await _context.Trips
                .Include(t => t.Customer)
                .Include(t => t.Tour).FirstOrDefaultAsync(m => m.ID == id);

            if (Trip == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
