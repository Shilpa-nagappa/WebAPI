using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;


namespace WebAppSample.Common
{
    public class TrackExecution:ActionFilterAttribute, IExceptionFilter
    {
        //public void OnException(ExceptionContext filterContext)
        //{
        //    throw new NotImplementedException();
        //}
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
         string msg= "\n"+filterContext.ActionDescriptor.ControllerDescriptor.ControllerName + 
                "========>"+ filterContext.ActionDescriptor.ActionName + "=====>" + "=====> OnActionExecuting \t-" + DateTime.Now.ToString() + "\n";
            LogExecutionTime(msg);
        }
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            string msg = filterContext.ActionDescriptor.ControllerDescriptor.ControllerName +
               "========>" + filterContext.ActionDescriptor.ActionName + "=====>" + "=====> OnActionExecuted \t-" + DateTime.Now.ToString() + "\n";
            LogExecutionTime(msg);
        }
        public override void OnResultExecuting(ResultExecutingContext filterContext)
        {
            string msg = filterContext.RouteData.Values["controller"].ToString()+
               "========>" + filterContext.RouteData.Values["action"].ToString() + "=====>" + "=====> OnResultExecuting \t-" + DateTime.Now.ToString() + "\n";
            LogExecutionTime(msg);
            LogExecutionTime("-----------------------------------------");
        }
        public override void OnResultExecuted(ResultExecutedContext filterContext)
        {
            string msg = filterContext.RouteData.Values["controller"].ToString() +
                "========>" + filterContext.RouteData.Values["action"].ToString() + "=====>" + "=====> OnResultExecuted \t-" + DateTime.Now.ToString() + "\n";
            LogExecutionTime(msg);
            LogExecutionTime("-----------------------------------------");
        }

        public void OnException(ExceptionContext filterContext)
        {
            string msg = filterContext.RouteData.Values["controller"].ToString() +
               "========>" + filterContext.RouteData.Values["action"].ToString() + "=====>" +filterContext.Exception.Message+ "\t-"+ DateTime.Now.ToString() + "\n";
            LogExecutionTime(msg);
            LogExecutionTime("-----------------------------------------");
        }
        private void LogExecutionTime(string data )
        {
            File.AppendAllText(HttpContext.Current.Server.MapPath("~/Data/Data.txt"), data);

        }
    }
}