using System;

namespace Elmah.Io.QuickFixes.Fixes
{
    public class WatchVideoAboutMvcParametersQuickFix : QuickFixBase
    {
        public WatchVideoAboutMvcParametersQuickFix()
        {
            Icon = "fa-play";
            Text = "ASP.NET MVC Actions and Parameters video tutorial";
            Url = new Uri("https://app.pluralsight.com/player?author=scott-allen&name=mvc4-building-m2-controllers&mode=live&clip=2&course=mvc4-building");
        }

        public override bool CanFix(Message message)
        {
            if (string.IsNullOrWhiteSpace(message.Title)) return false;
            return
                message.Title.ToLower().Contains("the parameters dictionary contains a null entry for parameter") &&
                message.Title.ToLower()
                    .Contains(
                        "an optional parameter must be a reference type, a nullable type, or be declared as an optional parameter");
        }
    }
}