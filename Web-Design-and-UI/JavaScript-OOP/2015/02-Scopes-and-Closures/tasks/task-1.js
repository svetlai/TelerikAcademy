/* Task Description */
/* 
 *	Create a module for working with books
 *	The module must provide the following functionalities:
 *	Add a new book to category
 *	Each book has unique title, author and ISBN
 *	It must return the newly created book with assigned ID
 *	If the category is missing, it must be automatically created
 *	List all books
 *	Books are sorted by ID
 *	This can be done by author, by category or all
 *	List all categories
 *	Categories are sorted by ID
 *	Each book/catagory has a unique identifier (ID) that is a number greater than or equal to 1
 *	When adding a book/category, the ID is generated automatically
 *	Add validation everywhere, where possible
 *	Book title and category name must be between 2 and 100 characters, including letters, digits and special characters ('!', ',', '.', etc)
 *	Author is any non-empty string
 *	Unique params are Book title and Book ISBN
 *	Book ISBN is an unique code that contains either 10 or 13 digits
 *	If something is not valid - throw Error
 */
function solve() {
    var library = (function () {
        var CONST = {
            MIN_TITLE_LENGTH: 2,
            MAX_TITLE_LENGTH: 100,
            MIN_CATEGORY_LENGTH: 2,
            MAX_CATEGORY_LENGTH: 100,
            ISBN_TEN_DIGITS_LENGTH: 10,
            ISBN_THIRTEEN_DIGITS_LENGTH: 13
        };

        var books = [];
        var categories = [];

        function listBooks() {
            var filterObj = arguments[0];

            books = books.sort(function (firstBook, secondBook) {
                return firstBook.ID - secondBook.ID;
            });

            if (filterObj) {
                books = books.filter(function (book) {
                    return book.author === filterObj.author || book.category === filterObj.category;
                });
            }

            return books;
        }

        function addBook(book) {
            if (book.title && !isBookPropertyLengthValid(book, 'title', CONST.MIN_TITLE_LENGTH, CONST.MAX_TITLE_LENGTH)) {
                throw new Error('Book title must be between ' + CONST.MIN_TITLE_LENGTH + ' and ' + CONST.MAX_TITLE_LENGTH + ' characters long.')
            }

            if (book.title && bookPropertyExists(books, book, 'title')) {
                throw new Error('A book with this title already exists in the collection.');
            }

            if (book.isbn && (!isBookPropertyLengthValid(book, 'isbn', CONST.ISBN_TEN_DIGITS_LENGTH) && !isBookPropertyLengthValid(book, 'isbn', CONST.ISBN_THIRTEEN_DIGITS_LENGTH))) {
                throw new Error('ISBN must be ' + CONST.ISBN_TEN_DIGITS_LENGTH + ' or ' + CONST.ISBN_THIRTEEN_DIGITS_LENGTH + ' characters long.');
            }

            if (book.isbn && bookPropertyExists(books, book, 'isbn')) {
                throw new Error('A book with this ISBN already exists in the collection.');
            }

            if (!isString(book.author) || book.author === '') {
                throw new Error('Author cannot be left empty.');
            }

            if (!book.category) {
                book.category = 'Unknown';
            }

            if (!isBookPropertyLengthValid(book, 'category', CONST.MIN_CATEGORY_LENGTH, CONST.MAX_CATEGORY_LENGTH)) {
                throw new Error('Category name must be between ' + CONST.MIN_CATEGORY_LENGTH + ' and ' + CONST.MAX_CATEGORY_LENGTH + ' characters long.')
            }

            book.ID = books.length + 1;
            books.push(book);

            var category = {
                ID: categories.length + 1,
                name: book.category
            };

            if (!categoryExists(categories, book)) {
                categories.push(category);
            }

            return book;
        }

        function listCategories() {
            categories = categories.sort(function (firstCategory, secondCategory) {
                return firstCategory.ID - secondCategory.ID;
            }).map(function (category) {
                return category.name;
            });

            return categories;
        }

        // validation checks:
        function isString(input) {
            return typeof(input) === "string";
        }

        function bookPropertyExists(books, book, property) {
            return books.some(function (bookInCollection) {
                return bookInCollection[property] === book[property];
            });
        }

        function categoryExists(categories, book) {
            return categories.some(function (category) {
                return category.name === book.category;
            });
        }

        function isBookPropertyLengthValid(book, property, minLength, maxLength) {
            minLength = minLength || 0;
            maxLength = maxLength || minLength;

            return book[property].length >= minLength && book[property].length <= maxLength;
        }

        return {
            books: {
                list: listBooks,
                add: addBook
            },
            categories: {
                list: listCategories
            }
        };
    }());
    return library;
}

module.exports = solve;
