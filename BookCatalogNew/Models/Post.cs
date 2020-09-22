using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;


namespace BookCatalogNew.Models
{
    public class Post
    {
        public long Id { get; set; }

        private string _key;

        public string Key
        {
            get
            {
                if(_key == null)
                {
                    _key = Regex.Replace(Title.ToLower(), "[^a-z0-9]", "-");
                }
                return _key;
            }

            set { _key = value; }
        }


        [Display(Name = "Select Book")]
        [Required]
        public string BookName { get; set; }

        [Display(Name ="Review Title")]
        [Required]
        [DataType(DataType.Text)]
        [StringLength(100, MinimumLength = 5, ErrorMessage ="Title must be between 5 and 100 characters long.")]
        public string Title { get; set; }

        public string Author { get; set; }

        [Display(Name = "Add Review")]
        [Required]
        [DataType(DataType.MultilineText)]
        [MinLength(10, ErrorMessage ="Review must be at least 10 characters long")]
        public string Body { get; set; }

        [Required]
        [Range(1, 10, ErrorMessage ="Rate on the scale of 1 to 10")]
        public int Rating { get; set; }

        public DateTime Posted { get; set; }
    }
}
