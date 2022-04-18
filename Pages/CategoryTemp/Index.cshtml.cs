﻿#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Abby.Data;
using Abby.Model;

namespace Abby.Pages.CategoryTemp
{
    public class IndexModel : PageModel
    {
        private readonly Abby.Data.ApplicationDBContext _context;

        public IndexModel(Abby.Data.ApplicationDBContext context)
        {
            _context = context;
        }

        public IList<Category> Category { get;set; }

        public async Task OnGetAsync()
        {
            Category = await _context.Category.ToListAsync();
        }
    }
}
