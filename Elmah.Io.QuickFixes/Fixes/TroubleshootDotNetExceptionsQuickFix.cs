using System;
using System.Collections.Generic;

namespace Elmah.Io.QuickFixes.Fixes
{
    public class TroubleshootDotNetExceptionsQuickFix : QuickFixBase
    {
        private readonly Dictionary<string, Uri> _links;

        public TroubleshootDotNetExceptionsQuickFix()
        {
            _links = new Dictionary<string, Uri>
            {
                {"System.NullReferenceException", new Uri("https://msdn.microsoft.com/en-us/library/sxw2ez55.aspx")},
                {"System.ArgumentException", new Uri("https://msdn.microsoft.com/en-us/library/ms242197.aspx")},
                {"System.StackOverflowException", new Uri("https://msdn.microsoft.com/en-us/library/w6sxk224.aspx")},
                {"System.Data.SqlClient.SqlException", new Uri("https://msdn.microsoft.com/en-us/library/24xy33d0.aspx")},
                {"System.BadImageFormatException", new Uri("https://msdn.microsoft.com/en-us/library/k7137bfe.aspx")},
                {"System.IndexOutOfRangeException", new Uri("https://msdn.microsoft.com/en-us/library/3zwz4dx3.aspx")},
                {"System.FormatException", new Uri("https://msdn.microsoft.com/en-us/library/34see4yz.aspx")},
                {"System.OverflowException", new Uri("https://msdn.microsoft.com/en-us/library/y3d0kef1.aspx")},
                {"System.InvalidCastException", new Uri("https://msdn.microsoft.com/en-us/library/7w0ksafs.aspx")},
                {"System.Net.WebException", new Uri("https://msdn.microsoft.com/en-us/library/48ww3ee9.aspx")},
                {"System.Exception", new Uri("https://msdn.microsoft.com/en-us/library/ms242319.aspx")},
                {"System.InvalidOperationException", new Uri("https://msdn.microsoft.com/en-us/library/fd85b3df.aspx")},
                {"System.AccessViolationException", new Uri("https://msdn.microsoft.com/en-us/library/ms164911.aspx")},
                {"System.ArgumentNullException", new Uri("https://msdn.microsoft.com/en-us/library/6xhxacwh.aspx")},
                {"System.MissingMemberException", new Uri("https://msdn.microsoft.com/en-us/library/62xdkcxy.aspx")},
                {"System.UnauthorizedAccessException", new Uri("https://msdn.microsoft.com/en-us/library/18b8kx07.aspx")},
                {"System.Security.VerificationException", new Uri("https://msdn.microsoft.com/en-us/library/432cdx67.aspx")},
                {"System.Drawing.Printing.InvalidPrinterException", new Uri("https://msdn.microsoft.com/en-us/library/0a92fcw1.aspx")},
                {"System.Net.Mail.SmtpException", new Uri("https://msdn.microsoft.com/en-us/library/ms241885.aspx")},
                {"System.DllNotFoundException", new Uri("https://msdn.microsoft.com/en-us/library/ms241899.aspx")},
                {"System.OutOfMemoryException", new Uri("https://msdn.microsoft.com/en-us/library/9w766t6y.aspx")},
                {"System.Net.CookieException", new Uri("https://msdn.microsoft.com/en-us/library/00y90f4c.aspx")},
                {"System.RankException", new Uri("https://msdn.microsoft.com/en-us/library/b58wh1zz.aspx")},
                {"System.Security.SecurityException", new Uri("https://msdn.microsoft.com/en-us/library/bats0y2a.aspx")},
                {"System.TypeInitializationException", new Uri("https://msdn.microsoft.com/en-us/library/ms242144.aspx")},
                {"System.Reflection.AmbiguousMatchException", new Uri("https://msdn.microsoft.com/en-us/library/ms242316.aspx")},
                {"System.Security.Cryptography.CryptographicException", new Uri("https://msdn.microsoft.com/en-us/library/ms241889.aspx")},
                {"System.Data.NoNullAllowedException", new Uri("https://msdn.microsoft.com/en-us/library/wcd34d19.aspx")},
                {"System.Data.SqlServerCe.SqlCeInvalidDatabaseFormatException", new Uri("https://msdn.microsoft.com/en-us/library/bb907251.aspx")},
                {"System.EntryPointNotFoundException", new Uri("https://msdn.microsoft.com/en-us/library/ms241901.aspx")},
                {"System.ArgumentOutOfRangeException", new Uri("https://msdn.microsoft.com/en-us/library/wkd6khbd.aspx")},
                {"System.IO.IOException", new Uri("https://msdn.microsoft.com/en-us/library/ms164917.aspx")},
                {"System.Threading.ThreadStartException", new Uri("https://msdn.microsoft.com/en-us/library/ms241887.aspx")},
                {"System.ServiceModel.Security.MessageSecurityException", new Uri("https://msdn.microsoft.com/en-us/library/bb907174.aspx")},
                {"System.Data.StrongTypingException", new Uri("https://msdn.microsoft.com/en-us/library/ms242030.aspx")},
                {"System.IO.InternalBufferOverflowException", new Uri("https://msdn.microsoft.com/en-us/library/hf4sz8xw.aspx")},
                {"System.Data.ConstraintException", new Uri("https://msdn.microsoft.com/en-us/library/4d40xefa.aspx")},
                {"System.TimeoutException", new Uri("https://msdn.microsoft.com/en-us/library/ms241747.aspx")},
                {"System.IO.DirectoryNotFoundException", new Uri("https://msdn.microsoft.com/en-us/library/53fkz89b.aspx")},
                {"System.IO.FileLoadException", new Uri("https://msdn.microsoft.com/en-us/library/dbe81ttk.aspx")},
                {"System.NotImplementedException", new Uri("https://msdn.microsoft.com/en-us/library/ms242166.aspx")},
                {"System.IO.PathTooLongException", new Uri("https://msdn.microsoft.com/en-us/library/5eyyxc3b.aspx")},
                {"System.Data.SyntaxErrorException", new Uri("https://msdn.microsoft.com/en-us/library/ms241764.aspx")},
                {"System.MissingMethodException", new Uri("https://msdn.microsoft.com/en-us/library/zk1a255s.aspx")},
                {"System.IO.IsolatedStorage.IsolatedStorageException", new Uri("https://msdn.microsoft.com/en-us/library/ms241607.aspx")},
                {"System.IdentityModel.Tokens.SecurityTokenValidationException", new Uri("https://msdn.microsoft.com/en-us/library/bb907154.aspx")},
                {"System.IO.InvalidDataException", new Uri("https://msdn.microsoft.com/en-us/library/ms241600.aspx")},
                {"System.Net.NetworkInformation.NetworkInformationException", new Uri("https://msdn.microsoft.com/en-us/library/ms242026.aspx")},
                {"System.EnterpriseServices.RegistrationException", new Uri("https://msdn.microsoft.com/en-us/library/ms241881.aspx")},
                {"System.MissingFieldException", new Uri("https://msdn.microsoft.com/en-us/library/ze74ahef.aspx")},
                {"System.Data.OleDb.OleDbException", new Uri("https://msdn.microsoft.com/en-us/library/6y8t7kbw.aspx")},
                {"System.Net.HttpListenerException", new Uri("https://msdn.microsoft.com/en-us/library/ms164918.aspx")},
                {"System.IO.FileNotFoundException", new Uri("https://msdn.microsoft.com/en-us/library/2a8964b2.aspx")},
                {"System.Threading.AbandonedMutexException", new Uri("https://msdn.microsoft.com/en-us/library/ms241597.aspx")},
                {"System.IdentityModel.Tokens.SecurityTokenException", new Uri("https://msdn.microsoft.com/en-us/library/bb907246.aspx")},
                {"System.FieldAccessException", new Uri("https://msdn.microsoft.com/en-us/library/4e52cxk5.aspx")},
                {"System.Runtime.InteropServices.COMException", new Uri("https://msdn.microsoft.com/en-us/library/af1y26ew.aspx")},
                {"System.DirectoryServices.ActiveDirectory.ActiveDirectoryOperationException", new Uri("https://msdn.microsoft.com/en-us/library/ms242012.aspx")},
                {"System.CannotUnloadAppDomainException", new Uri("https://msdn.microsoft.com/en-us/library/t0a88z4d.aspx")},
                {"System.Data.OracleClient.OracleException", new Uri("https://msdn.microsoft.com/en-us/library/6ad169f1.aspx")},
                {"System.Data.Odbc.OdbcException", new Uri("https://msdn.microsoft.com/en-us/library/w5834xh8.aspx")},
                {"System.Messaging.MessageQueueException", new Uri("https://msdn.microsoft.com/en-us/library/bw5eztxb.aspx")},
                {"System.Runtime.InteropServices.SEHException", new Uri("https://msdn.microsoft.com/en-us/library/ms241886.aspx")},
                {"System.Web.HttpCompileException", new Uri("https://msdn.microsoft.com/en-us/library/ms242190.aspx")},
                {"System.Windows.Markup.XamlParseException", new Uri("https://msdn.microsoft.com/en-us/library/bb907167.aspx")},
                {"System.Runtime.Remoting.RemotingException", new Uri("https://msdn.microsoft.com/en-us/library/ms241757.aspx")},
                {"System.Collections.Generic.KeyNotFoundException", new Uri("https://msdn.microsoft.com/en-us/library/ms164912.aspx")},
                {"System.Web.HttpException", new Uri("https://msdn.microsoft.com/en-us/library/ms242236.aspx")},
                {"System.Threading.Tasks.TaskCanceledException", new Uri("https://blogs.msdn.microsoft.com/pfxteam/2009/06/01/tasks-and-unhandled-exceptions/")},
            };
            Icon = "fa-book";
        }

        public override bool CanFix(Message message)
        {
            return !string.IsNullOrWhiteSpace(message.Type) && _links.ContainsKey(message.Type);
        }

        public override QuickFixBase Decorate(Message message)
        {
            Url = _links[message.Type];
            Text = string.Format("Troubleshoot {0}", message.Type);
            return this;
        }
    }
}