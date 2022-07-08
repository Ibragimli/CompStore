﻿using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CompStore.Core.Entites
{
    public class Product : BaseEntity
    {
        public int CategoryId { get; set; }
        public int ProductParametrId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal? Price { get; set; }
        [Range(0, 100)]
        public decimal? DiscountPercent { get; set; }
        public Category Category { get; set; }
        public ProductParametr ProductParametr { get; set; }
        public List<ProductImage> ProductImages { get; set; }
        //public List<Comment> Comments { get; set; }

        [NotMapped]
        public List<IFormFile> ImageFiles { get; set; }
        [NotMapped]
        public IFormFile PosterImageFile { get; set; }
        [NotMapped]
        public List<int> ProductImagesIds { get; set; }

    }
}
