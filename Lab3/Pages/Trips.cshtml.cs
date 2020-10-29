using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Lab3.Data;
using Lab3.Models;

namespace Lab3.Pages
{
    public class TripsModel : PageModel
    {
        private readonly Lab3.Data.TravelAgencyContext _context;

        public TripsModel(Lab3.Data.TravelAgencyContext context)
        {
            _context = context;
        }

        public IList<Trip> Trip { get;set; }

        public async Task OnGetAsync()
        {
            Trip = await _context.Trips
                .Include(t => t.Customer)
                .Include(t => t.Tour).ToListAsync();
        }
    }
}
