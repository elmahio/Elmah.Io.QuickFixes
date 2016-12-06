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
                .Where(i => CanFix(message, i))
                .Select(i => Decorate(message, i))
                .Where(
                    i =>
                        i != null && !string.IsNullOrWhiteSpace(i.Icon) && i.Icon.StartsWith("fa-") &&
                        !string.IsNullOrWhiteSpace(i.Text) && i.Url != null)
                .ToList();
        }

        private static QuickFixBase Decorate(Message message, QuickFixBase i)
        {
            try
            {
                return i.Decorate(message);
            }
            catch
            {
                return i;
            }
        }

        private static bool CanFix(Message message, QuickFixBase i)
        {
            try
            {
                return i.CanFix(message);
            }
            catch
            {
                return false;
            }
        }
    }
}