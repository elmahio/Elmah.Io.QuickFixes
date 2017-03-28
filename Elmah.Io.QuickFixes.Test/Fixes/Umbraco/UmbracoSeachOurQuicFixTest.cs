using System;
using Elmah.Io.QuickFixes.Fixes;
using Elmah.Io.QuickFixes.Fixes.Umbraco;
using NUnit.Framework;

namespace Elmah.Io.QuickFixes.Test.Fixes.Umbraco
{
    public class UmbracoSeachOurQuicFixTest
    {
        [TestCase(true, "Warning", "An Umbraco error", null)] // Fix umbraco warnings
        [TestCase(true, "Error", "An Umbraco error", null)] // Fix umbraco errors
        [TestCase(true, "Fatal", "An Umbraco error", null)] // Fix umbraco fatals
        [TestCase(true, "Fatal", null, "Umbraco.Core.UmbracoApplicationBase")] // Fix umbraco fatals
        [TestCase(false, null, "An Umbraco error", null)] // Don't fix umbraco messages without severity
        [TestCase(false, "Error", null, null)] // Don't fix errors without detail
        [TestCase(false, "Information", "An Umbraco error", null)] // Don't fix information
        [TestCase(false, "Error", "Other error", null)] // Don't fix non-umbraco errors
        public void CanFix(bool expectedCanFix, string severity, string detail, string source)
        {
            var quickFix = new UmbracoSearchOurQuickFix();
            var canFix = quickFix.CanFix(new Message {Severity = severity, Detail = detail, Source = source});
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