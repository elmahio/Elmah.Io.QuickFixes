using System;

namespace Elmah.Io.QuickFixes
{
    public abstract class QuickFixBase
    {
        protected QuickFixBase()
        {
            Icon = "fa-wrench";
        }

        /// <summary>
        /// Specify an icon to use for this quick fix. The name of the icon must be from
        /// the Font Awesome icon set: http://fontawesome.io/. Defaults to fa-wrench.
        /// Example: fa-bolt
        /// </summary>
        public string Icon { get; set; }

        /// <summary>
        /// The text to show for this quick fix. Will be available on the elmah.io UI.
        /// </summary>
        public string Text { get; set; }

        /// <summary>
        /// The URL to load when clicking on this quick fix on the elmah.io UI. Must be a GET.
        /// </summary>
        public Uri Url { get; set; }

        /// <summary>
        /// Determines if this quick fix is able to do something about the message sent as
        /// a paramter. Make sure to be specific and not just show the quick fix for all
        /// messages.
        /// </summary>
        /// <param name="message">The message to check</param>
        /// <returns>true if this quick fix should be available for the message</returns>
        public abstract bool CanFix(Message message);

        /// <summary>
        /// The Decorate method is executed on all quick fixes able to fix a message. In this
        /// method you have the option to decorate the quick fix properties like Url and Text.
        /// </summary>
        /// <param name="message">Message to use for decorating the result</param>
        /// <returns>The decorated quick fix</returns>
        public virtual QuickFixBase Decorate(Message message)
        {
            return this;
        }
    }
}