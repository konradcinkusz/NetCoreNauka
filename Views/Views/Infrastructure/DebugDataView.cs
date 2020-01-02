using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using System;
using System.Text;
using System.Threading.Tasks;

namespace Views.Infrastructure
{
    public class DebugDataView : IView
    {
        public string Path => String.Empty;

        public async Task RenderAsync(ViewContext context)
        {
            context.HttpContext.Response.ContentType = "text/plain";

            StringBuilder sb = new StringBuilder();

            sb.AppendLine("---Dane routingu.---");
            foreach (var kvp in context.RouteData.Values)
            {
                sb.AppendLine($"Klucz: {kvp.Key}, wartość {kvp.Value}");
            }

            sb.AppendLine("---Dane widoku---");
            foreach (var kvp in context.ViewData)
            {
                sb.AppendLine($"Klucz: {kvp.Key}, wartość {kvp.Value}");
            }

            await context.Writer.WriteAsync(sb.ToString());
        }
    }
}
