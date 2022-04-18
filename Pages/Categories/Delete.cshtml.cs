using Abby.Data;
using Abby.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Abby.Pages.Categories
{
    public class DeleteModel : PageModel
    {
        private readonly ApplicationDBContext _db;
        [BindProperty]
        public Category Category { get; set; }
        public DeleteModel(ApplicationDBContext db)
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
            
            
                var categoryFromDb = _db.Category.Find(Category.Id);
                if (categoryFromDb != null)
                {
                    _db.Category.Remove(categoryFromDb);
                    await _db.SaveChangesAsync();
                TempData["success"] = "Categpry deleted succesfully";
                return RedirectToPage("Index");
                }
                
            
            return Page(); // back to the same page
            
        }
    }
}
