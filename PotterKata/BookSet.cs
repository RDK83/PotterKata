using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PotterKata
{
    internal class BookSet
    {
        private List<int> books = new List<int>();
        private const decimal price = 8m;

        public BookSet(int id)
        {
            Id = id;
        }


        public int Id { get; set; }

        public decimal CalculateCost()
        {
            var booksInSet = books.Count;

            switch (booksInSet)
            {
                case 5:
                    return ((booksInSet * price) *0.75m);
                case 4:
                    return ((booksInSet * price) * 0.8m);
                case 3:
                    return ((booksInSet * price) * 0.9m);
                case 2:
                    return ((booksInSet * price) * 0.95m);
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

        public void RemoveBook(int bookId)
        {
            books.Remove(bookId);
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
