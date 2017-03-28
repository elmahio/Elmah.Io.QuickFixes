using Elmah.Io.QuickFixes.Fixes.Umbraco;
using NUnit.Framework;

namespace Elmah.Io.QuickFixes.Test.Fixes.Umbraco
{
    public class UmbracoModelBindingBugQuickFixTest
    {
        [TestCase(false, null)]
        [TestCase(false, "")]
        [TestCase(false, "Some string")]
        [TestCase(true, "Cannot bind source type Umbraco.Web.Models.RenderModel to model type Application.BusinessLogic.Models.MasterModel`1[[Application.BusinessLogic.Models.Login, Application.BusinessLogic]]")]
        public void CanFix(bool expectedCanFix, string title)
        {
            var quickFix = new UmbracoModelBindingBugQuickFix();
            var canFix = quickFix.CanFix(new Message { Title = title });
            Assert.That(canFix, Is.EqualTo(expectedCanFix));
        }
    }
}