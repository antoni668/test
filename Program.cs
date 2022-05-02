using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    public class Program
    {
        static void Main(string[] args)
        {
            Connector.Connect();

            Load();

            Connector.NewTradeEvent += WriteLine;

            Position.NewPositionEvent += PositionHandler;

            WriteLine();

            Console.ReadLine();
        }

        #region Fields

        static List<Level> levels;

        static decimal priceUp;

        static decimal priceDown;

        static decimal stepLevel;

        static decimal lotLevel;

        static Connector Connector = new Connector();

        static Position Position =new Position();

        #endregion

        #region Properties
        public static decimal StepLevel
        {
            get
            {
                return stepLevel;
            }

            set
            {
                stepLevel = value;

                levels = Level.CalculateLevels(priceUp, priceDown, stepLevel);
            }
        }

        #endregion

        #region Methods
        static void WriteLine()
        {
            Console.WriteLine("\nКол-во элементов в списке: " + levels.Count.ToString() + "\n");
            Console.WriteLine("Нижняя цена: " + priceDown.ToString());
            Console.WriteLine("Верхняя цена: " + priceUp.ToString());
            Console.WriteLine("Шаг цены: " + StepLevel.ToString() + "\n");
 
            for (int i = 0; i < levels.Count; i++)
            {
                Console.WriteLine(levels[i].PriceLevel);
            }

            Console.WriteLine("\n" + new String('=', 20) + "\n");
        }

        static string ReadLine(string message)
        {
            Console.WriteLine(message);

            string str = Console.ReadLine();

            return str;
        }

        static void Save()
        {
            using (StreamWriter writer = new StreamWriter("params.txt", false))
            {
                writer.WriteLine(priceDown.ToString());
                writer.WriteLine(priceUp.ToString());
                writer.WriteLine(stepLevel.ToString());
            }
        }

        static void Load()
        {
            using (StreamReader reader = new StreamReader("params.txt"))
            {
                int index = 0;

                while (true)
                {
                    string line = reader.ReadLine();

                    index++;

                    if (index == 1)
                    {
                        priceDown = decimal.Parse(line);
                    }
                    else if (index == 2)
                    {
                        priceUp = decimal.Parse(line); ;
                    }
                    else if (index == 3)
                    {
                        StepLevel = decimal.Parse(line); ;
                    }

                    if (line == null)
                    {
                        break;
                    }
                }
            }
        }

        static void PositionHandler(Trend position, Trend newPosition)
        {
            if (position != newPosition && Position.isTradingBegin)
            {
                Console.WriteLine("Позиция изменилась");

                Position.VolumePosition++;
            }
        }

        #endregion
    }
}
