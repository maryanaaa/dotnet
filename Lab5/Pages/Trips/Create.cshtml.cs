using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Lab5.Data;
using Lab5.Models;

namespace Lab5.Pages.Trips
{
    public class CreateModel : PageModel
    {
        private readonly Lab5.Data.TravelAgencyContext _context;

        public CreateModel(Lab5.Data.TravelAgencyContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["CustomerID"] = new SelectList(_context.Customers, "ID", "ID");
        ViewData["TourID"] = new SelectList(_context.Tours, "ID", "ID");
            return Page();
        }

        [BindProperty]
        public Trip Trip { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Trips.Add(Trip);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
