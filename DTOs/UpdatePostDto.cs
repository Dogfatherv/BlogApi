using System.ComponentModel.DataAnnotations;
namespace BlogApi.DTOs
{
    public class UpdatePostDto
    {
        [Required(ErrorMessage = "Title is required.")]
        [StringLength(150, MinimumLength = 3)]
        public string Title { get; set; } = string.Empty;

        [Required(ErrorMessage = "Content is required.")]
        [MinLength(10)]
        public string Content { get; set; }= string.Empty;
    }
}
