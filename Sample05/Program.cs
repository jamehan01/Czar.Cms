using Dapper;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
namespace Sample05
{
    class Program
    {
        ///<summary>
        ///测试插入单条数据
        /// </summary>
        static void test_insert()
        {
            var content = new Content
            {
                title = "标题1",
                content = "内容1",
            };
            using (var conn = new SqlConnection("Data Source=127.0.0.1;User ID=sa;Password=hn123654!;Initial Catalog=CMS;Pooling=true;Max Pool Size=100;"))
            {
                string sql_insert = @"INSERT INTO [Content]
                    (title,[content],status,add_time,modify_time)
                    VALUES (@title,@content,@status,@add_time,@modify_time)";
                var result = conn.Execute(sql_insert, content);
                Console.WriteLine($"test_insert:插入了{result}条数据!");
            }
        }
        static void test_mult_insert()
        {
            List<Content> contents = new List<Content>()
            {
                new Content
                {
                    title = "批量插入标题1",
                    content = "批量插入内容1",
                },
                 new Content
                {
                    title = "批量插入标题2",
                    content = "批量插入内容2",
                },

            };          
            using (var conn = new SqlConnection("Data Source=127.0.0.1;User ID=sa;Password=hn123654!;Initial Catalog=CMS;Pooling=true;Max Pool Size=100;"))
            {
                string sql_insert = @"INSERT INTO [Content]
                    (title,[content],status,add_time,modify_time)
                    VALUES (@title,@content,@status,@add_time,@modify_time)";
                var result = conn.Execute(sql_insert, contents);
                Console.WriteLine($"test_insert:插入了{result}条数据!");
            }
        }
        static void Main(string[] args)
        {
            /*test_insert();*/
            test_mult_insert();
        }
    }
}
