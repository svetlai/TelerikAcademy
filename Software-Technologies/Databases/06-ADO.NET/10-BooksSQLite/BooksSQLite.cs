namespace ADO.BooksSQLite
{
    using System;
    using System.Data.SQLite;

    /// <summary>
    /// 10. Re-implement the previous task with SQLite embedded DB (see http://sqlite.phxsoftware.com).
    /// </summary>
    public class BooksSQLite
    {
        public static void Main()
        {
            string connToSQLiteString = @"Data Source=../../BooksDB/BooksDB.sqlite;Version=3;Pooling=True;Max Pool Size=100;";
            SQLiteConnection dbConn = new SQLiteConnection(connToSQLiteString);

            dbConn.Open();
            using (dbConn)
            {
                Console.WriteLine("Connecting to SQLite database Books was successful.");

                string bookTitle = "Divergent";
                string isbn = "1234-6321-2343";
                string publishDate = "2014-03-15";
                string author = "Veronica Roth";

                AddBook(dbConn, bookTitle, isbn, publishDate, author);

                ListAllBooks(dbConn);
                SearchForBook(dbConn);

                dbConn.Close();
            }
        }

        public static void ListAllBooks(SQLiteConnection connection)
        {
            string query = "SELECT * FROM Books";
            SQLiteCommand cmdSelectAll = new SQLiteCommand(query, connection);
            var reader = cmdSelectAll.ExecuteReader();

            using (reader)
            {
                while (reader.Read())
                {
                    var bookId = reader["BookId"];
                    string bookTitle = (string)reader["BookTitle"];
                    string isbn = (string)reader["ISBN"];
                    string publishDate = (string)reader["publishDate"];
                    string author = (string)reader["Author"];

                    Console.WriteLine("BookID: {0} \nTitle: {1}\nISBN: {2} \nPublish Date: {3} \nAuthor {4}",
                                        bookId, bookTitle, isbn, publishDate, author);
                    Console.WriteLine("----");
                }
            }
        }

        public static void SearchForBook(SQLiteConnection connection)
        {
            Console.WriteLine("Type a string to search for: ");
            string toSearch = EscapeCharacters(Console.ReadLine());

            string queryBook = "SELECT * FROM Books WHERE BookTitle LIKE @toSearch";
            SQLiteCommand cmdBooks = new SQLiteCommand(queryBook, connection);

            cmdBooks.Parameters.AddWithValue("@toSearch", "%" + toSearch + "%");

            Console.WriteLine("Books found: ");
            Console.WriteLine();

            var reader = cmdBooks.ExecuteReader();

            using (reader)
            {
                while (reader.Read())
                {
                    var bookId = reader["BookId"];
                    string bookTitle = (string)reader["BookTitle"];
                    string isbn = (string)reader["ISBN"];
                    string publishDate = (string)reader["publishDate"];
                    string author = (string)reader["Author"];

                    Console.WriteLine("BookID: {0} \nTitle: {1}\nISBN: {2} \nPublish Date: {3} \nAuthor: {4}",
                                       bookId, bookTitle, isbn, publishDate, author);
                    Console.WriteLine("----");
                }
            }
        }

        public static void AddBook(SQLiteConnection connection, string bookTitle, string isbn, string publishDate, string author)
        {
            string query = "INSERT INTO Books (BookTitle, ISBN, PublishDate, Author) VALUES (@bookTitle, @isbn, @publishDate, @author)";

            SQLiteCommand cmdInsertBook = new SQLiteCommand(query, connection);

            cmdInsertBook.Parameters.AddWithValue("@bookTitle", bookTitle);
            cmdInsertBook.Parameters.AddWithValue("@isbn", isbn);
            cmdInsertBook.Parameters.AddWithValue("@publishDate", publishDate);
            cmdInsertBook.Parameters.AddWithValue("@author", author);

            cmdInsertBook.ExecuteNonQuery();

            Console.WriteLine("Book added successfully.");
        }

        private static string EscapeCharacters(string input)
        {
            input = input.Replace(@"\", @"[\]");
            input = input.Replace(@"%", @"[%]");
            input = input.Replace(@"_", @"[_]");
            input = input.Replace(@"'", @"[']");
            return input;
        }
    }
}

