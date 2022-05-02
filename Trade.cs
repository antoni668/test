using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    public class Trade
    {
        #region Fields

        public decimal Price = 0;

        public string SecCode = "";

        public string ClassCode = "";

        public string Portfolio = "";

        public DateTime DateTime = DateTime.MinValue;

        public Trend Trend;

        #endregion

        #region Properties

        public decimal Volume
        {
            get
            {
                return _volume;
            }

            set
            {
                _volume = value;
            }
        }

        decimal _volume = 0;

        #endregion
    }
}
