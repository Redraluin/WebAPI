using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPI.Models;

namespace WebAPI.Repository
{
    public interface ICurrency
    {
        public IEnumerable<Currency> GetCurrency();
        public Currency GetCurrency(Guid id);
        public void CreateCurrency(Currency currency);
        public void UpdateCurrency(Guid id, Currency currency);
        public void DeleteCurrency(Guid id);
    }
}
