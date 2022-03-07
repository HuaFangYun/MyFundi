using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MyFundi.Domain
{
    public class FundiProfileFundiRating
    {
        [Key]
        public int FundiProfileFundiRatingId { get; set; }
        [ForeignKey("FundiProfile")]
        public int FundiProfileiId { get; set; }
        public FundiProfile FundiProfile { get; set; }
        [ForeignKey("FundiRating")]
        public int FundiRatingId { get; set; }
        public FundiRating FundiRating { get; set; }
        public DateTime DateCreated { get; set; } = DateTime.Now;
        public DateTime DateUpdated { get; set; } = DateTime.Now;
    }
}
