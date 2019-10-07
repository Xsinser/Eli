using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.Speech.Synthesis;
namespace Eli
{
   abstract class SImain
    {
        //abstr methods
        public abstract void Check(string login, string pass);
        public abstract bool AuthorizeCheck(string login, string pass);


        
        protected string login = "", pass = "";




        protected void Informing(string countM, string typeSN)
        {
            SpeechSynthesizer synthesizer = new SpeechSynthesizer();
            synthesizer.Volume = 100;
            synthesizer.Rate = 0;
            synthesizer.Speak($"У вас обнаружено {countM} не прочитанное сообщение в {typeSN}");
        }
    }
}
