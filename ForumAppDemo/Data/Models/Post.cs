using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using static ForumAppDemo.Constants.DataConstants.Post;

namespace ForumAppDemo.Data.Models
{
    [Comment("Published posts")]
    public class Post
    {
        [Key]
        [Comment("Posts Identifier")]
        public int Id { get; set; }

        [Required]
        [Comment("Post Title")]
        [MaxLength(TitleMaxLength)]
        public string Title { get; set; }

        [Comment("Comment")]
        [Required]
        [MaxLength(ContentMaxLength)]
        public string Content { get; set; }

        [Comment("Mark record as delete")]
        [Required]
        public bool IsDelete { get; set; } = false;
    }
}
