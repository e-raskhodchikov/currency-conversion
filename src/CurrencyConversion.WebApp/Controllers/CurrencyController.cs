using System;
using System.Collections.Generic;
using System.Web.Http;
using CurrencyConversion.WebApp.Dto;

namespace CurrencyConversion.WebApp.Controllers
{
    [RoutePrefix("api/currency")]
    public class CurrencyController : ApiController
    {
        private readonly CurrencyDto[] currency =
        {
            new CurrencyDto {Id = 1, Name = "RUB"},
            new CurrencyDto {Id = 2, Name = "USD"},
            new CurrencyDto {Id = 3, Name = "EUR"}
        };

        [Route("")]
        public IEnumerable<CurrencyDto> Get()
        {
            return currency;
        }

        [Route("{currencyFromId}/to/{currencyToId}/of/{moneyAmount}")]
        public ExchangeRateDto Get(int currencyFromId, int currencyToId, decimal moneyAmount)
        {
            return new ExchangeRateDto
            {
                CurrencyFrom = currency[currencyFromId - 1],
                CurrencyTo = currency[currencyToId - 1],
                MoneyAmount = moneyAmount,
                ExchangeRate = new Random().Next(1, 100)
            };
        }
    }
}
