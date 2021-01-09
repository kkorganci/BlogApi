using BlogApi.Models;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogApi.Helpers.Filters
{
    public class CustomAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext actionContext)
        {
            string parameter = "keyData";
            if (actionContext.ActionArguments == null || !actionContext.ActionArguments.ContainsKey(parameter))
                throw new Exception(string.Format("parametre '{0}' mevcut değil", parameter));

            Blogs model = actionContext.ActionArguments[parameter] as Blogs;

            if (String.IsNullOrEmpty(model.Name))
                throw new Exception("Aranılan data bulunamadı");

        }
    }
}
