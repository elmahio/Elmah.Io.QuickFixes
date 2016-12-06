using System;
using System.Collections.Generic;
using System.Linq;

namespace Elmah.Io.QuickFixes
{
    public class QuickFixFinder
    {
        public List<QuickFixBase> FindQuickFixes(Message message)
        {
            return typeof(QuickFixBase)
                .Assembly
                .GetTypes()
                .Where(t => t.IsClass && !t.IsAbstract && t.IsSubclassOf(typeof(QuickFixBase)))
                .Select(t => (QuickFixBase) Activator.CreateInstance(t))
                .Where(i => i.CanFix(message))
                .Select(i => i.Decorate(message))
                .Where(
                    i =>
                        !string.IsNullOrWhiteSpace(i.Icon) && i.Icon.StartsWith("fa-") &&
                        !string.IsNullOrWhiteSpace(i.Text) && i.Url != null)
                .ToList();
        }
    }
}