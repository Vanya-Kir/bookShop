using Moq;
using Store;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace bookShop.Tests
{
    public class BookServiceTests
    {
        [Fact]
        public void GetAllByQuery_WhisIsbn_CallsGetAllByIsbn()
        {
            var bookRepositoryStub = new Mock<IBookRepository>();
            bookRepositoryStub.Setup(x => x.GetAllByIsbn(It.IsAny<string>()))
                .Returns(new[] { new Book(1, "", "", "") });
            bookRepositoryStub.Setup(x => x.GetAllByTitleOrAuthor(It.IsAny<string>()))
                .Returns(new[] { new Book(2, "", "", "") });
            var validIsbn = "ISBN 123-456-789 0";
            var bookService = new BookService(bookRepositoryStub.Object);
            var actual = bookService.GetAllByQuery(validIsbn);
            Assert.Collection(actual, book => Assert.Equal(1, book.Id));
        }

        [Fact]
        public void GetAllByQuery_WhisAuthor_CallsGetAllByTitleOrAuthor()
        {
            var bookRepositoryStub = new Mock<IBookRepository>();
            bookRepositoryStub.Setup(x => x.GetAllByIsbn(It.IsAny<string>()))
                .Returns(new[] { new Book(1, "", "", "") });
            bookRepositoryStub.Setup(x => x.GetAllByTitleOrAuthor(It.IsAny<string>()))
                .Returns(new[] { new Book(2, "", "", "") });
            var invalidIsbn = "123-456-789 0";
            var bookService = new BookService(bookRepositoryStub.Object);
            var actual = bookService.GetAllByQuery(invalidIsbn);
            Assert.Collection(actual, book => Assert.Equal(2, book.Id));
        }
    }
}
