using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransportBusiness
{
    interface ISql
    {
        void CreateDatabase(string DBName);
        void CreateTable(string TableName);
        void EditRow(string TableName, int id);
        void InserIntoTable(string TableName);
        void DeleteFromTable(string TableName, int id);
        void ReadTable(string TableName);
    }
    class Sql: ISql
    {
        public SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
        public Sql()
        {
            builder.DataSource = "sd\\test_sql";
            builder.InitialCatalog = "master";
            builder.UserID = "stud";
            builder.Password = "123456789";
        }

        public void CreateDatabase(string DBName)
        {
            try
            {
                Console.Write("Connection to SQl Server...");
                using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
                {
                    connection.Open();
                    Console.Write($"Dropping and creating database {DBName}... ");
                    string sql = $"CREATE DATABASE {DBName}";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.ExecuteNonQuery();
                        Console.WriteLine("Done.");
                    }
                    connection.Close();
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.ToString());
            }
        }
        public void CreateTable(string TableName)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
                {
                    connection.Open();
                    Console.Write("Creating a table. Press any key...");
                    Console.ReadKey(true);
                    StringBuilder sb = new StringBuilder();
                    sb.Append($"CREATE TABLE {TableName} ( ");
                    sb.Append(" ID INT IDENTITY(1, 1) NOT NULL PRIMARY KEY, ");
                    string column;
                    do
                    {
                        Console.Write("Enter the name of column (0 to exit): ");
                        column = Console.ReadLine();
                        if (column != "0")
                        {
                            Console.Write("Enter the type of the column(and amount of symbols if it is necessary): ");
                            string type = Console.ReadLine();
                            sb.Append($" {column} {type}, ");
                        }
                    } while (column != "0");
                    sb.Remove(sb.Length - 2, 2);
                    string sql = sb.ToString();
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.ExecuteNonQuery();
                        Console.WriteLine("Done!");
                    }
                    connection.Close();
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        public void EditRow(string TableName, int id)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
                {
                    connection.Open();
                    StringBuilder sb = new StringBuilder();
                    string column;
                    do
                    {
                        Console.Write("Enter column name to update (0 to exit): ");
                        column = Console.ReadLine();
                        if (column != "0")
                        {
                            Console.Write("Enter new value: ");
                            string value = Console.ReadLine();
                            sb.Append($" UPDATE {TableName} SET {column} = {value} WHERE ID = {id.ToString()} ");
                        }
                    } while (column != "0");
                    string sql = sb.ToString();
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.ExecuteNonQuery();
                        Console.WriteLine("Done!");
                    }
                    connection.Close();
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        public void InserIntoTable(string TableName)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
                {
                    connection.Open();
                    StringBuilder sb = new StringBuilder();
                    sb.Append($"INSERT INTO {TableName} VALUES (");
                    string column;
                    do
                    {
                        Console.Write("Enter the value (0 to exit): ");
                        column = Console.ReadLine();
                        if (column != "0")
                        {
                            sb.Append($" {column} , ");
                        }
                    } while (column != "0");
                    sb.Remove(sb.Length - 2, 2);
                    string sql = sb.ToString();
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.ExecuteNonQuery();
                        Console.WriteLine("Done!");
                    }
                    connection.Close();
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        public void DeleteFromTable(string TableName, int id)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
                {
                    connection.Open();
                    string sql = $"DELETE FROM {TableName} WHERE ID = {id.ToString()}";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.ExecuteNonQuery();
                        Console.WriteLine("Done!");
                    }
                    connection.Close();
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        public void ReadTable(string TableName)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
                {
                    connection.Open();
                    string sql = $"SELECT * FROM {TableName}";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.ExecuteNonQuery();
                        Console.WriteLine("Done!");
                    }
                    connection.Close();
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.ToString());
            }
        }
    }
    class Algorithm
    {

    }
}
