using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace KMMDotNetCore.ConsoleApp
{
    public class AdoDotNet
    {
        private readonly string _connectionString = "Data Source=.;Initial Catalog=DotNetTrainingBatch5;User ID=sa;Password=kmm@123";
        public void Read()
        {
            Console.WriteLine("ConnectionString " + _connectionString);
            SqlConnection connection = new SqlConnection(_connectionString);

            Console.WriteLine("Connection Opening");
            connection.Open();
            Console.WriteLine("Connection Opened");

            string query = @"SELECT [BlogId]
                        ,[BlogTitle]
                        ,[BlogAuthor]
                        ,[BlogContent]
                        ,[DeleteFlag]
                    FROM [dbo].[Tbl_Blog] where DeleteFlag = 0";

            SqlCommand cmd = new SqlCommand(query, connection);
            //SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            //DataTable dt = new DataTable();
            //adapter.Fill(dt); //Fill is execute in sql

            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                Console.WriteLine(reader["BlogId"]);
                Console.WriteLine(reader["BlogTitle"]);
                Console.WriteLine(reader["BlogAuthor"]);
                Console.WriteLine(reader["BlogContent"]);
            }

            Console.WriteLine("Connectino Closing");
            connection.Close();
            Console.WriteLine("Connection Closed");

            //Dataset
            //Datatable
            //Datarow
            //Datacolumn

            //foreach (DataRow dr in dt.Rows)
            //{
            //    Console.WriteLine(dr["BlogId"]);
            //    Console.WriteLine(dr["BlogTitle"]);
            //    Console.WriteLine(dr["BlogAuthor"]);
            //    Console.WriteLine(dr["BlogContent"]);
            //}
        }

        public void Create()
        {
            Console.WriteLine("Blog Title: ");
            string title = Console.ReadLine();

            Console.WriteLine("Blog Author: ");
            string author = Console.ReadLine();

            Console.WriteLine("Blog Content: ");
            string content = Console.ReadLine();

            SqlConnection connection = new SqlConnection(_connectionString);
            Console.WriteLine("Connection Opening...");
            connection.Open();
            Console.WriteLine("Connection Opened...");

            //string queryInsert = $@"INSERT INTO [dbo].[Tbl_Blog]
            //           ([BlogTitle]
            //           ,[BlogAuthor]
            //           ,[BlogContent]
            //           ,[DeleteFlag])
            //     VALUES
            //           ('{title}'
            //           ,'{author}'
            //           ,'{content}'
            //           ,0)";

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

            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@BlogTitle", title);
            cmd.Parameters.AddWithValue("@BlogAuthor", author);
            cmd.Parameters.AddWithValue("@BlogContent", content);

            //SqlDataAdapter adapter = new SqlDataAdapter(cmdInsert);
            //DataTable dt = new DataTable();
            //adapter.Fill(dt);

            int result = cmd.ExecuteNonQuery();

            string value = result == 1 ? "Saving Successful." : "Saving Failed";
            Console.WriteLine(value);

            Console.WriteLine("Connection Closing...");
            connection.Close();
            Console.WriteLine("Connection Closed...");
        }

        public void Edit()
        {
            Console.Write("Blog Id: ");
            string id = Console.ReadLine();

            SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();

            string query = @"SELECT [BlogId]
                      ,[BlogTitle]
                      ,[BlogAuthor]
                      ,[BlogContent]
                      ,[DeleteFlag]
                  FROM [dbo].[Tbl_Blog] where BlogId = @BlogId";

            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@BlogId", id);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);

            connection.Close();

            if (dt.Rows.Count == 0)
            {
                Console.WriteLine("No data found");
                return;
            }

            DataRow dr = dt.Rows[0];
            Console.WriteLine(dr["BlogId"]);
            Console.WriteLine(dr["BlogTitle"]);
            Console.WriteLine(dr["BlogAuthor"]);
            Console.WriteLine(dr["BlogContent"]);
        }

        public void Update()
        {
            Console.Write("Blog Id: ");
            string id = Console.ReadLine();

            Console.Write("Blog Title: ");
            string title = Console.ReadLine();

            Console.Write("Blog Author: ");
            string author = Console.ReadLine();

            Console.Write("Blog Content: ");
            string content = Console.ReadLine();

            SqlConnection connection = new SqlConnection(_connectionString);
            Console.WriteLine("Connection Opening...");
            connection.Open();
            Console.WriteLine("Connection Opened...");

            string query = $@"UPDATE [dbo].[Tbl_Blog]
                   SET [BlogTitle] = @BlogTitle
                      ,[BlogAuthor] = @BlogAuthor
                      ,[BlogContent] = @BlogContent
                      ,[DeleteFlag] = 0
                 WHERE [BlogId] = @BlogId";

            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@BlogTitle", title);
            cmd.Parameters.AddWithValue("@BlogAuthor", author);
            cmd.Parameters.AddWithValue("@BlogContent", content);
            cmd.Parameters.AddWithValue("@BlogId", id);

            int result = cmd.ExecuteNonQuery();

            string value = result == 1 ? "Saving Successful." : "Saving Failed";
            Console.WriteLine(value);

            Console.WriteLine("Connection Closing...");
            connection.Close();
            Console.WriteLine("Connection Closed...");
        }

        public void Delete()
        {
            Console.Write("Blog Id: ");
            string id = Console.ReadLine();

            SqlConnection connection = new SqlConnection(_connectionString);
            Console.WriteLine("Connection Opening...");
            connection.Open();
            Console.WriteLine("Connection Opened...");

            string query = $@"UPDATE [dbo].[Tbl_Blog]
            SET [DeleteFlag] = @DeleteFlag
          WHERE [BlogId] = @BlogId";

            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@DeleteFlag", 1);
            cmd.Parameters.AddWithValue("@BlogId", id);

            int result = cmd.ExecuteNonQuery();

            string value = result == 1 ? "Successfully Deleted" : "Fail to Delete";
            Console.WriteLine(value);

            Console.WriteLine("Connection Closing...");
            connection.Close();
            Console.WriteLine("Connection Closed...");
        }
    }
}
