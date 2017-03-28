using System;

namespace Elmah.Io.QuickFixes.Fixes.Umbraco
{
    public class UmbracoReadCustomControllersDocumentationQuickFix : QuickFixBase
    {
        public UmbracoReadCustomControllersDocumentationQuickFix()
        {
            Icon = "fa-book";
            Text = "Learn about custom controllers in Umbraco";
            Url = new Uri("https://our.umbraco.org/documentation/reference/routing/custom-controllers");
        }

        public override bool CanFix(Message message)
        {
            return
                !string.IsNullOrWhiteSpace(message.Title) &&
                message.Title.ToLower().Contains("custom controllers for umbraco routing must implement");
        }
    }
}