using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PotterKata
{
    public class BasketCalculator
    {
        public double CalculateBasketCost(params int[] basket)
        {
            double naturalCost = CalculateNaturalBookSetCost(basket);
            double alternateCost = CalculateAlternateBookSetCost(basket);

            if (alternateCost < naturalCost)
                return alternateCost;

            return naturalCost;
        }

        /// <summary>
        /// Calculates the cost of a basket based on the assumption that filling complete sets is the most heavily discounted
        /// </summary>
        /// <param name="basket"></param>
        /// <returns></returns>
        private double CalculateNaturalBookSetCost(params int[] basket)
        {
            var bookSets = new List<BookSet>();
            double totalCost = 0;

            if (bookSets.Count == 0)
                bookSets.Add(new BookSet());

            foreach (var bookId in basket)
            {
                bool bookAdded = false;

                for (int i = 0; i < bookSets.Count; i++)
                {
                    // if we cant add the book to this set, check the next one
                    if (!bookSets[i].CanAddBook(bookId))
                        continue;
                    // otherwise add the book to this set and break out of this loop
                    if (bookSets[i].CanAddBook(bookId))
                    {
                        bookSets[i].AddBook(bookId);
                        bookAdded = true;
                        break;
                    }
                }

                // if the book wasnt added to any existing sets, create a new one and add the book
                if (!bookAdded)
                {
                    bookSets.Add(new BookSet(bookId));
                    continue;
                }
            }

            foreach (var set in bookSets)
            {
                totalCost += set.CalculateCost();
            }

            return totalCost;
        }


        /// <summary>
        /// Calculates the cost of a basket based on the assumption that filling complete sets is the most heavily discounted
        /// </summary>
        /// <param name="basket"></param>
        /// <returns></returns>
        private double CalculateAlternateBookSetCost(params int[] basket)
        {
            var bookSets = new List<BookSet>(){ new BookSet() };

            foreach (var bookId in basket)
            {
                bool bookAdded = false;
                bool protectBookSetIfPossible = false;

                for (int i = 0; i < bookSets.Count; i++)
                {
                    // if we already have 4 books in the set, we want to try to keep it that way
                    if (bookSets[i].ReturnCount() == 4)
                        protectBookSetIfPossible = true;

                    // if we cant add the book to this set, check the next one
                    if (!bookSets[i].CanAddBook(bookId))
                        continue;

                    // if this bookSet isnt a protected set of 4 already, add the book if it fits
                    if (bookSets[i].CanAddBook(bookId) && !protectBookSetIfPossible)
                    {
                        bookSets[i].AddBook(bookId);
                        bookAdded = true;
                        break;
                    }
                    

                    // if we get to here, then all previous bookSets either
                    // already have this book
                    // or already have 4 books in, so we're trying not to put a 5th book in

                    // if there are any bookSets that can accept this book, lets try to fit it in
                    if (bookSets.Any(b => !b.ContainsBook(bookId)))
                    {
                        // there is at least one bookset with space for this book
                        for (int j = i; j < bookSets.Count; j++)
                        {
                            protectBookSetIfPossible = false;

                            // try not to use this set but if we have to, we will later...
                            if (bookSets[j].ReturnCount() == 4)
                                protectBookSetIfPossible = true;


                            if (bookSets[j].CanAddBook(bookId) && !protectBookSetIfPossible)
                            {
                                bookSets[j].AddBook(bookId);
                                bookAdded = true;
                                break;
                            }
                            if (bookAdded)
                                break;
                        }
                    }

                    // if we still havent managed to add the book to somewhere, just stick it in anywhere it will fit
                    if (!bookAdded)
                    {
                        for (int k = 0; k < bookSets.Count; k++)
                        {
                            if (bookSets[k].CanAddBook(bookId))
                            {
                                bookSets[k].AddBook(bookId);
                                bookAdded = true;
                                break;
                            }
                        }
                    }
                    break;
                }

                // if the book wasnt added to any existing sets, create a new one and add the book
                if (!bookAdded)
                {
                    bookSets.Add(new BookSet(bookId));
                    continue;
                }
            }

            double totalCost = 0;
            // add up the costs of each set
            foreach (var set in bookSets)
            {
                totalCost += set.CalculateCost();
            }

            return totalCost;

        }



    }
}
