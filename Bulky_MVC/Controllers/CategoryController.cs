using Bulky_MVC.Data;
using Bulky_MVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace Bulky_MVC.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _db; // accessing database 
        public CategoryController(ApplicationDbContext db)
        {
            _db = db; // make instance of database & set property 
        }
        public IActionResult Index()
        {
            List<Category> objCategoryList = _db.Categories.ToList(); // make a list of categorie objects
            return View(objCategoryList); // show the categorie objects in the Index View
        }

        //return the View for CreateCategory
        public IActionResult Create()
        {
            return View();
        }
        //create a new Category and add it to the database - [httpPost] for posting in MVC
        [HttpPost]
        public IActionResult Create(Category obj) 
        { 
            if(obj.Name == obj.DisplayOrder.ToString()) // if Name en Displayorder are the same show error message
            {
                ModelState.AddModelError("Name", "The Display Order cannot exactly match the Name.");
            }
            

            if(ModelState.IsValid) // check if the object is valid
            {
                _db.Categories.Add(obj); // add a new Category Object to the Database
                _db.SaveChanges(); // Go to the Database and Save the new Object
                return RedirectToAction("Index"); // return to the List of Categories, refers to Index Action
            }
            return View();
        }
    }
}
