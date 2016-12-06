using System;

namespace Elmah.Io.QuickFixes.Fixes
{
    public class SearchStackOverflowQuickFix : QuickFixBase
    {
        public SearchStackOverflowQuickFix()
        {
            Icon = "fa-stack-overflow";
            Text = "Search Stack Overflow";
        }

        public override bool CanFix(Message message)
        {
            return true;
        }

        public override QuickFixBase Decorate(Message message)
        {
            Url = new Uri("http://stackoverflow.com/search?q=" + message.Title);
            return this;
        }
    }
}