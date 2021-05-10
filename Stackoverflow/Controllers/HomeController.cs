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

        public HomeController(IQuestionService questionService)
        {
            _questionService = questionService;
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
    }
}