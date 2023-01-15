using CompStore.Core.Entites;
using CompStore.Service.Helper;
using System;
using System.Collections.Generic;
using System.Text;

namespace CompStore.Service.Dtos.Area.Products
{
    public class ProductCommentsIndexDto
    {
        public PagenetedList<Comment> PagenatedComments { get; set; }
        public string Search { get; set; }
    }
}