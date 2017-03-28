using Elmah.Io.QuickFixes.Fixes;
using Elmah.Io.QuickFixes.Fixes.Umbraco;
using NUnit.Framework;

namespace Elmah.Io.QuickFixes.Test.Fixes.Umbraco
{
    public class UmbracoReadRazorDocumentationQuickFixTest
    {
        [TestCase(true, "System.Web.HttpCompileException", "in Umbraco.Core.Profiling.ProfilingView.Render")]
        [TestCase(false, "System.Web.HttpCompileException", "in Profiling.ProfilingView.Render")]
        [TestCase(false, "System.Web.HttpException", "in Umbraco.Core.Profiling.ProfilingView.Render")]
        [TestCase(false, "System.Web.HttpCompileException", null)]
        [TestCase(false, null, "in Umbraco.Core.Profiling.ProfilingView.Render")]
        public void CanFixByUserAgent(bool expected, string type, string detail)
        {
            var quickFix = new UmbracoReadRazorDocumentationQuickFix();
            var message = new Message { Type = type, Detail = detail };
            var actual = quickFix.CanFix(message);
            Assert.That(actual, Is.EqualTo(expected));
        }
    }
}