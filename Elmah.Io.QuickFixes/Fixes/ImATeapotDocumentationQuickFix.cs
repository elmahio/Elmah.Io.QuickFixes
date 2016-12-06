using System;

namespace Elmah.Io.QuickFixes.Fixes
{
    public class ImATeapotDocumentationQuickFix : QuickFixBase
    {
        public ImATeapotDocumentationQuickFix()
        {
            Icon = "fa-coffee";
            Url = new Uri("https://en.wikipedia.org/wiki/Hyper_Text_Coffee_Pot_Control_Protocol");
            Text = "One does not simply brew a cup of tea";
        }

        public override bool CanFix(Message message)
        {
            return message.StatusCode.HasValue && message.StatusCode.Value == 418;
        }
    }
}