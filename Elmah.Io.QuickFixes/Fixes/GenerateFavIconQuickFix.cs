using System;

namespace Elmah.Io.QuickFixes.Fixes
{
    public class GenerateFavIconQuickFix : QuickFixBase
    {
        public GenerateFavIconQuickFix()
        {
            Icon = "fa-picture-o";
            Text = "Generate Favicon";
            Url = new Uri("https://realfavicongenerator.net/");
        }

        public override bool CanFix(Message message)
        {
            return
                message.StatusCode.HasValue &&
                message.StatusCode.Value == 404 && 
                !string.IsNullOrWhiteSpace(message.Url) &&
                (message.Url.ToLower().IndexOf("favicon") != -1 ||
                 message.Url.ToLower().IndexOf("apple-touch-icon") != -1);
        }
    }
}