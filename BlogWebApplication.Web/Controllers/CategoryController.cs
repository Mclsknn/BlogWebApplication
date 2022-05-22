using BlogWebApplication.Business.Abstract;
using BlogWebApplication.Web.Models;
using BlogWebApplicationEntities.Concrete;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BlogWebApplication.Web.Controllers
{
    public class CategoryController : Controller
    {
        ICategoryService _categoryService;
        bool success;
        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> CategoryList()
        {
            var categories = await _categoryService.GetAllAsync();
            return View(categories);
        }
        [HttpGet]
        public IActionResult CategoryAdd() 
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CategoryAdd(Category category)
        {
            if (ModelState.IsValid)
            {
                success = await _categoryService.AddAsync(category);
                if (success)
                {
                    return Json(new JsonReturnObject { text = "Veri başarılı bir şekilde eklendi !", success = true });
                }
            }
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> Delete(int id) 
        {
            success = await _categoryService.SoftDeleteAsync(id);
            if (success)
            {
                return Json(new JsonReturnObject { text = "Veri başarılı bir şekilde silindi !", success = true });
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id) 
        {
            var category = await _categoryService.GetByID(id);
            return View(category);
        }
        [HttpPost]
        public IActionResult Edit(Category category)
        {
            success = _categoryService.Update(category);
            if (success)
            {
                return Json(new JsonReturnObject { text = "Veri başarılı bir şekilde güncellendi !", success = true });
            }
            return View();
        }
        public IActionResult CategoryPartial()
        { 
            Category c = new Category();
            c.CategoryName = "ali";  
            return View(c);
        }
    }
}
