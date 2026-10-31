using System.ComponentModel.DataAnnotations;
namespace BlogApi.Models
{
    public class Post
    {
        public int Id { get; set; }

        [Required(ErrorMessage= "Title is required.")]
        [StringLength(150, MinimumLength = 3, 
            ErrorMessage = "Title must be between 3 and 150 characters.")]

        public string Title { get; set; } = string.Empty;

        [Required(ErrorMessage = "Content is required.")]
        [MinLength(10,
            ErrorMessage = "Content must contain at least 10 charcaters.")]

        public string Content { get; set; } = string.Empty;

        public DateTime CreatedDate { get; set; } = DateTime.Now;
    }
}
