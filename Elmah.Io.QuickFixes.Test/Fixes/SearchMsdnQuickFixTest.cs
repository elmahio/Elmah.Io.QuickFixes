using System;
using Elmah.Io.QuickFixes.Fixes;
using NUnit.Framework;

namespace Elmah.Io.QuickFixes.Test.Fixes
{
    public class SearchMsdnQuickFixTest
    {
        [Test]
        public void CanFix()
        {
            var quickFix = new SearchMsdnQuickFix();
            var canFix = quickFix.CanFix(new Message());
            Assert.That(canFix, Is.EqualTo(true));
        }

        [Test]
        public void CanDecorate()
        {
            var quickFix = new SearchMsdnQuickFix();
            var decorated = quickFix.Decorate(new Message {Title = "This is a test"});
            Assert.That(decorated.Url, Is.EqualTo(new Uri("https://social.msdn.microsoft.com/Forums/en-US/home?sort=relevancedesc&searchTerm=This is a test")));
        }
    }
}