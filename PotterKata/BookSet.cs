using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PotterKata
{
    class BookSet
    {
        private List<int> books = new List<int>();
        private const int price = 8;

        public BookSet()
        {

        }
        public BookSet(int bookId)
        {
            AddBook(bookId);
        }

        public double CalculateCost()
        {
            var booksInSet = books.Count;

            switch (booksInSet)
            {
                case 5:
                    return ((booksInSet * price) *0.75);
                case 4:
                    return ((booksInSet * price) * 0.8);
                case 3:
                    return ((booksInSet * price) * 0.9);
                case 2:
                    return ((booksInSet * price) * 0.95);
                case 1:
                    return (booksInSet *price);
                case 0:
                    return 0;
                default:
                    return 0;
            }

        }

        public bool CanAddBook(int bookId)
        {
            if (books.Contains(bookId))
                return false;

            return true;
        }

        public void AddBook(int bookId)
        {
            books.Add(bookId);
        }

        public int ReturnCount()
        {
            return books.Count();
        }

        public bool ContainsBook(int bookId)
        {
            return books.Contains(bookId);
        }
    }
}
