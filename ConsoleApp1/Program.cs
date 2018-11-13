using System;
using System.Text.RegularExpressions;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            string sql = "truncate table m";
            SqlPaser.SqlPaser paser = new SqlPaser.SqlPaser();
            paser.Paser(sql);
            var v=  paser.Permission;

        }
    }
}
