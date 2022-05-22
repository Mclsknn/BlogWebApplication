using BlogWebApplication.Business.Abstract;
using BlogWebApplication.Web.Models;
using BlogWebApplicationEntities.Concrete;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BlogWebApplication.Web.Controllers
{
    public class WriterController : Controller
    {
        private readonly IWriterService _writerService;
        bool success;
        public WriterController(IWriterService writerService)
        {
            _writerService = writerService;
        }
        public async Task<IActionResult> Index()
        {
            var writers = await _writerService.GetAllAsync();
            return View(writers);
        }
        [HttpGet]
        public async Task<IActionResult> WriterList()
        {
            var writers = await _writerService.GetAllAsync();
            return View(writers);
        }
        [HttpGet]
        public IActionResult WriterAdd()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> WriterAdd(Writer writer)
        {
            if (ModelState.IsValid)
            {
                success = await _writerService.AddAsync(writer);
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
            success = await _writerService.SoftDeleteAsync(id);
            if (success)
            {
                return Json(new JsonReturnObject { text = "Veri başarılı bir şekilde silindi !", success = true });
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var category = await _writerService.GetByID(id);
            return View(category);
        }
        [HttpPost]
        public IActionResult Edit(Writer writer)
        {
            success = _writerService.Update(writer);
            if (success)
            {
                return Json(new JsonReturnObject { text = "Veri başarılı bir şekilde güncellendi !", success = true });
            }
            return View();
        }

    }
}
