using System;
using Elmah.Io.QuickFixes.Fixes;
using NUnit.Framework;

namespace Elmah.Io.QuickFixes.Test.Fixes
{
    public class BlogPostsQuickFixTest
    {
        [TestCase(true, "System.Net.WebException", "https://blog.elmah.io/debugging-system-net-webexception-the-remote-name-could-not-be-resolved/")]
        [TestCase(true, "System.OutOfMemoryException", "https://blog.elmah.io/debugging-system-outofmemoryexception-using-net-tools/")]
        [TestCase(false, null, "")]
        [TestCase(false, "", "")]
        [TestCase(false, "nothing valid here", "")]
        public void CanFixByUserAgent(bool canFix, string type, string url)
        {
            var quickFix = new BlogPostsQuickFix();
            var message = new Message { Type = type };
            var actual = quickFix.CanFix(message);
            Assert.That(actual, Is.EqualTo(canFix));
            if (canFix)
            {
                var decorated = quickFix.Decorate(message);
                Assert.That(decorated.Text, Is.EqualTo($"Blog post about {type}"));
                Assert.That(decorated.Url.ToString(), Is.EqualTo(url));
            }
        }
    }
}