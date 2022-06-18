using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MyFundi.Web.ViewModels 
{ 
    public class FundiRatingAndReviewViewModel
    {
        public int FundiRatingAndReviewId { get; set; }
        public Guid UserId { get; set; }
        public int Rating { get; set; }
        public string Review { get; set; }
        public int FundiProfileId { get; set; }
        public FundiProfileViewModel FundiProfile { get; set; }
        public DateTime DateCreated { get; set; } = DateTime.Now;
        public DateTime DateUpdated { get; set; } = DateTime.Now;
        public string WorkCategoryType { get; set; }
    }
}
