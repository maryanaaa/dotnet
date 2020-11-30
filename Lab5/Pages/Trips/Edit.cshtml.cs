using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Lab5.Data;
using Lab5.Models;

namespace Lab5.Pages.Trips
{
    public class EditModel : PageModel
    {
        private readonly Lab5.Data.TravelAgencyContext _context;

        public EditModel(Lab5.Data.TravelAgencyContext context)
        {
            _context = context;
        }

        [BindProperty]
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
           ViewData["CustomerID"] = new SelectList(_context.Customers, "ID", "ID");
           ViewData["TourID"] = new SelectList(_context.Tours, "ID", "ID");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Trip).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TripExists(Trip.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool TripExists(int id)
        {
            return _context.Trips.Any(e => e.ID == id);
        }
    }
}
