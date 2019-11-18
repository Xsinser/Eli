using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eli
{
    class Checker
    {
        Dictionary<string, ISIchecker> siTypes = new Dictionary<string, ISIchecker>(2);
        private SQLDataWorkerClass worker;
        DataBD data;
        private void CollectionUpdate()
        {
            siTypes.Add("VK", new VKchecker());
            siTypes.Add("Mail", new Mchecker());
        }

        public Checker()
        {
            CollectionUpdate();
            worker  = new SQLDataWorkerClass();
        }
        public void Check()
        {
            data = worker.GetDataMail();
            int ia = data.length;
            for (int i=0;i<ia;i++)
            {

                if (siTypes[data.getType(i)].AuthorizeCheck(data.getLogin(i), data.getPass(i)))
                    siTypes[data.getType(i)].Check(data.getLogin(i), data.getPass(i));
            }
            //конец?!
        }
    }
}
