using System.ComponentModel.DataAnnotations;
using static ForumAppDemo.Constants.DataConstants.Post;

namespace ForumAppDemo.Models
{
    public class AddPostViewModel
    {
        [Display(Name = "Title")]
        [Required(ErrorMessage = "Field {0} is required")]
        [StringLength(TitleMaxLength, MinimumLength = TitleMinimumLength, ErrorMessage = "Field {0} must be between {2} and {1} symbols")]
        public string Title { get; set; }

        [Display(Name = "Content")]
        [Required(ErrorMessage = "Field {0} is required")]
        [StringLength(ContentMaxLength, MinimumLength = ContentMinimumLength, ErrorMessage = "Field {0} must be between {2} and {1} symbols")]
        public string Content { get; set; }

    }
}
