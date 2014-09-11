using System.Web.Mvc;
using LetsGoOut.Controllers;
using Simple.Data;

namespace LetsGoOut.ActionFilters
{
    public class SimpleDataActionFilter: ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            (filterContext.Controller as IDataBaseContainer).DataBase = Database.Open();
        }
    }
}