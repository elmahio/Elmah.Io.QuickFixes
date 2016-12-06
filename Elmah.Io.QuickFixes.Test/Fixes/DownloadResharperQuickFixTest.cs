using Elmah.Io.QuickFixes.Fixes;
using NUnit.Framework;

namespace Elmah.Io.QuickFixes.Test.Fixes
{
    public class DownloadResharperQuickFixTest
    {
        [TestCase(true, "System.NullReferenceException")]
        [TestCase(true, "System.ArgumentNullException")]
        [TestCase(false, "System.DbException")]
        [TestCase(false, "")]
        [TestCase(false, null)]
        public void CanFix(bool canFix, string type)
        {
            var quickFix = new DownloadResharperQuickFix();
            Assert.That(quickFix.CanFix(new Message { Type = type}), Is.EqualTo(canFix));
        }
    }
}