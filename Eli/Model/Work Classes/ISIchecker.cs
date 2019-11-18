using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eli
{
    interface ISIchecker
    {
            void Check(string login, string pass);
        bool AuthorizeCheck(string login, string pass);
    }
}
