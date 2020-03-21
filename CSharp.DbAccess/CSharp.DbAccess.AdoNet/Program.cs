using MySql.Data.MySqlClient;
using System;
using System.Data;

namespace CSharp.DbAccess.AdoNet
{
    class Program
    {
        static void Main(string[] args)
        {
            var strConn = "Data Source=127.0.0.1;port=3306;Initial Catalog=mycourse;user id=root;password=North@09170302;Character Set=utf8;";
            var dataSet = new DataSet();

            using (var conn = new MySqlConnection(strConn))
            {
                var dataAbp = new MySqlDataAdapter("SELECT * FROM mycourse.`user`;SELECT * FROM mycourse.course;", conn);
                dataAbp.Fill(dataSet);
            }

            foreach (DataRow row in dataSet.Tables[0].Rows)
            {
                Console.WriteLine($"Id:{row["Id"]},Name:{row["Name"]}, Pwd:{row["Password"]}");
            }
            //using (var conn = new MySqlConnection(strConn))
            //{
            //    conn.Open();
            //    var command = new MySqlCommand("SELECT * FROM mycourse.`user`", conn);
            //    var reader = command.ExecuteReader();
            //    while (reader.Read())
            //    {
            //        Console.WriteLine($"Id:{reader["Id"]},Name:{reader["Name"]}");
            //    }
            //    conn.Close();
            //}

            // SQL 注入如何处理？
            // 还是要手写SQL，如何能不写SQL？
            // 返回数据如何映射一个类上面？
            
        }
    }
}
;