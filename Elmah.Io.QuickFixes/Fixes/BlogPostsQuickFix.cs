using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elmah.Io.QuickFixes.Fixes
{
    public class BlogPostsQuickFix : QuickFixBase
    {
        private readonly Dictionary<string, Tuple<Uri, string>> _links;

        public BlogPostsQuickFix()
        {
            _links = new Dictionary<string, Tuple<Uri, string>>
            {
                {"System.Net.WebException", new Tuple<Uri, string>(new Uri("https://blog.elmah.io/debugging-system-net-webexception-the-remote-name-could-not-be-resolved/"), "Debugging System.Net.WebException blog post")},
                {"System.OutOfMemoryException", new Tuple<Uri, string>(new Uri("https://blog.elmah.io/debugging-system-outofmemoryexception-using-net-tools/"), "Debugging System.OutOfMemoryException blog post")},
                {"System.IO.FileNotFoundException", new Tuple<Uri, string>(new Uri("https://blog.elmah.io/debugging-system-io-filenotfoundexception-cause-and-fix/"), "Debugging System.IO.FileNotFoundException blog post")},
                {"System.UnauthorizedAccessException", new Tuple<Uri, string>(new Uri("https://blog.elmah.io/debugging-system-unauthorizedaccessexception/"), "Debugging System.UnauthorizedAccessException blog post")},
            };
            Icon = "fa-book";
        }

        public override bool CanFix(Message message)
        {
            return !string.IsNullOrWhiteSpace(message.Type) && _links.ContainsKey(message.Type);
        }

        public override QuickFixBase Decorate(Message message)
        {
            Url = _links[message.Type].Item1;
            Text = _links[message.Type].Item2;
            return this;
        }
    }
}
