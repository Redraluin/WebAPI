using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPI.Models;

namespace WebAPI.Repository
{
    public class InMemoryRepository : ICurrency
    {
        private List<Currency> _Currencies;
        public InMemoryRepository()
        {
            _Currencies = new() { new Currency { id=Guid.NewGuid(), coinName = "ada", amount = 10, price = 1.43f, transactionFee = 10 } };
        }
        public void CreateCurrency(Currency currency)
        {
            _Currencies.Add(currency);

            //throw new NotImplementedException();
        }

        public void DeleteCurrency(Guid id)
        {
            var currencyIndex = _Currencies.FindIndex(x => x.id == id);
            if (currencyIndex > -1)
                _Currencies.RemoveAt(currencyIndex);
            //throw new NotImplementedException();
        }

        public IEnumerable<Currency> GetCurrency()
        {
            return _Currencies;
            //throw new NotImplementedException();
        }

        public Currency GetCurrency(Guid id)
        {
            var currency = _Currencies.Where(x => x.id == id).SingleOrDefault();
            return currency;
            //throw new NotImplementedException();
        }

        public void UpdateCurrency(Guid id, Currency currency)
        {
            var currencyIndex = _Currencies.FindIndex(x=>x.id==id);
            if (currencyIndex > -1)
                _Currencies[currencyIndex] = currency;

            //throw new NotImplementedException();
        }
    }
}
