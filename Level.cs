using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    public class Level
    {
        #region Fields

        public decimal PriceLevel = 0;

        public static decimal LotLevel = 0;

        public decimal Volume = 100;

        #endregion

        #region Methods

        public static List<Level> CalculateLevels(decimal priceUp, decimal priceDown, decimal step)
        {
            List<Level> levels = new List<Level>();

            decimal priceLevel = priceUp;

            decimal stepCount = (priceUp - priceDown) / step;

            stepCount = (int)stepCount;

            for (decimal i = 0; i <= stepCount; i++)
            {
                Level level = new Level();

                level.PriceLevel = priceLevel;

                levels.Add(level);

                priceLevel -= step;
            }

            return levels;
        }

        #endregion
    }
}
