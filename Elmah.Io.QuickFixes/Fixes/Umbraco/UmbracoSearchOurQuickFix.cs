﻿using System;

namespace Elmah.Io.QuickFixes.Fixes.Umbraco
{
    public class UmbracoSearchOurQuickFix : QuickFixBase
    {
        public UmbracoSearchOurQuickFix()
        {
            Icon = "fa-heart-o";
            Text = "Search Our";
        }

        public override bool CanFix(Message message)
        {
            return !string.IsNullOrWhiteSpace(message.Severity)
                   && (message.Severity == "Error" || message.Severity == "Warning" || message.Severity == "Fatal")
                   && (!string.IsNullOrWhiteSpace(message.Detail) && message.Detail.ToLower().Contains("umbraco")
                   || !string.IsNullOrWhiteSpace(message.Source) && message.Source.ToLower().Contains("umbraco"));

        }

        public override QuickFixBase Decorate(Message message)
        {
            Url = new Uri("https://our.umbraco.org/search?q=" + message.Title);
            return this;
        }
    }
}