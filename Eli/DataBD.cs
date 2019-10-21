using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eli
{
    class DataBD
    {
        private List<string> logins = new List<string>();
        private List<string> passes = new List<string>();
        private List<string> types = new List<string>();
        public string getLogin(int index)
        {
            return logins[index];
        }
        public string getPass(int index)
        {
            return passes[index];
        }
        public string getType(int index)
        {
            return types[index];
        }
        public void Add(string login, string pass,string type)
        {
            logins.Add(login);
            passes.Add(pass);
            types.Add(type);
        }
    }
}
