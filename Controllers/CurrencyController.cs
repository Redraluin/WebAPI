using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPI.Dtos;
using WebAPI.Models;
using WebAPI.Repository;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("currencies")]
    public class CurrencyController : ControllerBase
    {
        private ICurrency _CurrencyRepository;
        public CurrencyController(ICurrency currencyRepo)
        {
            _CurrencyRepository = currencyRepo;
            //_CurrencyRepository = new InMemoryRepository();
        }
        [HttpGet]
        public ActionResult<IEnumerable<CurrencyDTO>> GetCurrency()
        {
            return _CurrencyRepository.GetCurrency()
                .Select(x => new CurrencyDTO { id = x.id, coinName = x.coinName, amount = x.amount, price = x.price, transactionFee = x.transactionFee })
                .ToList();
        }
        [HttpGet("{id}")]
        public ActionResult<CurrencyDTO> GetCurrency(Guid id)
        {
            var currency = _CurrencyRepository.GetCurrency(id);

            if (currency == null)
                return NotFound();

            var currencyDTO = new CurrencyDTO
            { id = currency.id, coinName = currency.coinName, amount = currency.amount, price = currency.price, transactionFee = currency.transactionFee };


            return currencyDTO;
        }
        [HttpPost]
        public ActionResult CreateCurrency(CreateDTO currency)
        {
            var newCurrency = new Currency();
            newCurrency.id = Guid.NewGuid();
            newCurrency.coinName = currency.coinName;
            newCurrency.price = currency.price;
            newCurrency.amount = currency.amount;
            newCurrency.transactionFee = currency.transactionFee;

            _CurrencyRepository.CreateCurrency(newCurrency);

            return Ok();
        }
        [HttpPut("{id}")]
        public ActionResult UpdateCurrency(Guid id, UpdateDTO currency)
        {
            var newCurrency = _CurrencyRepository.GetCurrency(id);

            if (newCurrency == null)
                return NotFound();

            newCurrency.price = currency.price;
            newCurrency.amount = currency.amount;
            newCurrency.transactionFee = currency.transactionFee;

            _CurrencyRepository.UpdateCurrency(id, newCurrency);

            return Ok();
        }
        [HttpDelete("{id}")]
        public ActionResult DeleteCurrency(Guid id)
        {
            var currency = _CurrencyRepository.GetCurrency(id);
            if (currency == null) return NotFound();

            _CurrencyRepository.DeleteCurrency(id);
            return Ok();
        }
    }
}
