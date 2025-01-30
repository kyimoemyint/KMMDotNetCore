// See https://aka.ms/new-console-template for more information
using KMMDotNetCore.ConsoleApp;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Channels;

Console.WriteLine("Hello, World!");
//Console.ReadKey();

//ADO.NET
//Dapper / new version of  ADO.NET (ORM = object relational mapping)
//EFCore / entity framework (ORM)

//AdoDotNet adoDotNet = new AdoDotNet();
//adoDotNet.Read();
//adoDotNet.Create();
//adoDotNet.Edit();
//adoDotNet.Update();
//adoDotNet.Delete();

DapperExample dapperExample = new DapperExample();
//dapperExample.Read();
//dapperExample.Create("asdfasdf", "asdfasdfief", "aljljhopjlj");
//dapperExample.Edit(1);
//dapperExample.Edit(5);
//dapperExample.Update(3, "apple", "kmm", "some apple");

//EFCoreExample eFCoreExample = new EFCoreExample();
//eFCoreExample.Read();
//eFCoreExample.Create("earth", "jack sparrow", "sailing");
//eFCoreExample.Update(5, "iii", "iiiii", "abababab");
//eFCoreExample.Delete(5);
Console.ReadLine();