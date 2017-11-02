using System;

namespace Elmah.Io.QuickFixes.Fixes
{
    public class CertificateQuickFix : QuickFixBase
    {
        public CertificateQuickFix()
        {
            Icon = "fa-unlock-alt";
            Url = new Uri("https://en.wikipedia.org/wiki/Certificate_authority");
            Text = "Purchase a valid SSL certificate";
        }

        public override bool CanFix(Message message)
        {
            if (string.IsNullOrWhiteSpace(message.Detail)) return false;
            return message
                .Detail
                .ToLower()
                .Contains("could not establish trust relationship for the ssl/tls secure channel");
        }
    }
}