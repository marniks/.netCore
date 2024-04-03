using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Refresher_Temp.Data;
using Refresher_Temp.Model;

namespace Refresher_Temp.Pages.Categories
{
    [BindProperties]
    public class DeleteModel : PageModel
    {
        private readonly ApplicationDbContext _db;
        public DeleteModel(ApplicationDbContext db)
        {
            _db = db;
        }
        public Category Category { get; set; }
        public void OnGet(int? id)
        {
            if(id == null || id != 0)
            {
                Category = _db.Categories.Find(id);
            }
        }

        
        public IActionResult OnPost()
        {
           Category obj = _db.Categories.Find(Category.Id);
            if(obj == null)
            {
                return NotFound();
            }
            _db.Categories.Remove(obj);
            _db.SaveChanges();
            TempData["success"] = "Category Deleted Successfully";
            return RedirectToPage("Index");
        }

    }
}
