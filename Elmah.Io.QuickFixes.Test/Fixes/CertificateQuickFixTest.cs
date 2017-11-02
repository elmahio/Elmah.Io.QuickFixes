using Elmah.Io.QuickFixes.Fixes;
using NUnit.Framework;

namespace Elmah.Io.QuickFixes.Test.Fixes
{
    public class CertificateQuickFixTest
    {
        [TestCase(true, "Could not establish trust relationship for the SSL/TLS secure channel")]
        [TestCase(true, "could not establish trust relationship for the ssl/tls secure channel")]
        [TestCase(true, "The underlying connection was closed: Could not establish trust relationship for the SSL/TLS secure channel.")]
        [TestCase(false, "")]
        [TestCase(false, "Some other message")]
        [TestCase(false, null)]
        public void CanFix(bool canFix, string detail)
        {
            var quickFix = new CertificateQuickFix();
            Assert.That(quickFix.CanFix(new Message { Detail = detail }), Is.EqualTo(canFix));
        }
    }
}