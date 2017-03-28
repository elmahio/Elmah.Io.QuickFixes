using System;

namespace Elmah.Io.QuickFixes.Fixes.Umbraco
{
    public class UmbracoModelBindingBugQuickFix : QuickFixBase
    {
        public UmbracoModelBindingBugQuickFix()
        {
            Icon = "fa-book";
            Text = "Troubleshoot model binding issue";
            Url = new Uri("https://our.umbraco.org/forum/extending-umbraco-and-using-the-api/76178-error-cannot-bind-source-type-type-to-model-type-type");
        }

        public override bool CanFix(Message message)
        {
            return
                !string.IsNullOrWhiteSpace(message.Title) &&
                message.Title.ToLower().StartsWith("cannot bind source type umbraco.web.models.rendermodel to model type");
        }
    }
}