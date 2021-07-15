using System.Collections.Generic;
using System.Linq;

namespace PotterKata
{
    public class BasketCalculator
    {
        private List<BookSet> bookSets = new List<BookSet>();
        private decimal finalCost;
        private int numberOfBookSetsNeeded;

        public decimal GetBasketCost(params int[] basket)
        {
            ResetBasket();

            // if there's no book in the basket just return 0
            if(!basket.Any())
                return finalCost;

            CalculateRequiredNumberOfBookSets(basket);

            CreateBookSets();

            var orderedBasket = OrderBooksInBasket(basket);

            CalculateBookSets(orderedBasket);

            // return final cost
            return GetBasketTotal();

        }

        /// <summary>
        /// Figures out the best set to put the book into based on the cost that book will add to the bookset
        /// </summary>
        /// <param name="bookId"></param>
        /// <returns></returns>
        private int FindOptimumBooksetForBook(int bookId)
        {
            decimal predictedCostForThisSetIfBookIsAdded = decimal.MaxValue;
            decimal currentSetPriceForThisBook = decimal.MaxValue;
            decimal lowestPriceOfferedForThisBook = decimal.MaxValue;
            int optimumBookSetId = -1;

            foreach(var set in bookSets)
            {
                if(set.CanAddBook(bookId))
                {
                    set.AddBook(bookId);
                    predictedCostForThisSetIfBookIsAdded = set.CalculateCost();
                    set.RemoveBook(bookId);
                }

                currentSetPriceForThisBook = predictedCostForThisSetIfBookIsAdded - set.CalculateCost();


                // if this is the best price offered for this book, this current set is the best home for the book and update the lowestOfferedPrice
                if (currentSetPriceForThisBook < lowestPriceOfferedForThisBook)
                {
                    optimumBookSetId = set.Id;
                    lowestPriceOfferedForThisBook = currentSetPriceForThisBook;
                }

            }

            return optimumBookSetId;
        }

        private decimal GetBasketTotal()
        {
            finalCost = 0;

            foreach (var set in bookSets)
            {
                finalCost += set.CalculateCost();
            }

            return finalCost;
        }

        private void ResetBasket()
        {
            bookSets.Clear();
            finalCost = 0;
            numberOfBookSetsNeeded = 0;
        }


        private IEnumerable<int> OrderBooksInBasket(params int[] basket)
        {
            // order the books by their 'ID'
            var orderedBasket = basket.GroupBy(book => book)
                .OrderBy(group => group.Key)
                .SelectMany(book => book);

            return orderedBasket;
        }

        private void CalculateRequiredNumberOfBookSets(params int[] basket)
        {
            // figure out how many booksets we need
            numberOfBookSetsNeeded = basket.GroupBy(book => book)
                .OrderBy(group => group.Key)
                .Select(group => group.Count()).Max();
        }

        private void CreateBookSets()
        {
            // create all the booksets we need
            for (int i = 0; i < numberOfBookSetsNeeded; i++)
            {
                bookSets.Add(new BookSet(i));
            }
        }

        private void CalculateBookSets(IEnumerable<int> orderedBasket)
        {
            foreach (var book in orderedBasket)
            {
                int optmimumBookSetId;

                optmimumBookSetId = FindOptimumBooksetForBook(book);

                bookSets.FirstOrDefault(set => set.Id == optmimumBookSetId).AddBook(book);
            }
        }

    }
}
