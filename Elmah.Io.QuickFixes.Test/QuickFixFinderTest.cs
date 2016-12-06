using NUnit.Framework;

namespace Elmah.Io.QuickFixes.Test
{
    public class QuickFixFinderTest
    {
        [Test]
        public void CanFindQuickFixes()
        {
            var quickFixFinder = new QuickFixFinder();
            var quickFixes = quickFixFinder.FindQuickFixes(new Message());
            Assert.That(quickFixes.Count, Is.GreaterThan(0));
        }
    }
}