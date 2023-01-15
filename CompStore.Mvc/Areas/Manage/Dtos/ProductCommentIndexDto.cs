using CompStore.Core.Entites;
using CompStore.Service.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CompStore.Mvc.Areas.Manage.Dtos
{
    public class ProductCommentIndexDto
    {
        public PagenetedList<Comment> PagenatedComments { get; set; }
        public string Search { get; set; }
    }
}
