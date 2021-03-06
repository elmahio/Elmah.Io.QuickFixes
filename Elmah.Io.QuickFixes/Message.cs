﻿using System;
using System.Collections.Generic;

namespace Elmah.Io.QuickFixes
{
    public class Message
    {
        /// <summary>
        /// The id of this message.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// The id of the log that this message belongs to.
        /// </summary>
        public Guid LogId { get; set; }

        /// <summary>
        /// Used to identify which application logged this message. You can use this if you have multiple applications and services logging to the same log
        /// </summary>
        public string Application { get; set; }

        /// <summary>
        /// A longer description of the message. For errors this could be a stacktrace, but it's really up to you what to log in there.
        /// </summary>
        public string Detail { get; set; }

        /// <summary>
        /// The hostname of the server logging the message.
        /// </summary>
        public string Hostname { get; set; }

        /// <summary>
        /// The textual title or headline of the message to log.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// The source of the code logging the message. This could be the assembly name.
        /// </summary>
        public string Source { get; set; }

        /// <summary>
        /// If the message logged relates to a HTTP status code, you can put the code in this property. This would probably only be relevant for errors,
        /// but could be used for logging successful status codes as well.
        /// </summary>
        public int? StatusCode { get; set; }

        /// <summary>
        /// The date and time in UTC of the message. If you don't provide us with a value in dateTime, we will set the current date and time in UTC.
        /// </summary>
        public DateTime? DateTime { get; set; }

        /// <summary>
        /// The type of message. If logging an error, the type of the exception would go into type but you can put anything in there, that makes sense for your domain.
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// An identification of the user triggering this message. You can put the users email address or your user key into this property.
        /// </summary>
        public string User { get; set; }

        /// <summary>
        /// An enum value representing the severity of this message. The following values are allowed: Verbose, Debug, Information, Warning, Error, Fatal
        /// </summary>
        public string Severity { get; set; }

        /// <summary>
        /// If message relates to a HTTP request, you may send the URL of that request. If you don't provide us with an URL, we will try to find a key named URL in serverVariables.
        /// </summary>
        public string Url { get; set; }

        /// <summary>
        /// If message relates to a HTTP request, you may send the HTTP method of that request. If you don't provide us with a method, we will try to find a key named REQUEST_METHOD in serverVariables.
        /// </summary>
        public string Method { get; set; }

        /// <summary>
        /// Versions can be used to distinguish messages from different versions of your software. The value of version can be a SemVer compliant string or any other
        /// syntax that you are using as your version numbering scheme.
        /// </summary>
        public string Version { get; set; }

        /// <summary>
        /// If found in server variables, the user agent (typically a browser) is extracted and put into this property for easy access.
        /// </summary>
        public string UserAgent { get; set; }

        /// <summary>
        /// A key/value pair of cookies. This property only makes sense for logging messages related to web requests.
        /// </summary>
        public List<Item> Cookies { get; set; }

        /// <summary>
        /// A key/value pair of form fields and their values. This property makes sense if logging message related to users inputting data in a form.
        /// </summary>
        public List<Item> Form { get; set; }

        /// <summary>
        /// A key/value pair of query string parameters. This property makes sense if logging message related to a HTTP request.
        /// </summary>
        public List<Item> QueryString { get; set; }

        /// <summary>
        /// A key/value pair of server values. Server variables are typically related to handling requests in a webserver but could be used for other types of information as well.
        /// </summary>
        public List<Item> ServerVariables { get; set; }

        /// <summary>
        /// A key/value pair of user-defined fields and their values. When logging an exception, the Data dictionary of
        /// the exception is copied to this property. You can add additional key/value pairs, by modifying the Data
        /// dictionary on the exception or by supplying additional key/values to this API.
        /// </summary>
        public List<Item> Data { get; set; }
    }

    public class Item
    {
        public string Key { get; set; }

        public string Value { get; set; }
    }
}