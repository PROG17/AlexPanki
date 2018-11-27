using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Panken.ViewModels
{
    public class TransferVM
    {
        [Required]
        public int FromAccountNumber { get; set; }
        [Required]
        public int ToAccountNumber { get; set; }
        [Required]
        public decimal Amount { get; set; }
    }   
}
