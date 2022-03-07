using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MyFundi.Web.ViewModels 
{ 
    public class FundiRatingViewModel
    {
        public int FundiRatingId { get; set; }
        public string FundiRatingDescription { get; set; }
        public string FundiRatingSummary{ get; set; }
        public int Rating { get; set; }
        public DateTime DateCreated { get; set; } = DateTime.Now;
        public DateTime DateUpdated { get; set; } = DateTime.Now;
    }
}
