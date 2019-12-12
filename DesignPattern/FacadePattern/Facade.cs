using System;

namespace Facade
{
    // 子系统类
    #region 子系统类
    class Stock_1
    {
        public void Buy()
        {
            Console.WriteLine("购买股票1");
        }
        public void Sell()
        {
            Console.WriteLine("出售股票1");
        }
    }

    class Stock_2
    {
        public void Buy()
        {
            Console.WriteLine("购买股票2");
        }
        public void Sell()
        {
            Console.WriteLine("出售股票2");
        }
    }

    class Stock_3
    {
        public void Buy()
        {
            Console.WriteLine("购买股票3");
        }
        public void Sell()
        {
            Console.WriteLine("出售股票3");
        }
    }

    class NationalDebt_1
    {
        public void Buy()
        {
            Console.WriteLine("购买国债1");
        }
        public void Sell()
        {
            Console.WriteLine("出售国债1");
        }
    }

    class Realty_1
    {
        public void Buy()
        {
            Console.WriteLine("购买房地产1");
        }
        public void Sell()
        {
            Console.WriteLine("出售房地产1");
        }
    }
    #endregion

    // 外观类:
    // -------
    class Fund
    {
        Stock_1 Stock_1;
        Stock_2 Stock_2;
        Stock_3 Stock_3;
        NationalDebt_1 NationalDebt_1;
        Realty_1 Realty_1;

        public Fund()
        {
            Stock_1 = new Stock_1();
            Stock_2 = new Stock_2();
            Stock_3 = new Stock_3();
            NationalDebt_1 = new NationalDebt_1();
            Realty_1 = new Realty_1();
        }

        public void BuyFund()
        {
            Stock_1.Buy();
            Stock_2.Buy();
            Stock_3.Buy();
            NationalDebt_1.Buy();
            Realty_1.Buy();
        }

        public void SellFund()
        {
            Stock_1.Sell();
            Stock_2.Sell();
            Stock_3.Sell();
            NationalDebt_1.Sell();
            Realty_1.Sell();
        }
    }

    // 客户端:
    // ------
    class Client
    {
        static void Main(string[] args)
        {
            Fund fund = new Fund();

            fund.BuyFund();
            Console.WriteLine();
            fund.SellFund();

            Console.Read();
        }
    }
}
