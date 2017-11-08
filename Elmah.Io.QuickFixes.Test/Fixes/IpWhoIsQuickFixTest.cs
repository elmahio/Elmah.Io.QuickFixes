using System.Collections.Generic;
using Elmah.Io.QuickFixes.Fixes;
using NUnit.Framework;

namespace Elmah.Io.QuickFixes.Test.Fixes
{
    public class IpWhoIsQuickFixTest
    {
        [TestCase(true, "REMOTE_ADDR", "1.1.1.1")]
        [TestCase(false, "REMOTE_ADDR", "OTHER_VALUE")]
        [TestCase(false, "REMOTE_ADDR", null)]
        [TestCase(true, "HTTP_FORWARDED", "1.1.1.1")]
        [TestCase(false, "HTTP_FORWARDED", "OTHER_VALUE")]
        [TestCase(true, "HTTP_FORWARDED_FOR", "1.1.1.1")]
        [TestCase(false, "HTTP_FORWARDED_FOR", "OTHER_VALUE")]
        [TestCase(true, "HTTP_CLIENT_IP", "1.1.1.1")]
        [TestCase(false, "HTTP_CLIENT_IP", "OTHER_VALUE")]
        [TestCase(true, "HTTP_VIA", "1.1.1.1")]
        [TestCase(false, "HTTP_VIA", "OTHER_VALUE")]
        [TestCase(true, "HTTP_X_FORWARDED", "1.1.1.1")]
        [TestCase(false, "HTTP_X_FORWARDED", "OTHER_VALUE")]
        [TestCase(true, "HTTP_X_FORWARDED_FOR", "1.1.1.1")]
        [TestCase(false, "HTTP_X_FORWARDED_FOR", "OTHER_VALUE")]
        [TestCase(true, "HTTP_X_CLUSTER_CLIENT_IP", "1.1.1.1")]
        [TestCase(false, "HTTP_X_CLUSTER_CLIENT_IP", "OTHER_VALUE")]
        [TestCase(false, null, null)]
        [TestCase(false, "OTHER_HEADER", "OTHER_VALUE")]
        public void CanFix(bool canFix, string headerName, string headerValue)
        {
            var quickFix = new IpWhoIsQuickFix();
            var message = new Message();
            if (!string.IsNullOrWhiteSpace(headerName))
            {
                message.ServerVariables = new List<Item>
                {
                    new Item {Key = headerName, Value = headerValue}
                };
            }
            Assert.That(quickFix.CanFix(message), Is.EqualTo(canFix));
        }

        [Test]
        public void CanDecorate()
        {
            var quickFix = new IpWhoIsQuickFix();
            var message = new Message
            {
                ServerVariables = new List<Item>
                {
                    new Item {Key = "REMOTE_ADDR", Value = "192.168.0.1"}
                }
            };
            Assert.That(quickFix.Decorate(message).Url.ToString(), Is.EqualTo("https://db-ip.com/192.168.0.1"));
        }
    }
}
