using System;
using Store;
using System.Linq;

namespace bookShop.Memory
{
    public class BookRepository : IBookRepository
    {
        private readonly Book[] books = new[]
        {
            new Book(1, "ISBN 12312-31231", "Толстой", "Война и мир"),
            new Book(2, "ISBN 12312-00000", "Пушкин", "Капитанская дочка"),
            new Book(3, "ISBN 33333-31231", "Гейтс", "Программирование "),
            new Book(4, "ISBN 66666-77777", "Горький", "Мать"),
        };

        public Book[] GetAllByIsbn(string isbn)
        {
            return books.Where(book => book.Isbn == isbn).ToArray();
        }

        public Book[] GetAllByTitleOrAuthor(string query)
        {
            return books.Where(book => book.Author.Contains(query)
                                    || book.Title.Contains(query))
                        .ToArray();
        }
    }
}
