using BibleApp.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace BibleApp.Services
{
    public class DAO
    {
        string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=bible;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        public List<BibleVerse> searchTerm(string searchString) 
        {
            List<BibleVerse> results = new List<BibleVerse>();

            string sqlStatement = "SELECT * FROM dbo.t_kjv WHERE t LIKE @searchString";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(sqlStatement, connection);

                command.Parameters.AddWithValue("@searchString", '%' + searchString + '%');


                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        results.Add(new BibleVerse((int)reader[0], (int)reader[1], getBookNameById((int)reader[1]), (int)reader[2], (int)reader[3], (string)reader[4], "", 0, null));
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            return results;
        }

        public List<BibleVerse> seacrhOldTestament(string searchString)
        {
            List<BibleVerse> results = new List<BibleVerse>();

            string sqlStatement = "SELECT* FROM dbo.t_kjv WHERE b BETWEEN 1 AND 39 AND t LIKE @searchString";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(sqlStatement, connection);

                command.Parameters.AddWithValue("@searchString", '%' + searchString + '%');


                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        results.Add(new BibleVerse((int)reader[0], (int)reader[1], getBookNameById((int)reader[1]), (int)reader[2], (int)reader[3], (string)reader[4], "", 0, null));
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            return results;
        }

        public List<BibleVerse> searchNewTestament(string searchString)
        {
            List<BibleVerse> results = new List<BibleVerse>();

            string sqlStatement = "SELECT* FROM dbo.t_kjv WHERE b BETWEEN 39 AND 66 AND t LIKE @searchString";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(sqlStatement, connection);

                command.Parameters.AddWithValue("@searchString", '%' + searchString + '%');


                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        results.Add(new BibleVerse((int)reader[0], (int)reader[1], getBookNameById((int)reader[1]), (int)reader[2], (int)reader[3], (string)reader[4], "", 0, null));
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            return results;
        }

        public BibleVerse searchVerse(BibleVerse verse) 
        {
            BibleVerse result = new BibleVerse();
            List<string> verseRangeText = new List<string>();

            string sqlStatement = "SELECT * FROM dbo.t_kjv WHERE b LIKE @searchBook AND c LIKE @searchChapter AND v BETWEEN @verseBeginning AND @verseEnd";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(sqlStatement, connection);

                command.Parameters.AddWithValue("@searchBook",  verse.Book );
                command.Parameters.AddWithValue("@searchChapter", verse.Chapter );
                command.Parameters.AddWithValue("@verseBeginning", verse.Verse);
                command.Parameters.AddWithValue("@verseEnd", verse.LastVerse);


                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        verseRangeText.Add((string)reader[4]);
                        result = new BibleVerse((int)reader[0], (int)reader[1], verse.BookName , (int)reader[2], verse.Verse, "", verse.VerseRange, verse.LastVerse,
                           verseRangeText);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            return result;
        }

        public BibleVerse getBookName(BibleVerse verse)
        {            
            string sqlStatement = "SELECT Book FROM dbo.book WHERE Id LIKE @searchBook";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(sqlStatement, connection);

                command.Parameters.AddWithValue("@searchBook", verse.Book);              


                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        verse.BookName = (string)reader[0];
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            return verse;
        }

        public string getBookNameById(int bookId)
        {
            string result = "";
            string sqlStatement = "SELECT Book FROM dbo.book WHERE Id LIKE @bookId";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(sqlStatement, connection);

                command.Parameters.AddWithValue("@bookId", bookId);


                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        string res = (string)reader[0];
                        result = res;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }            
            return result;
        }

        public BibleVerse getBookNumber(BibleVerse verse)
        {
            string sqlStatement = "SELECT * FROM dbo.book WHERE Book LIKE @bookName";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(sqlStatement, connection);

                command.Parameters.AddWithValue("@bookName", verse.BookName);


                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        verse.Book = (int)reader[0];
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            return verse;
        }

        public List<string> getVerseRangeText(int verseBeginning, int verseEnd) 
        {
            List<string> result = new List<string>();

            string sqlStatement = "SELECT t FROM dbo.t_kjv WHERE v BETWEEN @verseBeginning AND @verseEnd";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(sqlStatement, connection);

                command.Parameters.AddWithValue("@verseBeginning", verseBeginning);
                command.Parameters.AddWithValue("@verseEnd", verseEnd);


                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        result.Add((string)reader[0]);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            return result;
        }
    }
}
