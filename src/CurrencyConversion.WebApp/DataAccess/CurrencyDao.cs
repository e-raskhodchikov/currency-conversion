using System;
using System.Collections.Generic;
using System.Linq;
using CurrencyConversion.WebApp.Dto;

namespace CurrencyConversion.WebApp.DataAccess
{
    public class CurrencyDao : BaseDao
    {
        public List<CurrencyDto> GetCurrency() =>
            Query<CurrencyDto>(@"
select
    Id,
    AlphabeticCode,
    Name
from Currency
").ToList();

        public ExchangeRateDto GetExchangeRate(int currencyFromId, int currencyToId, decimal moneyAmount) =>
            Query<ExchangeRateDto>(@"
select
    ExchangeRate,
    Date
from ExchangeRate
where
    CurrencyFromId = @currencyFromId and
    CurrencyToId = @currencyToId
order by Date
limit 1", new
            {
                currencyFromId,
                currencyToId,
                moneyAmount
            }).FirstOrDefault();
    }
}
