using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    public class Connector
    {
        public delegate void newTradeEvent();

        public event newTradeEvent NewTradeEvent;

        public List<Trade> Trades = new List<Trade>();

        private void NewTrade(Trade trade)
        {
            Trades.Add(trade);

            //NewTradeEvent();
        }

        public void Connect()
        {
            Console.WriteLine("Connected");
        }
    }
}
