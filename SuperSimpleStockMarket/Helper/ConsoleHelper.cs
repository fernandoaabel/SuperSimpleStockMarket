using System;

namespace SuperSimpleStockMarket.Helper
{
    public static class ConsoleHelper
    {
        public const int Padding = 19;

        public static void SeparatorLine()
        {
            Console.WriteLine($"{"".PadLeft(110, '-')}");
        }
    }
}
