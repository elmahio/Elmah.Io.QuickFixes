using Elmah.Io.QuickFixes.Fixes;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elmah.Io.QuickFixes.Test.Fixes
{
    public class RenewSslCertificateQuickFixTest
    {
        [TestCase(true, "SSL Checker")]
        [TestCase(false, null)]
        [TestCase(false, "")]
        [TestCase(false, "nothing valid here")]
        public void CanFix(bool canFix, string source)
        {
            var quickFix = new RenewSslCertificateQuickFix();
            var message = new Message { Source = source };
            var actual = quickFix.CanFix(message);
            Assert.That(actual, Is.EqualTo(canFix));
            if (canFix)
            {
                Assert.That(quickFix.Text, Is.EqualTo("Renew SSL certificate"));
                Assert.That(quickFix.Url.ToString(), Is.EqualTo("http://whichssl.com/comparisons/all-certificates.html"));
            }
        }
    }
}
