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
    public class ToursModel : PageModel
    {
        private readonly Lab3.Data.TravelAgencyContext _context;

        public ToursModel(Lab3.Data.TravelAgencyContext context)
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
