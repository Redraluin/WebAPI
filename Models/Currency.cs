using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAPI.Models
{
    public class Currency
    {
        [Required]
        public Guid id { get; set; }
        [Required]
        public String coinName { get; set; }
        [Required]
        public int amount { get; set; }
        [Required]
        public float price { get; set; }
        [Required]
        public float transactionFee { get; set; }
    }
}
