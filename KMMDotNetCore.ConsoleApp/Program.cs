// See https://aka.ms/new-console-template for more information
using System.Data;
using System.Data.SqlClient;

Console.WriteLine("Hello, World!");
//Console.ReadKey();

//ADO.NET
//Dapper / new version of  ADO.NET (ORM = object relational mapping)
//EFCore / entity framework (ORM)

string connectionString = "Data Source=.;Initial Catalog=DotNetTrainingBatch5;User ID=sa;Password=kmm@123";
Console.WriteLine("ConnectionString " + connectionString);
SqlConnection conn = new SqlConnection(connectionString);
Console.WriteLine("Connection Opening");
conn.Open();
Console.WriteLine("Connection Opened");

string query = @"SELECT [BlogId]
      ,[BlogTitle]
      ,[BlogAuthor]
      ,[BlogContent]
      ,[DeleteFlag]
  FROM [dbo].[Tbl_Blog] where DeleteFlag = 0";

SqlCommand cmd = new SqlCommand(query, conn);
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
conn.Close();
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
Console.ReadLine();