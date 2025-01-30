using Dapper;
using KMMDotNetCore.ConsoleApp.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KMMDotNetCore.ConsoleApp
{
    public class DapperExample
    {
        private readonly string _connectionString = "Data Source=.;Initial Catalog=DotNetTrainingBatch5;User ID=sa;Password=kmm@123";

        public void Read()
        {
            //using(IDbConnection db = new SqlConnection(_connectionString))
            //{
            //    string query = "select * from tbl_blog where DeleteFlag = 0;";
            //    var lst = db.Query(query).ToList();
            //    foreach (var item in lst)
            //    {
            //        Console.WriteLine(item.BlogId);
            //        Console.WriteLine(item.BlogTitle);
            //        Console.WriteLine(item.BlogAuthor);
            //        Console.WriteLine(item.BlogContent);
            //    }
            //}

            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                string query = "select * from tbl_blog where DeleteFlag = 0;";
                var lst = db.Query<BlogDapperDataModel>(query).ToList();
                foreach (var item in lst)
                {
                    Console.WriteLine(item.BlogId);
                    Console.WriteLine(item.BlogTitle);
                    Console.WriteLine(item.BlogAuthor);
                    Console.WriteLine(item.BlogContent);
                }
            }
        }

        public void Create(string title, string author, string content)
        {
            string query = $@"INSERT INTO [dbo].[Tbl_Blog]
                       ([BlogTitle]
                       ,[BlogAuthor]
                       ,[BlogContent]
                       ,[DeleteFlag])
                 VALUES
                       (@BlogTitle
                       ,@BlogAuthor
                       ,@BlogContent
                       ,0)";

            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                int result = db.Execute(query, new BlogDapperDataModel
                {
                    BlogTitle = title,
                    BlogAuthor = author,
                    BlogContent = content,
                });
                Console.WriteLine(result == 1 ? "Saving Successful." : "Saving Failed.");
            }
        }

        public void Edit(int id)
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                string query = "select * from tbl_blog where DeleteFlag = 0 and BlogId = @BlogId;";
                var item = db.Query<BlogDapperDataModel>(query, new BlogDapperDataModel
                {
                    BlogId = id
                }).FirstOrDefault();

                //if (item == null)
                if (item is null)
                {
                    Console.WriteLine("No Data Found.");
                    return;
                }

                Console.WriteLine(item.BlogId);
                Console.WriteLine(item.BlogTitle);
                Console.WriteLine(item.BlogAuthor);
                Console.WriteLine(item.BlogContent);

            }
        }

        public void Update(int id, string title, string author, string content)
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                string query = $@"UPDATE [dbo].[Tbl_Blog]
                   SET [BlogTitle] = @BlogTitle
                      ,[BlogAuthor] = @BlogAuthor
                      ,[BlogContent] = @BlogContent
                      ,[DeleteFlag] = 0
                 WHERE [BlogId] = @BlogId";

                var result = db.Execute(query, new BlogDapperDataModel
                {
                    BlogTitle = title,
                    BlogAuthor = author,
                    BlogContent = content,
                    BlogId = id
                });

                Console.WriteLine(result == 1 ? "Update Successful." : "Update Failed.");
            }
        }
    }
}
