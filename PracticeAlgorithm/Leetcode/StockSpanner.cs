using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeAlgorithm.Leetcode
{
    /// <summary>
    /// URL. https://leetcode.com/problems/online-stock-span/
    /// </summary>
    public class StockSpanner
    {
        Stack<int> prices, weighs;
        public StockSpanner()
        {
            prices = new Stack<int>();
            weighs = new Stack<int>();
        }

        public int Next(int price)
        {
            int w = 1;
            //int currPrice = price;
            while(prices.Count > 0 && prices.Peek() <= price)
            {
                prices.Pop();
                w += weighs.Pop();
            }

            prices.Push(price);
            weighs.Push(w);

            return w;
        }
    }
}
