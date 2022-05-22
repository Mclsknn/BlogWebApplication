using BlogWebApplicationEntities.Concrete;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;
using System;
using BlogWebApplication.Business.Abstract;
using System.Threading.Tasks;

namespace BlogWebApplication.Web.Controllers
{
    public class CommentController : Controller
    {
        ICommentService _commentService;
        public CommentController(ICommentService commentService)
        {
            _commentService = commentService;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult CommentPartial() 
        {
            int BlogID = Convert.ToInt32(HttpContext.Session.GetString("BlogID"));
            var comments = _commentService.GetCommentsByBlogID(BlogID);
            return View(comments);
        }
        public async Task<IActionResult> CommentAdd(int blogID, Comment comment) 
        {
            int id = Convert.ToInt32(HttpContext.Session.GetString("UserID"));
            comment.UserID = id;
            comment.BlogID = blogID;
            bool success = await _commentService.AddAsync(comment);
            return View();
        }
    }
}
