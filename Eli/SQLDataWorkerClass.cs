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
        private DataBD data = new DataBD();

        public string GetVK(string nameRow)
        {
            con.Open();
            var com = new SQLiteCommand($"Select {nameRow} from dataTable where typeCode='VK'", con);
            var bufString = com.ExecuteScalar();
            con.Close();
            if (bufString != null)
                return (string)bufString;
            else
                return "error";
        }

        public DataBD getAllBDData()
        {
            return data;
        }
        public void InsertData(string login, string pass, string type)
        {
            con.Open();
            var com = new SQLiteCommand($"insert into dataTable values ('{type}','nul','{login}','{pass}')", con);

            var bufString = com.ExecuteScalar();

            con.Close();
        }


        public DataBD GetDataMail()
        {
            con.Open();
            var com = new SQLiteCommand($"Select * from dataTable", con);
            var reader = com.ExecuteReader();


            // if (reader.HasRows)
            reader.Read(); 
            object i = reader.GetValue(0);
            {
                while(reader.Read())
                {//2,3,0
                    data.Add((string)reader.GetValue(2), (string)reader.GetValue(3), (string)reader.GetValue(0));
                }
            }
            con.Close();
            return data;
        }

    }
}
