using Elmah.Io.QuickFixes.Fixes.Umbraco;
using NUnit.Framework;

namespace Elmah.Io.QuickFixes.Test.Fixes.Umbraco
{
    public class UmbracoDatalayerTimeoutQuickFixTest
    {
        [TestCase(false, null, null)]
        [TestCase(false, "", "")]
        [TestCase(false, "", null)]
        [TestCase(false, null, "")]
        [TestCase(false, "Some string", "Some other string")]
        [TestCase(true, "The wait operation timed out", "umbraco.datalayer.sqlhelper")]
        public void CanFix(bool expectedCanFix, string title, string detail)
        {
            var quickFix = new UmbracoDatalayerTimeoutQuickFix();
            var canFix = quickFix.CanFix(new Message { Title = title, Detail = detail });
            Assert.That(canFix, Is.EqualTo(expectedCanFix));
        }
    }
}