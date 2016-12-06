using Elmah.Io.QuickFixes.Fixes;
using NUnit.Framework;

namespace Elmah.Io.QuickFixes.Test.Fixes
{
    public class InstallBotBusterAppQuickFixTest
    {
        [TestCase(true, "some bot")]
        [TestCase(true, "crawler")]
        [TestCase(true, "a spider")]
        [TestCase(true, "a search engine")]
        [TestCase(false, null)]
        [TestCase(false, "")]
        [TestCase(false, "nothing valid here")]
        public void CanFixByUserAgent(bool canFix, string userAgent)
        {
            var quickFix = new InstallBotBusterAppQuickFix();
            Assert.That(quickFix.CanFix(new Message { UserAgent = userAgent }), Is.EqualTo(canFix));
        }

        [TestCase(false, "nothing valid here")]
        [TestCase(false, "")]
        [TestCase(false, null)]
        [TestCase(false, "The controller for path '/login' was not found or does not implement IController.")]
        [TestCase(true, "The controller for path '/wp-admin' was not found or does not implement IController.")]
        [TestCase(true, "The controller for path '/wp-admin/admin.php' was not found or does not implement IController.")]
        public void CanFixByMessage(bool canFix, string message)
        {
            var quickFix = new InstallBotBusterAppQuickFix();
            Assert.That(quickFix.CanFix(new Message { Title = message }), Is.EqualTo(canFix));
        }
    }
}