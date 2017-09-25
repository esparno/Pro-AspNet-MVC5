using System.Web.Mvc;
using System.Web.Routing;
using System;

namespace ControllersAndActions.Controllers
{
    public class BasicController : IController
    {

        public void Execute(RequestContext requestContext)
        {
            string controller = (string)requestContext.RouteData.Values["controller"];
            var val = requestContext.RouteData.Values;

            string action = (string)requestContext.RouteData.Values["action"];

            requestContext.HttpContext.Response.Write(String.Format("Controller: {0}, Action: {1}", controller, action));
        }
    }
}