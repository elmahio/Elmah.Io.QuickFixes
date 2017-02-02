using System;

namespace Elmah.Io.QuickFixes.Fixes
{
    public class WatchVideoAboutMvcRoutesAndControllersQuickFix : QuickFixBase
    {
        public WatchVideoAboutMvcRoutesAndControllersQuickFix()
        {
            Icon = "fa-play";
            Text = "ASP.NET MVC Routes and Controllers video tutorial";
            Url = new Uri("https://app.pluralsight.com/player?author=scott-allen&name=mvc4-building-m2-controllers&mode=live&clip=1&course=mvc4-building");
        }

        public override bool CanFix(Message message)
        {
            if (string.IsNullOrWhiteSpace(message.Title)) return false;
            return
                message.Title.ToLower().Contains("the controller for path") &&
                message.Title.ToLower().Contains("was not found or does not implement icontroller");
        }
    }
}