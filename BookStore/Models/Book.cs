using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BookStore.Models {
    public class Book {

        [Required (ErrorMessage = "The field Index is required.")]
        public int Index { get; set; }

        [Required(ErrorMessage = "The field ID is required.")]
        [RegularExpression(@"^\d{10}$", ErrorMessage = "The field ID must be a 10-digit number.")]
        public string ID { get; set; }

        [Required(ErrorMessage = "The field Name is required.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "The field Author is required.")]
        public string Author { get; set; }

        [Required(ErrorMessage = "The field Year is required.")]
        [RegularExpression(@"^\d{4}$", ErrorMessage = "The field Year must be a 4-digit number.")]
        public int Year { get; set; }

        [Required(ErrorMessage = "The field Price is required.")]
        [DataType(DataType.Currency)]
        [Range(0, int.MaxValue)]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "The field Stock is required.")]
        [Range(1, int.MaxValue, ErrorMessage = "The field Stock cannot be 0.")]
        public int Stock { get; set; }
    }
}