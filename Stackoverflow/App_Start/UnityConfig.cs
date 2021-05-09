using System.Web.Http;
using System.Web.Mvc;
using StackOverflow.ServiceLayer;
using StackOverflow.ServiceLayer.Interfaces;
using Unity;
using Unity.WebApi;

namespace Stackoverflow
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
            var container = new UnityContainer();
            container.RegisterType<IQuestionService, QuestionService>();
            //Enable dependency injection for MVC5 ↓↓↓↓↓↓↓↓↓↓
            DependencyResolver.SetResolver(new Unity.Mvc5.UnityDependencyResolver(container));
            //Enable dependency injection for Web API ↓↓↓↓↓↓
            GlobalConfiguration.Configuration.DependencyResolver = new Unity.WebApi.UnityDependencyResolver(container);
        }
    }
}
