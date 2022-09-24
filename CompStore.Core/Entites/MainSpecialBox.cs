using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CompStore.Core.Entites
{
    public class MainSpecialBox : BaseEntity
    {
        public string Title { get; set; }
        public bool IsFirstBox { get; set; }
        public string Image { get; set; }
        [NotMapped]
        public IFormFile ImageFile { get; set; }
    }
}
