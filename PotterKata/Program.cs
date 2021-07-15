using System;

namespace PotterKata
{
    class Program
    {
        static void Main(string[] args)
        {
            var basketCalc = new BasketCalculator();

            //basketCalc.CalculateBasketCost(0, 0, 0, 0, 0, 1, 1, 1, 1, 1, 2, 2, 2, 2, 3, 3, 3, 3, 3, 4, 4, 4, 4);
            //basketCalc.CalculateBasketCost(0, 0, 1, 1, 2, 2, 3, 4);
            basketCalc.CalculateBasketCost(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 2, 2, 2, 2, 2, 2, 2, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 4, 4, 4, 4, 4);
            //basketCalc.CalculateBasketCost();
            //basketCalc.CalculateBasketCost(0,1,0,2);
        }
    }
}
