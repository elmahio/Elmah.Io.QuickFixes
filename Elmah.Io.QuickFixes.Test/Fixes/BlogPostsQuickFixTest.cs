using System;
using Elmah.Io.QuickFixes.Fixes;
using NUnit.Framework;

namespace Elmah.Io.QuickFixes.Test.Fixes
{
    public class BlogPostsQuickFixTest
    {
        [TestCase(true, "System.Net.WebException", "https://blog.elmah.io/debugging-system-net-webexception-the-remote-name-could-not-be-resolved/", "Debugging: System.Net.WebException - The remote name could not be resolved")]
        [TestCase(true, "System.OutOfMemoryException", "https://blog.elmah.io/debugging-system-outofmemoryexception-using-net-tools/", "Debugging System.OutOfMemoryException using .NET tools")]
        [TestCase(true, "System.IO.FileNotFoundException", "https://blog.elmah.io/debugging-system-io-filenotfoundexception-cause-and-fix/", "Debugging System.IO.FileNotFoundException - Cause and fix")]
        [TestCase(false, null, "", null)]
        [TestCase(false, "", "", null)]
        [TestCase(false, "nothing valid here", "", null)]
        public void CanFix(bool canFix, string type, string url, string title)
        {
            var quickFix = new BlogPostsQuickFix();
            var message = new Message { Type = type };
            var actual = quickFix.CanFix(message);
            Assert.That(actual, Is.EqualTo(canFix));
            if (canFix)
            {
                var decorated = quickFix.Decorate(message);
                Assert.That(decorated.Text, Is.EqualTo(title));
                Assert.That(decorated.Url.ToString(), Is.EqualTo(url));
            }
        }
    }
}