using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StackOverflow.ServiceLayer.Interfaces;
using StackOverflow.ViewModels;

namespace Stackoverflow.Controllers
{
    public class HomeController : Controller
    {
        private readonly IQuestionService _questionService;
        private readonly ICategoryService _categoryService;

        public HomeController(IQuestionService questionService,ICategoryService categoryService)
        {
            _questionService = questionService;
            _categoryService = categoryService;
        }
        public ActionResult Index()
        {
            List<QuestionViewModel> questionViewModels = _questionService.GetQuestions().Take(10).ToList();

            return View(questionViewModels);
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }

        public ActionResult Categories()
        {
            List<CategoryViewModel> categories = _categoryService.GetCategories();
            return View(categories);
        }

        public ActionResult Questions()
        {
            List<QuestionViewModel> questionViewModels = _questionService.GetQuestions();
            return View(questionViewModels);
        }
    }
}