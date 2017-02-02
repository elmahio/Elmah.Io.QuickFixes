using Elmah.Io.QuickFixes.Fixes;
using NUnit.Framework;

namespace Elmah.Io.QuickFixes.Test.Fixes
{
    public class WatchVideoAboutMvcRoutesAndControllersQuickFixTest
    {
        [TestCase(true, "The controller for path '/logging-to-elmah-io-from-microsoft-extensions-logging' was not found or does not implement IController.")]
        [TestCase(false, null)]
        [TestCase(false, "")]
        [TestCase(false, "nothing valid here")]
        public void CanFix(bool canFix, string title)
        {
            var quickFix = new WatchVideoAboutMvcRoutesAndControllersQuickFix();
            var message = new Message { Title = title };
            var actual = quickFix.CanFix(message);
            Assert.That(actual, Is.EqualTo(canFix));
            if (canFix)
            {
                var decorated = quickFix.Decorate(message);
                Assert.That(decorated.Text, Is.EqualTo("ASP.NET MVC Routes and Controllers video tutorial"));
                Assert.That(decorated.Url.ToString(), Is.EqualTo("https://app.pluralsight.com/player?author=scott-allen&name=mvc4-building-m2-controllers&mode=live&clip=1&course=mvc4-building"));
            }
        }
    }
}