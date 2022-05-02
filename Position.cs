using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace ConsoleApp
{
    public class Position
    {
        public Position()
        {
            Timer timer = new Timer();

            timer.Interval = 1000;

            timer.Elapsed += NewTrade;

            timer.Start();
        }

        #region Fields

        public decimal Lot = 0;

        public decimal OpenPrice = 0;

        public DateTime DateTime = DateTime.MinValue;

        public string ClassCode = "";

        public string SecCode = "";

        public decimal VolumePosition = 1;

        public Trend position;

        Trend currentPosition;

        public bool isTradingBegin;


        #endregion

        public delegate void newPositionEvent(Trend position, Trend newPosition);

        public event newPositionEvent NewPositionEvent;

        Random random = new Random();

        private void NewTrade(object sender, ElapsedEventArgs e)
        {
            Trade Trade = new Trade();

            int num = random.Next(-10, 10);

            if (num > 0)
            {
                position = Trend.Long;
            }
            else if (num < 0)
            {
                position = Trend.Short;
            }

            NewPositionEvent(currentPosition, position);

            currentPosition = position;

            Trade.Volume = Math.Abs(num);

            Trade.Price = random.Next(70000, 80000);

            string str = "Volume = " + Trade.Volume.ToString() + " / Price = " + Trade.Price.ToString() + " / Position = " + position + " / Volume Position = " + VolumePosition;

            Console.WriteLine(str);

            isTradingBegin = true;
        }


        
    }
}
