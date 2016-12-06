using Elmah.Io.QuickFixes.Fixes;
using NUnit.Framework;

namespace Elmah.Io.QuickFixes.Test.Fixes
{
    public class GenerateFavIconQuickFixTest
    {
        [TestCase(true, 404, "/favicon.ico")]
        [TestCase(true, 404, "apple-touch-icon")]
        [TestCase(true, 404, "/favicon2.ico")]
        [TestCase(false, 400, "/favicon.ico")]
        [TestCase(false, 404, "/icon.ico")]
        [TestCase(false, null, "/favicon.ico")]
        [TestCase(false, null, "apple-touch-icon")]
        [TestCase(false, 404, null)]
        public void CanFix(bool canFix, int? statusCode, string url)
        {
            var quickFix = new GenerateFavIconQuickFix();
            Assert.That(quickFix.CanFix(new Message {StatusCode = statusCode, Url = url}), Is.EqualTo(canFix));
        }
    }
}