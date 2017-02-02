using Elmah.Io.QuickFixes.Fixes;
using NUnit.Framework;

namespace Elmah.Io.QuickFixes.Test.Fixes
{
    public class WatchVideoAboutMvcParametersQuickFixTest
    {
        [TestCase(true, "The parameters dictionary contains a null entry for parameter 'logId' of non-nullable type 'System.Guid' for method 'System.Web.Mvc.ActionResult Settings(System.Guid)' in 'Elmah.Io.Web.Controllers.ErrorLogController'. An optional parameter must be a reference type, a nullable type, or be declared as an optional parameter.Parameter name: parameters")]
        [TestCase(false, null)]
        [TestCase(false, "")]
        [TestCase(false, "nothing valid here")]
        public void CanFix(bool canFix, string title)
        {
            var quickFix = new WatchVideoAboutMvcParametersQuickFix();
            var message = new Message { Title = title };
            var actual = quickFix.CanFix(message);
            Assert.That(actual, Is.EqualTo(canFix));
            if (canFix)
            {
                var decorated = quickFix.Decorate(message);
                Assert.That(decorated.Text, Is.EqualTo("ASP.NET MVC Actions and Parameters video tutorial"));
                Assert.That(decorated.Url.ToString(), Is.EqualTo("https://app.pluralsight.com/player?author=scott-allen&name=mvc4-building-m2-controllers&mode=live&clip=2&course=mvc4-building"));
            }
        }
    }
}