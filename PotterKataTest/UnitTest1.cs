using Microsoft.VisualStudio.TestTools.UnitTesting;
using PotterKata;
using System;

namespace PotterKataTest
{
    [TestClass]
    public class UnitTest1
    {
        private static BasketCalculator basketCalculator = new BasketCalculator();

        private const double price = 8;
        private const double twoBookDiscount = 0.95;
        private const double threeBookDiscount = 0.90;
        private const double fourBookDiscount = 0.80;
        private const double fiveBookDiscount = 0.75;

        [TestMethod]
        public void No_Book_Costs_0()
        {
            Assert.AreEqual(0 * price, basketCalculator.CalculateBasketCost());
        }

        [TestMethod]
        public void One_Book_Costs_8()
        {
            Assert.AreEqual(price, basketCalculator.CalculateBasketCost(0));
        }

        [TestMethod]
        public void Two_Distinct_Book_Costs_15_2()
        {
            Assert.AreEqual(price * 2 * twoBookDiscount, basketCalculator.CalculateBasketCost(0,1));
        }

        [TestMethod]
        public void Two_Same_Book_Costs_16()
        {
            Assert.AreEqual(price * 2, basketCalculator.CalculateBasketCost(0,0));
        }

        [TestMethod]
        public void Three_Distinct_Book_Costs_21_6()
        {
            Assert.AreEqual(price * 3 * threeBookDiscount, basketCalculator.CalculateBasketCost(0,1,2));
        }

        [TestMethod]
        public void Three_Same_Book_Costs_24()
        {
            Assert.AreEqual(price * 3, basketCalculator.CalculateBasketCost(0,0,0));
        }

        [TestMethod]
        public void Four_Distinct_Book_Costs_25_6()
        {
            Assert.AreEqual(price * 4 * fourBookDiscount, basketCalculator.CalculateBasketCost(0,1,2,3));
        }

        [TestMethod]
        public void Four_Same_Book_Costs_32()
        {
            Assert.AreEqual(price * 4, basketCalculator.CalculateBasketCost(0, 0, 0, 0));
        }

        [TestMethod]
        public void Five_Distinct_Book_Costs_30()
        {
            Assert.AreEqual(price * 5 * fiveBookDiscount, basketCalculator.CalculateBasketCost(0, 1 , 2, 3, 4));
        }

        [TestMethod]
        public void Two_Sets_of_Two_Distinct_Book_Costs_()
        {
            Assert.AreEqual(((price * 3 * threeBookDiscount)+price), basketCalculator.CalculateBasketCost(0, 1, 0, 2));
        }


        // more complex tests
        [TestMethod]
        public void Test_Basket_Costs_23_20()
        {
            Assert.AreEqual((price * 2 * twoBookDiscount) + price, basketCalculator.CalculateBasketCost(0, 0, 1));
        }

        [TestMethod]
        public void Test_Basket_Costs_30_40()
        {
            Assert.AreEqual((price * 2 * twoBookDiscount) * 2, basketCalculator.CalculateBasketCost(0, 0, 1, 1));
        }

        [TestMethod]
        public void Test_Basket_Costs_30_4jk0()
        {
            Assert.AreEqual((price * 4 * fourBookDiscount) + (price * 2 * twoBookDiscount), basketCalculator.CalculateBasketCost(0, 0, 1, 2, 2, 3));
        }

        [TestMethod]
        public void Test_Basket_Costs_30_hjk40()
        {
            Assert.AreEqual(8 + (8 * 5 * 0.75), basketCalculator.CalculateBasketCost(0, 1, 1, 2, 3, 4));
        }

        [TestMethod]
        public void Test_Basket_Costs_51_20()
        {
            Assert.AreEqual((price * 4 * fourBookDiscount)*2, basketCalculator.CalculateBasketCost(0, 0, 1, 1, 2, 2, 3, 4));
        }

        [TestMethod]
        public void Test_Basket_Costs_141_20()
        {
            Assert.AreEqual(3 * (price * 5 * fiveBookDiscount) + 2 * (price * 4 * fourBookDiscount), basketCalculator.CalculateBasketCost(0, 0, 0, 0, 0, 1, 1, 1, 1, 1, 2, 2, 2, 2, 3, 3, 3, 3, 3, 4, 4, 4, 4));
        }

        [TestMethod]
        public void Test_Basket_Costs_I_have_no_idea_but_its_ridiculous()
        {
            Assert.AreEqual(3 * (price * 5 * fiveBookDiscount) + 2 * (price * 4 * fourBookDiscount), basketCalculator.CalculateBasketCost(0,0,0,0,0,0,0,0, 0, 0, 0, 0, 1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1, 2, 2, 2,2,2,2, 2, 3, 3,3,3,3,3,3, 3, 3, 3, 4, 4, 4, 4,4));
        }

        // 12 * 0
        // 20 * 1
        // 7 * 2
        // 10 * 3
        // 5 * 4
    }
}
