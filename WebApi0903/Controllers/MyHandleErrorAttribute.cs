using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Filters;

namespace WebApi0903.Controllers
{
    public class MyHandleErrorAttribute : ExceptionFilterAttribute
    {
        public override void OnException(HttpActionExecutedContext actionExecutedContext)
        {
            actionExecutedContext.Response = new HttpResponseMessage() {
                StatusCode = HttpStatusCode.InternalServerError,
                Content = new ObjectContent<MyErrorObject>(
                                    new MyErrorObject()
                                    {
                                        Error_Code = 1,
                                        Error_Message = "Hello My Bad"
                                    },
                                    GlobalConfiguration.Configuration.Formatters.JsonFormatter)
            };
        }
    }
}