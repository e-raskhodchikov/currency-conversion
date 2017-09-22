using System.Collections.Generic;
using System.Web.Http;
using CurrencyConversion.WebApp.DataAccess;
using CurrencyConversion.WebApp.Dto;

namespace CurrencyConversion.WebApp.Controllers
{
    [RoutePrefix("api/currency")]
    public class CurrencyController : ApiController
    {
        private readonly CurrencyDao currencyDao;

        public CurrencyController(CurrencyDao currencyDao)
        {
            this.currencyDao = currencyDao;
        }

        public CurrencyController() : this(new CurrencyDao())
        {
        }

        [Route("")]
        public IEnumerable<CurrencyDto> GetCurrency() =>
            currencyDao.GetCurrency();

        [Route("{currencyFromId}/to/{currencyToId}/amount/{moneyAmount}")]
        public ExchangeRateDto Get(int currencyFromId, int currencyToId, decimal moneyAmount) =>
            currencyDao.GetExchangeRate(currencyFromId, currencyToId, moneyAmount);
    }
}
