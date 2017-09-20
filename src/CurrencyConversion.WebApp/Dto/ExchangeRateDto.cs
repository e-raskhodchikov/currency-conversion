namespace CurrencyConversion.WebApp.Dto
{
    public class ExchangeRateDto
    {
        public CurrencyDto CurrencyFrom { get; set; }

        public CurrencyDto CurrencyTo { get; set; }

        public decimal MoneyAmount { get; set; }

        public decimal ExchangeRate { get; set; }
    }
}
