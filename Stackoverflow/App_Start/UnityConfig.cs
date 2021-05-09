using System.Web.Http;
using System.Web.Mvc;
using StackOverflow.ServiceLayer;
using StackOverflow.ServiceLayer.Interfaces;
using Unity;

namespace Stackoverflow
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
            var container = new UnityContainer();
            container.RegisterType<IQuestionService, QuestionService>();
            container.RegisterType<IUsersService, UsersService>();
            //Enable dependency injection for MVC5 ↓↓↓↓↓↓↓↓↓↓
            DependencyResolver.SetResolver(new Unity.Mvc5.UnityDependencyResolver(container));
            //Enable dependency injection for Web API ↓↓↓↓↓↓
            GlobalConfiguration.Configuration.DependencyResolver = new Unity.WebApi.UnityDependencyResolver(container);
        }
    }
}
