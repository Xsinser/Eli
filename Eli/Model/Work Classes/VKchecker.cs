using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using VkNet;
using VkNet.Abstractions;
using VkNet.AudioBypassService.Extensions;
using VkNet.Model;

namespace Eli
{
    class VKchecker: SImain, ISIchecker
    { 
        public override void Check(string login, string pass)
        { 
            VkApi api = AuthorizeInSN();

            var bufferMessages = api.Messages.GetDialogs(new VkNet.Model.RequestParams.MessagesDialogsGetParams { Count = 200 });
            if (bufferMessages.Unread != null)
                Informing(bufferMessages.Unread.ToString(), "ВКонтакте");
        }


        VkApi AuthorizeInSN()
        {
            var services = new ServiceCollection();
            services.AddAudioBypass();
            var api = new VkApi(services);
            api.Authorize(new ApiAuthParams { Login = login, Password = pass });
            return api;
        }

 

        public override bool AuthorizeCheck(string login, string pass)
        {
            this.login =login;
            this.pass = pass;
            VkApi api ;
            try
            {
                api = AuthorizeInSN();
            }
            catch
            {
                return false;
            }
            return true;
        }
    }
}
