using System;

namespace Elmah.Io.QuickFixes.Fixes
{
    public class DownloadResharperQuickFix : QuickFixBase
    {
        public DownloadResharperQuickFix()
        {
            Icon = "fa-download";
            Url = new Uri("https://www.jetbrains.com/resharper/");
            Text = "Download ReSharper to help identify nulls";
        }

        public override bool CanFix(Message message)
        {
            return !string.IsNullOrWhiteSpace(message.Type) &&
                   (message.Type == "System.ArgumentNullException" || message.Type == "System.NullReferenceException");
        }
    }
}