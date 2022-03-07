using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MyFundi.Web.ViewModels
{
    public class FundiProfileFundiRatingViewModel
    {
        public int FundiProfileFundiRatingId { get; set; }
        public int FundiProfileiId { get; set; }
        public int FundiRatingId { get; set; }
        public DateTime DateCreated { get; set; } = DateTime.Now;
        public DateTime DateUpdated { get; set; } = DateTime.Now;
    }
}
