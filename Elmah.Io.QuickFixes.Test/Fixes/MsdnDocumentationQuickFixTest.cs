using Elmah.Io.QuickFixes.Fixes;
using NUnit.Framework;

namespace Elmah.Io.QuickFixes.Test.Fixes
{
    public class MsdnDocumentationQuickFixTest
    {
        [TestCase(true, "System.NullReferenceException", "https://msdn.microsoft.com/en-us/library/system.nullreferenceexception.aspx")]
        [TestCase(false, null, "")]
        [TestCase(false, "", "")]
        [TestCase(false, "nothing valid here", "")]
        [TestCase(false, "Elmah.Io.CustomException", "")]
        public void CanFixByUserAgent(bool canFix, string type, string url)
        {
            var quickFix = new MsdnDocumentationQuickFix();
            var message = new Message { Type = type };
            var actual = quickFix.CanFix(message);
            Assert.That(actual, Is.EqualTo(canFix));
            if (canFix)
            {
                var decorated = quickFix.Decorate(message);
                Assert.That(decorated.Text, Is.EqualTo($"Documentation for {type}"));
                Assert.That(decorated.Url.ToString(), Is.EqualTo(url));
            }
        }
    }
}