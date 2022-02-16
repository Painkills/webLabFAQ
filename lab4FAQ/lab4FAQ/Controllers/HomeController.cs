using lab4FAQ.Models;
using lab5FAQ.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace lab4FAQ.Controllers
{
    public class HomeController : Controller
    {
        private FaqContext context { get; set; }

        public HomeController(FaqContext ctx)
        {
            context = ctx;
        }

        public IActionResult Index(string topic, string category)
        {
            ViewBag.Topics = context.Topics.OrderBy(t => t.TopicName).ToList();
            ViewBag.Categories = context.Categories.OrderBy(c => c.CategoryName).ToList();

            IQueryable<FAQ> faqs = context.FAQs.
                Include(t => t.Topic).
                Include(c => c.Category).
                OrderBy(f => f.Question);

            if (!string.IsNullOrEmpty(topic))
            {
                faqs = faqs.Where(f => f.TopicId == topic);
            }

            if (!string.IsNullOrEmpty(category))
            {
                faqs = faqs.Where(f => f.CategoryId == category);
            }

            return View(faqs.ToList());
        }

        
    }
}