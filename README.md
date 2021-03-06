
# SuperSimpleStockMarket

### Requirements

Provide working source code that will:

 1. For a given stock,
	- Given any price as input, calculate the dividend yield
	- Given any price as input, calculate the P/E Ratio
	- Record a trade, with timestamp, quantity of shares, buy or sell indicator and traded price
	- Calculate Volume Weighted Stock Price based on trades in past 15 minutes
2. Calculate the GBCE All Share Index using the geometric mean of prices for all stocks

### Constraints & Notes

1. Written in one of these languages:
	- Java, C#, C++, Python
2. No database or GUI is required, all data need only be held in memory
3. No prior knowledge of stock markets or trading is required – all formulas are provided below.

#### Table 1. Sample data from the Global Beverage Corporation Exchange
|Stock Symbol|Type| Last Dividend| Fixed Dividend|Par Value|
|--|--|--|--|--|
|TEA|Common|0||100|
|POP|Common|8||100|
|ALE|Common|23||60|
|GIN|Preferred|8|2%|100|
|JOE|Common|13||250|

> All number values in pennies

#### Table 2. Formula
![Formula table](./images/formulas.png)