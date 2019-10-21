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

        private void CollectionUpdate()
        {
            siTypes.Add("VK", new VKchecker());
            siTypes.Add("Mail", new Mchecker());
        }

        public Checker()
        {
            CollectionUpdate();
        }
        public void Check()
        {
            //for() перебор запросов и выхов 
            { }
            //конец?!
        }
    }
}
