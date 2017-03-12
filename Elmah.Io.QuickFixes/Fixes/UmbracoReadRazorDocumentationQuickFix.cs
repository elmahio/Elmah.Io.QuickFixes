namespace Elmah.Io.QuickFixes.Fixes
{
    public class UmbracoReadRazorDocumentationQuickFix : QuickFixBase
    {
        public UmbracoReadRazorDocumentationQuickFix()
        {
            Icon = "fa-book";
            Text = "Troubleshoot Razor errors";
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