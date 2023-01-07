using System;
using System.Collections.Generic;
using System.Text;

namespace CompStore.Service.Dtos.User
{

    public class WishProductCreateDto
    {
        public List<WishItemsDto> WishItems { get; set; }

    }
    public class WishItemsDto
    {
        public int ProductId { get; set; }
        public decimal Price { get; set; }
        public decimal DiscountPercent { get; set; }
        public string Name { get; set; }
        public bool StockStatus { get; set; }
    }
}
