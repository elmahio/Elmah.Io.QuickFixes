using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;

namespace Elmah.Io.QuickFixes.Fixes
{
    public class IpWhoIsQuickFix : QuickFixBase
    {
        private const string Headers = "REMOTE_ADDR,HTTP_FORWARDED,HTTP_FORWARDED_FOR,HTTP_CLIENT_IP,HTTP_VIA,HTTP_X_FORWARDED,HTTP_X_FORWARDED_FOR,HTTP_X_CLUSTER_CLIENT_IP";
        public IpWhoIsQuickFix()
        {
            Icon = "fa-globe";
            Text = "WHOIS";
        }

        public override bool CanFix(Message message)
        {
            return message?.ServerVariables != null && message.ServerVariables.Any(MatchingHeader);
        }

        public override QuickFixBase Decorate(Message message)
        {
            Url = new Uri($"https://db-ip.com/{message.ServerVariables.First(MatchingHeader).Value}");
            return this;
        }

        private static bool MatchingHeader(Item sv)
        {
            var headers = HeaderNames();
            return headers.Contains(sv.Key) && IPAddress.TryParse(sv.Value, out IPAddress ip);
        }

        private static List<string> HeaderNames()
        {
            return Headers.Split(new[] { "," }, StringSplitOptions.RemoveEmptyEntries).ToList();
        }
    }
}