using Abby.Data;
using Abby.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Abby.Pages.Categories
{
    public class EditModel : PageModel
    {
        private readonly ApplicationDBContext _db;
        [BindProperty]
        public Category Category { get; set; }
        public EditModel(ApplicationDBContext db)
        {
            this._db = db;
        }
        public void OnGet(int id)
        {
            Category = _db.Category.Find(id);

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
                _db.Category.Update(Category);
                await _db.SaveChangesAsync();
                TempData["success"] = "Category edited succesfully";
                return RedirectToPage("Index");
            }
            return Page(); // back to the same page
            
        }
    }
}
