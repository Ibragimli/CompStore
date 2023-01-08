using System;
using System.Collections.Generic;
using System.Text;

namespace CompStore.Service.Dtos.User
{
    public class WishDto
    {
        public List<WishItemDto> WishItems { get; set; }

    }
    public class WishItemDto
    {
        public int ProductId { get; set; }
        public decimal Price { get; set; }
        public decimal SalePrice { get; set; }
        public decimal DiscountPercent { get; set; }
        public string Name { get; set; }
        public bool StockStatus { get; set; }
    }
    
}
