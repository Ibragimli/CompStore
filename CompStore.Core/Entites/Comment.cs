using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CompStore.Core.Entites
{
    public class Comment:BaseEntity
    {
        public int ProductId { get; set; }
        public string AppUserId { get; set; }
        public string Title { get; set; }
        public string Fullname { get; set; }
        public bool CommentStatus { get; set; }
        public string Email { get; set; }
        public string Text { get; set; }
        [Range(1, 5)]
        public int Rate { get; set; }
        public DateTime Time { get; set; }
        public Product Product { get; set; }
        public AppUser AppUser { get; set; }
    }
}
