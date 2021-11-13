using System;
using Store;
using System.Linq;

namespace bookShop.Memory
{
    public class BookRepository : IBookRepository
    {
        private readonly Book[] books = new[]
        {
            new Book(1, "Война и мир"),
            new Book(2, "Пушкин"),
            new Book(3, "Программирование "),
            new Book(4, "Горький"),
        };
        public Book[] GetAllByTitle(string titlePart)
        {
            return books.Where(book => book.Title.Contains(titlePart)).ToArray();
        }
    }
}
