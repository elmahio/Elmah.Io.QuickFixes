using System;

namespace Elmah.Io.QuickFixes.Fixes
{
    public class RenewSslCertificateQuickFix : QuickFixBase
    {
        public RenewSslCertificateQuickFix()
        {
            Icon = "fa-lock";
            Url = new Uri("http://whichssl.com/comparisons/all-certificates.html");
            Text = "Renew SSL certificate";
        }

        public override bool CanFix(Message message)
        {
            return message?.Source?.Equals("SSL Checker") ?? false;
        }
    }
}
