using System;
using Elmah.Io.QuickFixes.Fixes;
using NUnit.Framework;

namespace Elmah.Io.QuickFixes.Test.Fixes
{
    public class UmbracoSeachOurQuicFixTest
    {
        [TestCase(false, null, "An Umbraco error")] // Don't fix umbraco messages without severity
        [TestCase(false, "Error", null)] // Don't fix errors without detail
        [TestCase(false, "Information", "An Umbraco error")] // Don't fix information
        [TestCase(true, "Warning", "An Umbraco error")] // Fix umbraco warnings
        [TestCase(true, "Error", "An Umbraco error")] // Fix umbraco errors
        [TestCase(true, "Fatal", "An Umbraco error")] // Fix umbraco fatals
        [TestCase(false, "Error", "Other error")] // Don't fix non-umbraco errors
        public void CanFix(bool expectedCanFix, string severity, string detail)
        {
            var quickFix = new UmbracoSearchOurQuickFix();
            var canFix = quickFix.CanFix(new Message {Severity = severity, Detail = detail});
            Assert.That(canFix, Is.EqualTo(expectedCanFix));
        }

        [Test]
        public void CanDecorate()
        {
            var quickFix = new UmbracoSearchOurQuickFix();
            var decorated = quickFix.Decorate(new Message { Severity = "Error", Detail = "Umbraco error", Title = "This is a test" });
            Assert.That(decorated.Url, Is.EqualTo(new Uri("https://our.umbraco.org/search?q=This is a test")));
        }
    }
}