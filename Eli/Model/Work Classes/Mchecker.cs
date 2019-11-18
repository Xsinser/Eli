using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MailKit.Net.Imap;
using MailKit.Search;
using MailKit;
using MimeKit;
 
namespace Eli
{
    class Mchecker: SImain,ISIchecker
    {
        private int count=0;
        private string imap = "";
        private void GetImap()
        {
            string[] words = login.Split(new char[] { '@' });
           imap= "imap." + words[1];
        }
        public override void Check(string login, string pass)
        {
            GetImap();
            using (var client = new ImapClient())
            {                
                client.ServerCertificateValidationCallback = (s, c, h, e) => true;
                client.Connect(imap, 993, true);
                client.Authenticate(login, pass);               
                var inbox = client.Inbox;
                inbox.Open(FolderAccess.ReadOnly);
                var bufCount = inbox.Count;
                if ((bufCount > count) && (count != 0))               
                {
                    Informing((count - bufCount).ToString(), login);
                    count = bufCount;                    
                }
                else if (count == 0)
                {
                    count = bufCount;
                }

                client.Disconnect(true);
            }
        }

        public override bool AuthorizeCheck(string login, string pass)
        {
           
            var client = new ImapClient();
            try
            {
                    GetImap();
                    client.ServerCertificateValidationCallback = (s, c, h, e) => true;
                    client.Connect(imap, 993, true);
                    client.Authenticate(login, pass);
                    client.Disconnect(true);
                    return true;                
            }
            catch
            {
                client.Disconnect(true);
            }
            return false;
        }
    }
}
