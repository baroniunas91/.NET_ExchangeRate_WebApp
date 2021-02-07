using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExchangeRate.WebApp.Models
{
    public class RegisterDate
    {
        [Required(ErrorMessage = "Oops... Invalid date!")]
        [DataType(DataType.DateTime, ErrorMessage = "Invalid date!")]
        public DateTime Date { get; set; } = new DateTime(2010, 01, 01);
    }
}
