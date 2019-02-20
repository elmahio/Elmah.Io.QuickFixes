using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elmah.Io.QuickFixes.Fixes
{
    public class BlogPostsQuickFix : QuickFixBase
    {
        private readonly Dictionary<string, Uri> _links;

        public BlogPostsQuickFix()
        {
            _links = new Dictionary<string, Uri>
            {
                {"System.Net.WebException", new Uri("https://blog.elmah.io/debugging-system-net-webexception-the-remote-name-could-not-be-resolved/")},
                {"System.OutOfMemoryException", new Uri("https://blog.elmah.io/debugging-system-outofmemoryexception-using-net-tools/")},
            };
            Icon = "fa-file-text-o";
        }

        public override bool CanFix(Message message)
        {
            return !string.IsNullOrWhiteSpace(message.Type) && _links.ContainsKey(message.Type);
        }

        public override QuickFixBase Decorate(Message message)
        {
            Url = _links[message.Type];
            Text = string.Format("Blog post about {0}", message.Type);
            return this;
        }
    }
}
