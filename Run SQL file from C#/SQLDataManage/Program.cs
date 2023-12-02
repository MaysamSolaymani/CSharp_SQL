using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLDataManage
{
    class Program
    {
        static void Main(string[] args)
        {
            string script = null;
            script = File.ReadAllText("CreateDB.sql");
            string[] ScriptSplitter = script.Split(new string[] { "GO" }, StringSplitOptions.None);
            SqlConnection cn = new SqlConnection(@"Password=test;Persist Security Info=True; User ID=test; Initial Catalog=master; Data Source=.");
            SqlCommand cm;
            using (cn)
            {
                cn.Open();
                
                foreach (string str in ScriptSplitter)
                {
                    using (cm = cn.CreateCommand())
                    {
                        cm.CommandText = str;
                        cm.ExecuteNonQuery();
                    }
                }
            }
        }
    }
}
