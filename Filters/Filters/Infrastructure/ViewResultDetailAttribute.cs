using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Filters.Infrastructure
{
    public class ViewResultDetailAttribute : ResultFilterAttribute
    {
        public override async Task OnResultExecutionAsync(ResultExecutingContext context, ResultExecutionDelegate next)
        {
            Dictionary<string, string> dict = new Dictionary<string, string>
            {
                ["Typ wyniku"] = context.Result.GetType().Name
            };

            ViewResult vr;
            if ((vr = context.Result as ViewResult) != null)
            {
                dict["Nazwa widoku"] = vr.ViewName;
                dict["Typ modelu"] = vr.ViewData.Model.GetType().Name;
                dict["Dane modelu"] = vr.ViewData.Model.ToString();
            }

            context.Result = new ViewResult
            {
                ViewName = "Message",
                ViewData = new Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary(new EmptyModelMetadataProvider(), new ModelStateDictionary()) { Model = dict }
            };

            await next();
        }
    }
}
