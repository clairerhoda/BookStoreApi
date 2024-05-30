using System;
using System.ComponentModel.DataAnnotations;

namespace BookStore.Models
{
	public class Book
	{
		
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required")] // input validation
        public string Title { get; set; }

        public string Author { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "Price must be greater " +
            "than or equal to 0")]// input validation
        [Required]
        public decimal Price { get; set; }

        public bool IsDeleted { get; set; } = false;

        public Book()
        {
            IsDeleted = false; // alt to public bool IsDeleted { get; set; } = false;
        }
        
	}
}

