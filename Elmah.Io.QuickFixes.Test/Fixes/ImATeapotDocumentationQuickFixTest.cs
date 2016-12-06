using Elmah.Io.QuickFixes.Fixes;
using NUnit.Framework;

namespace Elmah.Io.QuickFixes.Test.Fixes
{
    public class ImATeapotDocumentationQuickFixTest
    {
        [TestCase(true, 418)]
        [TestCase(false, 400)]
        [TestCase(false, null)]
        public void CanFix(bool canFix, int? statusCode)
        {
            var quickFix = new ImATeapotDocumentationQuickFix();
            Assert.That(quickFix.CanFix(new Message {StatusCode = statusCode}), Is.EqualTo(canFix));
        }
    }
}