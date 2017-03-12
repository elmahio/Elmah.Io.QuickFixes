using System;

namespace Elmah.Io.QuickFixes.Fixes
{
    public class UmbracoReadRazorDocumentationQuickFix : QuickFixBase
    {
        public UmbracoReadRazorDocumentationQuickFix()
        {
            Icon = "fa-book";
            Text = "Learn about Razor in Umbraco";
            Url = new Uri("https://our.umbraco.org/documentation/Reference/Templating/Mvc/");
        }

        public override bool CanFix(Message message)
        {
            return !string.IsNullOrWhiteSpace(message.Type)
                   && !string.IsNullOrWhiteSpace(message.Detail)
                   && message.Type.Equals("System.Web.HttpCompileException")
                   && message.Detail.Contains("Umbraco.Core.Profiling.ProfilingView.Render");
        }
    }
}