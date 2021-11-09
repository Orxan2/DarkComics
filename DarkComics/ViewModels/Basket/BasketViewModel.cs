using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DarkComics.ViewModels.Basket
{
    public class BasketViewModel
    {
        public List<BasketItemViewModel> ProductDetails { get; set; }
        public int? TotalCount { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
