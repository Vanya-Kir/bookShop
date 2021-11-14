using Store;
using System;
using Xunit;

namespace bookShop.Tests
{
    public class BookTests 
    {
        [Fact]
        public void IsIsbn_WithNull_ReturnFalse()
        {
            bool actual = Book.IsIsbn(null);
            Assert.False(actual);
        }        
        [Fact]
        public void IsIsbn_WithBlankString_ReturnFalse()
        {
            bool actual = Book.IsIsbn("  ");
            Assert.False(actual);
        }        
        [Fact]
        public void IsIsbn_WithIsbd10_ReturnTrue()
        {
            bool actual = Book.IsIsbn("IsBN 123-456-789 0");
            Assert.True(actual);
        }
        [Fact]
        public void IsIsbn_WithIsbd13_ReturnTrue()
        {
            bool actual = Book.IsIsbn("IsBN 123-123-4657 0- 21");
            Assert.True(actual);
        }
        [Fact]
        public void IsIsbn_WithTradhStart_ReturnFalse()
        {
            bool actual = Book.IsIsbn("uISBn 123-123-4657 0- 213");
            Assert.False(actual);
        }
        [Fact]
        public void IsIsbn_WithTrashFinish_ReturnFalse()
        {
            bool actual = Book.IsIsbn("ISBn 123-123-4657 0- 213b");
            Assert.False(actual);
        }
    }
}
