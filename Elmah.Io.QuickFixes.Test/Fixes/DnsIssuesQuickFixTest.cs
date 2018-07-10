using Elmah.Io.QuickFixes.Fixes;
using NUnit.Framework;

namespace Elmah.Io.QuickFixes.Test.Fixes
{
    public class DnsIssuesQuickFixTest
    {
        [TestCase(true, "The remote name could not be resolved: &#39;djdjdjdjdjksdjksdjksd.com&#39;")]
        [TestCase(false, "Nothing to see here")]
        [TestCase(false, null)]
        [TestCase(false, "")]
        public void CanFix(bool canFix, string detail)
        {
            var quickFix = new DnsIssuesQuickFix();
            Assert.That(quickFix.CanFix(new Message { Detail = detail }), Is.EqualTo(canFix));
        }
    }
}
