using Elmah.Io.QuickFixes.Fixes.Umbraco;
using NUnit.Framework;

namespace Elmah.Io.QuickFixes.Test.Fixes.Umbraco
{
    public class UmbracoReadCustomControllersDocumentationQuickFixTest
    {
        [TestCase(false, null)]
        [TestCase(false, "")]
        [TestCase(false, "Other string")]
        [TestCase(true, "The current Document Type SearchResults matches a locally declared controller of type MyApp.Controllers.HomeController. Custom Controllers for Umbraco routing must implement 'Umbraco.Web.Mvc.IRenderController' and inherit from 'System.Web.Mvc.ControllerBase'.")]
        public void CanFixByUserAgent(bool expected, string title)
        {
            var quickFix = new UmbracoReadCustomControllersDocumentationQuickFix();
            var message = new Message { Title = title };
            var actual = quickFix.CanFix(message);
            Assert.That(actual, Is.EqualTo(expected));
        }
    }
}