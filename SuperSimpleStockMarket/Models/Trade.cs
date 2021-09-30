using SuperSimpleStockMarket.Helper;
using SuperSimpleStockMarket.Models.Enum;
using System;

namespace SuperSimpleStockMarket.Models
{
    /// <summary>
    /// Class for Trade transacation
    /// </summary>
    public class Trade
    {
        public string StockSymbol { get; set; }
        public DateTime Timestamp { get; set; }
        public TradeOperation Operation { get; set; }
        public float Price { get; set; }
        public int Quantity { get; set; }

        public Trade()
        {
            Timestamp = DateTime.Now;
        }

        public override string ToString()
        {
            return $"{Timestamp,ConsoleHelper.Padding} | {StockSymbol,ConsoleHelper.Padding} | {Operation,ConsoleHelper.Padding} | {Price,ConsoleHelper.Padding} | {Quantity,ConsoleHelper.Padding}";
        }

        public string ToSummary()
        {
            return $"{Timestamp} - {StockSymbol} - {Operation} - Price: {Price} - Quantity: {Quantity}";
        }
    }
}
