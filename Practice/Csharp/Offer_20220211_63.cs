using System;

namespace CsharpExam
{
    // https://leetcode-cn.com/problems/gu-piao-de-zui-da-li-run-lcof/
    // 63 股票的最大利润
    public class Offer_20220211_63
    {
        public int MaxProfit(int[] prices)
        {
            //注意，题设仅为买卖一次
            int minPrice = Int32.MaxValue;
            int maxProfit = 0;

            for (int i = 0; i < prices.Length; i++)
            {
                if (prices[i] < minPrice)
                    minPrice = prices[i];
                else
                {
                    if (prices[i] - minPrice > maxProfit)
                        maxProfit = prices[i] - minPrice;
                }
            }

            return maxProfit;
        }
    }
}