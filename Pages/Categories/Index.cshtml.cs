using Abby.Data;
using Abby.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Abby.Pages.Categories
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDBContext _db;
        public IEnumerable<Category> Categories { get; set; }

        public IndexModel(ApplicationDBContext db)
        {
            this._db = db;
        }
        public void OnGet() // nazwa domyslna , bez niej nie dziala
        {
            Categories = _db.Category;
        }
    }
}
