using System;
using Elmah.Io.QuickFixes.Fixes;
using NUnit.Framework;

namespace Elmah.Io.QuickFixes.Test.Fixes
{
    public class TroubleshootDotNetExceptionsQuickFixTest
    {
        [TestCase(true, "System.NullReferenceException", "https://msdn.microsoft.com/en-us/library/sxw2ez55.aspx")]
        [TestCase(false, null, "")]
        [TestCase(false, "", "")]
        [TestCase(false, "nothing valid here", "")]
        public void CanFixByUserAgent(bool canFix, string type, string url)
        {
            var quickFix = new TroubleshootDotNetExceptionsQuickFix();
            var message = new Message { Type = type };
            var actual = quickFix.CanFix(message);
            Assert.That(actual, Is.EqualTo(canFix));
            if (canFix)
            {
                var decorated = quickFix.Decorate(message);
                Assert.That(decorated.Text, Is.EqualTo("Troubleshoot System.NullReferenceException"));
                Assert.That(decorated.Url.ToString(), Is.EqualTo(url));
            }
        }
    }
}