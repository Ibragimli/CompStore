using System;
using System.Collections.Generic;
using System.Text;

namespace CompStore.Core.Entites
{
    public class WishItem : BaseEntity
    {
        public string AppUserId { get; set; }
        public int ProductId { get; set; }
        public AppUser AppUser { get; set; }
        public Product Product { get; set; }
    }
}
