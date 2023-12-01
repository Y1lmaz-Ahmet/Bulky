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
            // Server side Validation
            // Check if Name and Display Order are the same; show an error message if they match
            if (obj.Name == obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("Name", "The Display Order cannot exactly match the Name.");
            }

            // Client side Validation
            // Check if the object is valid based on server-side and any additional client-side validations
            if (ModelState.IsValid)
            {
                // If the object is valid, add a new Category Object to the Database
                _db.Categories.Add(obj);

                // Save changes to the Database
                _db.SaveChanges();

                // Redirect to the List of Categories (refers to Index Action)
                return RedirectToAction("Index");
            }

            return View();
        }
        // edit existing Category object
        public IActionResult Edit(int? id)
        {
            if(id == null || id == 0) 
            {
                return NotFound(); // check if id is higher than 0 and not null
            }
            Category? CategoryFromDb = _db.Categories.Find(id); // find ONLY 1 specific Category object
            //Category? CategoryFromDb2 = _db.Categories.FirstOrDefault(x => x.Id== id);
            //Category? CategoryFromDb3 = _db.Categories.Where(x => x.Id == id).FirstOrDefault();
            if(CategoryFromDb == null) // check if found category exists
            {
                return NotFound();
            }
            return View(CategoryFromDb); // return the View with the found Category
        }
        //create a new Category and add it to the database - [httpPost] for posting in MVC
        [HttpPost]
        public IActionResult Edit(Category obj)
        {
            // Server side Validation
            // Check if Name and Display Order are the same; show an error message if they match
            if (obj.Name == obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("Name", "The Display Order cannot exactly match the Name.");
            }

            // Client side Validation
            // Check if the object is valid based on server-side and any additional client-side validations
            if (ModelState.IsValid)
            {
                // If the object is valid, add a new Category Object to the Database
                _db.Categories.Add(obj);

                // Save changes to the Database
                _db.SaveChanges();

                // Redirect to the List of Categories (refers to Index Action)
                return RedirectToAction("Index");
            }

            return View();
        }
    }
}
