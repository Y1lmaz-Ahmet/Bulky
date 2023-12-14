using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulkyBook.Models
{
    public class Product
    {
        [Key] // Data annotation telling entity framework that ID is an primary key
        public int Id { get; set; } // primary key

        [Required]
        public string Title { get; set; } // title of the book
        public string Description { get; set; } // description about the book

        [Required]
        public string ISBN { get; set; } // 13-digit number that uniquely identifies books

        [Required]
        public string Author { get; set; } // author of the book

        [Required]
        [Display(Name = "List Price")] // the price of a list of books
        [Range(1,1000)]
        public double ListPrice { get; set; }

        [Required]
        [Display(Name = "Price for 1-50")] // price for 1 - 50 books combined
        [Range(1, 1000)]
        public string Price { get; set; }

        [Required]
        [Display(Name = "Price for 50+")] // price for books more than 50
        [Range(1,1000)]
        public double Price50 { get; set; }

        [Required]
        [Display(Name = "Price for 100+")] // price for books more than 100
        [Range(1, 1000)]
        public double Price100 { get; set; }
    }
}
