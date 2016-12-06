using System;
using Elmah.Io.QuickFixes.Fixes;
using NUnit.Framework;

namespace Elmah.Io.QuickFixes.Test.Fixes
{
    public class SearchStackOverflowQuickFixTest
    {
        [Test]
        public void CanFix()
        {
            var quickFix = new SearchStackOverflowQuickFix();
            var canFix = quickFix.CanFix(new Message());
            Assert.That(canFix, Is.EqualTo(true));
        }

        [Test]
        public void CanDecorate()
        {
            var quickFix = new SearchStackOverflowQuickFix();
            var decorated = quickFix.Decorate(new Message {Title = "This is a test"});
            Assert.That(decorated.Url, Is.EqualTo(new Uri("http://stackoverflow.com/search?q=This is a test")));
        }
    }
}