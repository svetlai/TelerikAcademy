namespace ADO.BooksMySQL
{
    using System;
    using System.IO;

    using MySql.Data.MySqlClient;

    /// <summary>
    /// 9. Download and install MySQL database, MySQL Connector/Net (.NET Data Provider for MySQL) + MySQL Workbench GUI 
    /// administration tool . Create a MySQL database to store Books (title, author, publish date and ISBN). 
    /// Write methods for listing all books, finding a book by name and adding a book.
    /// </summary>
    public class BooksMySQLDB
    {
        public static void Main()
        {
            string connToMySqlString = @"Server=localhost;Uid=root;Pwd=;Allow User Variables=True;";

            MySqlConnection dbConn = new MySqlConnection(connToMySqlString);

            CreateDB(dbConn);

            string bookTitle = "Allegiant";
            string isbn = "1234-7321-2343";
            string publishDate = "2013-12-15";
            int authorId = 2;

            AddBook(dbConn, bookTitle, isbn, publishDate, authorId);

            Console.WriteLine();

            ListAllBooks(dbConn);
            SearchForBook(dbConn);
        }

        public static void CreateDB(MySqlConnection connection)
        {
            StreamReader sqlScript = new StreamReader("../../Create-Books-Script.sql");
            
            connection.Open();

            using (connection)
            {
                MySqlCommand createDB = new MySqlCommand(sqlScript.ReadToEnd(), connection);

                createDB.ExecuteNonQuery();
            }

            connection.Close();

            Console.WriteLine("Database Books was created.");
        }

        public static void ListAllBooks(MySqlConnection connection)
        {
            connection.Open();

            using(connection)
            {
                string query = "SELECT * FROM booksdb.Books b INNER JOIN booksdb.Authors a ON a.AuthorID = b.Author_AuthorId";
                MySqlCommand cmdSelectAll = new MySqlCommand(query, connection);
                MySqlDataReader reader = cmdSelectAll.ExecuteReader();

                using (reader)
                {
                    while (reader.Read())
                    {
                        int bookId = (int)reader["BookId"];
                        string bookTitle = (string)reader["BookTitle"];
                        string isbn = (string)reader["ISBN"];
                        DateTime publishDate = (DateTime)reader["publishDate"];
                        string authorFirstName = (string)reader["FirstName"];
                        string authorLastName = (string)reader["LastName"];

                        Console.WriteLine("BookID: {0} \nTitle: {1}\nISBN: {2} \nPublish Date: {3} \nAuthor {4} {5}",
                                           bookId, bookTitle, isbn, publishDate, authorFirstName, authorLastName);
                        Console.WriteLine("----");
                    }
                }
            }

            connection.Close();
        }

        public static void SearchForBook(MySqlConnection connection)
        {
            Console.WriteLine("Type a string to search for: ");
            string toSearch = EscapeCharacters(Console.ReadLine());
            
            connection.Open();

            using (connection)
            {
                string queryBook = "SELECT * FROM booksdb.Books b INNER JOIN booksdb.Authors a ON a.AuthorID = b.Author_AuthorId WHERE b.BookTitle LIKE @toSearch";
                MySqlCommand cmdBooks = new MySqlCommand(queryBook, connection);

                cmdBooks.Parameters.AddWithValue("@toSearch", "%" + toSearch + "%");

                Console.WriteLine("Books found: ");
                Console.WriteLine();

                MySqlDataReader reader = cmdBooks.ExecuteReader();

                using (reader)
                {
                    while (reader.Read())
                    {
                        int bookId = (int)reader["BookId"];
                        string bookTitle = (string)reader["BookTitle"];
                        string isbn = (string)reader["ISBN"];
                        DateTime publishDate = (DateTime)reader["publishDate"];

                        Console.WriteLine("BookID: {0} \nTitle: {1}\nISBN: {2} \nPublish Date: {3}",
                                           bookId, bookTitle, isbn, publishDate);
                        Console.WriteLine("----");
                    }
                }
            }

            connection.Close();
        }

        public static void AddBook(MySqlConnection connection, string bookTitle, string isbn, string publishDate, int authorId)
        {
            connection.Open();

            using (connection)
            {
                string query = "INSERT INTO booksdb.Books (BookTitle, ISBN, PublishDate, Author_AuthorId) VALUES (@bookTitle, @isbn, @publishDate, @authorId)";

                MySqlCommand cmdInsertBook = new MySqlCommand(query, connection);

                cmdInsertBook.Parameters.AddWithValue("@bookTitle", bookTitle);
                cmdInsertBook.Parameters.AddWithValue("@isbn", isbn);
                cmdInsertBook.Parameters.AddWithValue("@publishDate", publishDate);
                cmdInsertBook.Parameters.AddWithValue("@authorId", authorId);

                cmdInsertBook.ExecuteNonQuery();

                Console.WriteLine("Book added successfully.");
            }

            connection.Close();
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
