using System;

namespace Elmah.Io.QuickFixes.Fixes
{
    public class SearchGoogleQuickFix : QuickFixBase
    {
        public SearchGoogleQuickFix()
        {
            Icon = "fa-search-plus";
            Text = "Search Google";
        }

        public override bool CanFix(Message message)
        {
            return true;
        }

        public override QuickFixBase Decorate(Message message)
        {
            Url = new Uri("https://www.google.com/search?q=" + message.Title);
            return this;
        }
    }
}