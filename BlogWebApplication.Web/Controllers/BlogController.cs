using BlogWebApplication.Business.Abstract;
using BlogWebApplication.Web.Models;
using BlogWebApplicationEntities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlogWebApplication.Web.Controllers
{
    public class BlogController : Controller
    {
        private readonly IBlogService _blogService;
        private readonly IWriterService _writerService;
        private readonly ICategoryService _categoryService;
        bool success;
        public BlogController(IBlogService blogService, IWriterService writerService, ICategoryService categoryService)
        {
            _blogService = blogService;
            _writerService = writerService;
            _categoryService = categoryService;
        }
        public async Task<IActionResult> Index()
        {
            var blogs = await _blogService.GetAllAsync();
            return View(blogs);
        }

        public async Task<IActionResult> BlogDetail(int id)
        {
            var blog = await _blogService.GetByID(id);
            HttpContext.Session.SetString("BlogID", id.ToString());
            return View(blog);
        }
        [HttpGet]
        public async Task<IActionResult> BlogAdd()
        {
            ViewBag.SelectedCategories = await GetCategoriesForDropDown();
            ViewBag.SelectedWriters = await GetWritersForDropDown();
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> BlogAdd(Blog blog) 
        {
            success = await _blogService.AddAsync(blog);
            if (success)
            {
                return Json(new JsonReturnObject { text="Kayıt işlemi başarılı !", success = true });
            }
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var blog = await _blogService.GetByID(id);
            ViewBag.SelectedCategories = await GetCategoriesForDropDown();
            ViewBag.SelectedWriters = await GetWritersForDropDown();
            return View(blog);
        }
        [HttpPost]
        public IActionResult Edit(Blog blog) 
        {
            if (ModelState.IsValid)
            {
                success = _blogService.Update(blog);
                if (success)
                {
                    return RedirectToAction(nameof(BlogList));
                }
            }
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> Delete(int id) 
        {
            success =await _blogService.SoftDeleteAsync(id);
            if (success)
            {
                return Json(new JsonReturnObject { text = "Silme işlemi Başarılı", success = true });
            }
            return View();
        }
        public async Task<IActionResult> BlogList() 
        {
            var blogs = await _blogService.GetAllAsync();
            return View(blogs);
        }
        public async Task<List<SelectListItem>> GetWritersForDropDown()
        {

            var selectedWriters = new List<SelectListItem>();
            var items = await _writerService.GetAllAsync();
            foreach (var item in items)
            {
                selectedWriters.Add
                    (
                    new SelectListItem { Text = item.WriterName, Value = item.WriterID.ToString() }
                    );
            }
            return selectedWriters;
        }
        public async Task<List<SelectListItem>> GetCategoriesForDropDown()
        {

            var selectedCategories = new List<SelectListItem>();
            var items = await _categoryService.GetAllAsync();
            foreach (var item in items)
            {
                selectedCategories.Add
                    (
                    new SelectListItem { Text = item.CategoryName, Value = item.CategoryID.ToString() }
                    );
            }
            return selectedCategories;
        }
    }
}
