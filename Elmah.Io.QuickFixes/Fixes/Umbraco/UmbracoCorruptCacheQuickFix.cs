using System;

namespace Elmah.Io.QuickFixes.Fixes.Umbraco
{
    public class UmbracoCorruptCacheQuickFix : QuickFixBase
    {
        public UmbracoCorruptCacheQuickFix()
        {
            Icon = "fa-book";
            Text = "Troubleshoot corrupt cache";
            Url = new Uri("https://our.umbraco.org/forum/umbraco-7/using-umbraco-7/73079-xml-cache-data-integrity-check-in-730-what-is-it-and-why-does-the-fix-throw-an-exception");
        }

        public override bool CanFix(Message message)
        {
            return
                !string.IsNullOrWhiteSpace(message.Title) &&
                message.Title.ToLower().StartsWith("the xml cache is corrupt. use the health check data integrity dashboard to fix it");
        }
    }
}