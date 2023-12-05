using Bulky.DataAccess.Repository.IRepository;
using Bulky.Models;
using BulkyBook.DataAccess.Repository;
using BulkyBook.DataAccess.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;

namespace Bulky_MVC.Controllers
{
    public class CategoryController : Controller
    {
        private readonly IUnitOfWork _unitOfWork; // accessing database 
        public CategoryController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork; // make instance of database & set property 
        }
        public IActionResult Index()
        {
            List<Category> objCategoryList =_unitOfWork.Category.GetAll().ToList(); // make a list of categorie objects
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
                _unitOfWork.Category.Add(obj);

                // Save changes to the Database
                _unitOfWork.Save();
                TempData["succes"] = "Category created succesfully!";
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
            Category? CategoryFromDb = _unitOfWork.Category.Get(u => u.Id == id); // find ONLY 1 specific Category object
            //Category? CategoryFromDb2 = _db.Categories.FirstOrDefault(x => x.Id== id);
            //Category? CategoryFromDb3 = _db.Categories.Where(x => x.Id == id).FirstOrDefault();
            if(CategoryFromDb == null) // check if found category exists
            {
                return NotFound();
            }
            return View(CategoryFromDb); // return the View with the found Category
        }
        //Take the selected Category; Show it in a new UI with its data; Edit Category & Update it;
        [HttpPost]
        public IActionResult Edit(Category obj)
        {
            // Client side Validation
            // Check if the object is valid based on server-side and any additional client-side validations
            if (ModelState.IsValid)
            {
                // If the object is valid, Update Category Object and send it to the database
                _unitOfWork.Category.Update(obj);

                // Save changes to the Database
                _unitOfWork.Save();
                TempData["succes"] = "Category Updated succesfully!";
                // Redirect to the List of Categories (refers to Index Action)
                return RedirectToAction("Index");
            }

            return View();
        }
        // Delete existing Category object
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound(); // check if id is higher than 0 and not null
            }
            Category? CategoryFromDb = _unitOfWork.Category.Get(u => u.Id == id); // find ONLY 1 specific Category object
            if (CategoryFromDb == null) // check if found category exists
            {
                return NotFound();
            }
            return View(CategoryFromDb); // return the View with the found Category
        }
        //Remove a Category object by its Id
        [HttpPost,ActionName("Delete")]
        public IActionResult DeletePost(int? id)
        {
            // Client side Validation
            // Check if the object is valid based on server-side and any additional client-side validations
            Category? obj = _unitOfWork.Category.Get(u => u.Id == id); // find the specifik Category object
            if (obj == null) // object doesn't exist
            {
                return NotFound();
            }
            // remove the object from the database
            _unitOfWork.Category.Remove(obj);

            // save the database with the removed Category object
            _unitOfWork.Save();
            TempData["succes"] = "Category Removed succesfully!";
            // Redirect to the List of Categories (refers to Index Action)
            return RedirectToAction("Index");
            

            
        }
    }
}
