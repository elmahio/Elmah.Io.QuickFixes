using System;

namespace Elmah.Io.QuickFixes.Fixes
{
    public class InstallBotBusterAppQuickFix : QuickFixBase
    {
        public InstallBotBusterAppQuickFix()
        {
            Icon = "fa-android";
            Text = "Ignore bots by installing the BotBuster app";
        }

        public override bool CanFix(Message message)
        {
            return
                // Looks like bot requesting wordpress pages
                (!string.IsNullOrWhiteSpace(message.Title) &&
                message.Title.IndexOf("The controller for path") != -1 &&
                message.Title.IndexOf("The controller for path '/wp-admin") != -1) ||
                // User agent identifies itself as a bot
                (!string.IsNullOrWhiteSpace(message.UserAgent) &&
                (message.UserAgent.ToLower().IndexOf("bot") != -1 ||
                 message.UserAgent.ToLower().IndexOf("crawl") != -1 ||
                 message.UserAgent.ToLower().IndexOf("spider") != -1 ||
                 message.UserAgent.ToLower().IndexOf("search") != -1));
        }

        public override QuickFixBase Decorate(Message message)
        {
            Url = new Uri("https://app.elmah.io/errorlog/settings/?logId=" + message.LogId + "#apps");
            return this;
        }
    }
}