using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StockMarket
{
    public class Investor
    {
        private readonly List<Stock> Portfolio;

        public Investor(string fullName, string emailAddress, decimal moneyToInvest, string brokerName)
        {
            Portfolio = new List<Stock>();
            FullName = fullName;
            EmailAddress = emailAddress;
            MoneyToInvest = moneyToInvest;
            BrokerName = brokerName;
        }

        public string FullName { get; set; }
        public string EmailAddress { get; set; }
        public decimal MoneyToInvest { get; set; }
        public string BrokerName { get; set; }
        public int Count { get => Portfolio.Count; }


        public void BuyStock(Stock stock)
        {
            if (stock.MarketCapitalization > 10000 && MoneyToInvest >= stock.PricePerShare)
            {
                MoneyToInvest -= stock.PricePerShare;
                Portfolio.Add(stock);
            }
        }

        public string SellStock(string companyName, decimal sellPrice)
        {
            var currStock = Portfolio.FirstOrDefault(x => x.CompanyName == companyName);

            if (currStock == null)
            {
                return $"{companyName} does not exist.";
            }
            else if (sellPrice < currStock.PricePerShare)
            {
                return $"Cannot sell {companyName}.";
            }
            
            MoneyToInvest += sellPrice;
            Portfolio.Remove(currStock);
            return $"{companyName} was sold.";
        }

        public Stock FindStock(string companyName)
        {
            var currStock = Portfolio.FirstOrDefault(x => x.CompanyName == companyName);
            
            return currStock;
        }

        public Stock FindBiggestCompany()
        {
            var currStock = Portfolio.OrderByDescending(x => x.MarketCapitalization);

            return currStock.FirstOrDefault();
        }

        public string InvestorInformation()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"The investor {FullName} with a broker {BrokerName} has stocks: ");

            foreach (var item in Portfolio)
            {
                sb.AppendLine(item.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
