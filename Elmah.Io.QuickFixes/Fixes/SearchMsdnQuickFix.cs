using System;

namespace Elmah.Io.QuickFixes.Fixes
{
    public class SearchMsdnQuickFix : QuickFixBase
    {
        public SearchMsdnQuickFix()
        {
            Icon = "fa-windows";
            Text = "Search MSDN Forums";
        }

        public override bool CanFix(Message message)
        {
            return true;
        }

        public override QuickFixBase Decorate(Message message)
        {
            Url = new Uri("https://social.msdn.microsoft.com/Forums/en-US/home?sort=relevancedesc&searchTerm=" + message.Title);
            return this;
        }
    }
}