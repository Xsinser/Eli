using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
namespace Eli
{
    class SQLDataWorkerClass
    {
        protected SQLiteConnection con = new SQLiteConnection("Data Source=usersBD.db; Password=Eli;");        
        private List<string> logins = new List<string>();
        private List<string> passes = new List<string>();
        public string getLogin(int index) {
            return logins[index];
         }
        public string getPass(int index)
        {
            return passes[index];
        }
        public string GetVK(string nameRow)
        {
            con.Open();
            var com = new SQLiteCommand($"Select {nameRow} from Data where typeCode='VK'", con);
            var bufString = com.ExecuteScalar();
            con.Close();
            if (bufString != null)
                return (string)bufString;
            else
                return "error";
        }

        public string GetDataMail()
        {
            con.Open();
            var com = new SQLiteCommand($"Select * from Data where type='Mail'", con);
            var bufString = com.ExecuteScalar();

            con.Close();
            if (bufString != null)
                return (string)bufString;
            else
                return "error";
        }

    }
}
