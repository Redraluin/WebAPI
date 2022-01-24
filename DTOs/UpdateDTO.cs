using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAPI.Dtos
{
    public record UpdateDTO
    {
        [Required]
        public int amount { get; set; }
        [Required]
        public float price { get; set; }
        [Required]
        public float transactionFee { get; set; }
    }
}
