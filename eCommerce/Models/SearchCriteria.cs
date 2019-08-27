using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace eCommerce.Models
{
    public class SearchCriteria
    {
        public string Title { get; set; }
        public string Rating { get; set; }

        [Display(Name = "Minimum Price")]
        [Range(0, double.MaxValue, ErrorMessage = "the min price must be double")]
        public double? MinPrice { get; set; }

        [Display(Name = "Maximum Price")]
        [Range(0, double.MaxValue, ErrorMessage = "the Max price must be double")]
        public double? MaxPrice { get; set; }

        /// <summary>
        /// The video games found using the search criteria
        /// </summary>
        public List<VideoGame> Games { get; set; }


    }
}
