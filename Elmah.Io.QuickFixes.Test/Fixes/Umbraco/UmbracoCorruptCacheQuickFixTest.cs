using Elmah.Io.QuickFixes.Fixes.Umbraco;
using NUnit.Framework;

namespace Elmah.Io.QuickFixes.Test.Fixes.Umbraco
{
    public class UmbracoCorruptCacheQuickFixTest
    {
        [TestCase(false, null)]
        [TestCase(false, "")]
        [TestCase(false, "Some string")]
        [TestCase(true, "The Xml cache is corrupt. Use the Health Check data integrity dashboard to fix it.")]
        public void CanFix(bool expectedCanFix, string title)
        {
            var quickFix = new UmbracoCorruptCacheQuickFix();
            var canFix = quickFix.CanFix(new Message { Title = title });
            Assert.That(canFix, Is.EqualTo(expectedCanFix));
        }
    }
}