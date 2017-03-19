using System;
using System.Collections.Generic;

namespace Elmah.Io.QuickFixes.Fixes
{
    public class MsdnDocumentationQuickFix : QuickFixBase
    {
        public MsdnDocumentationQuickFix()
        {
            Icon = "fa-book";
        }

        public override bool CanFix(Message message)
        {
            return !string.IsNullOrWhiteSpace(message.Type) && message.Type.ToLower().StartsWith("system.");
        }

        public override QuickFixBase Decorate(Message message)
        {
            Url = new Uri($"https://msdn.microsoft.com/en-us/library/{message.Type.ToLower()}.aspx");
            Text = $"Documentation for {message.Type}";
            return this;
        }
    }
}