using Abby.Data;
using Abby.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Abby.Pages.Categories
{
    public class CreateModel : PageModel
    {
        private readonly ApplicationDBContext _db;
        [BindProperty]
        public Category Category { get; set; }
        public CreateModel(ApplicationDBContext db)
        {
            this._db = db;
        }
        public void OnGet()
        {

        }
        public async Task<IActionResult> OnPost() /// musi Byc "On" i typ akcji OnPostCreate, OnPostHandler
            // dzieki BindPropertry nie trzeba przekazywac w parametrze Category category
        {
            if(Category.Name == Category.DisplayOrder.ToString()) // custom validateon 
            {
                ModelState.AddModelError(string.Empty, "Name cannot be the same like DisplayOrder");
            }
            if(ModelState.IsValid)
            {
                await _db.Category.AddAsync(Category);
                await _db.SaveChangesAsync();
                TempData["success"] = "Category created succesfully";
                return RedirectToPage("Index");
            }
            return Page(); // back to the same page
            
        }
    }
}
