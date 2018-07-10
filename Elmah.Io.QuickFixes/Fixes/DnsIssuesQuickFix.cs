using System;

namespace Elmah.Io.QuickFixes.Fixes
{
    public class DnsIssuesQuickFix : QuickFixBase
    {
        public DnsIssuesQuickFix()
        {
            Icon = "fa-book";
            Text = "Debugging DNS issues";
            Url = new Uri("https://blog.elmah.io/debugging-system-net-webexception-the-remote-name-could-not-be-resolved/");
        }

        public override bool CanFix(Message message)
        {
            return
                !string.IsNullOrWhiteSpace(message.Detail) &&
                message.Detail.ToLower().IndexOf("the remote name could not be resolved") != -1;
        }
    }
}
