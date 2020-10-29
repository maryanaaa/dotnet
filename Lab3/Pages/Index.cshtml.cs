using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lab3.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace Lab3.Pages
{
    public class IndexModel : PageModel
    {
        public TravelAgencyContext DbContext { get; }

        public IndexModel(TravelAgencyContext context)
        {
            DbContext = context;
        }
    }
}