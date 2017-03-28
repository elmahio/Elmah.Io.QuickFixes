using System;

namespace Elmah.Io.QuickFixes.Fixes.Umbraco
{
    public class UmbracoDatalayerTimeoutQuickFix : QuickFixBase
    {
        public UmbracoDatalayerTimeoutQuickFix()
        {
            Icon = "fa-book";
            Text = "Troubleshoot timeout";
            Url = new Uri("https://our.umbraco.org/projects/backoffice-extensions/falm-housekeeping/bugs-reports/42409-The-wait-operation-timed-out");
        }

        public override bool CanFix(Message message)
        {
            return
                !string.IsNullOrWhiteSpace(message.Title) &&
                !string.IsNullOrWhiteSpace(message.Detail) &&
                message.Title.ToLower().Contains("the wait operation timed out") &&
                message.Detail.ToLower().Contains("umbraco.datalayer.sqlhelper");
        }
    }
}