using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Models
{
    /// <summary>
    /// Represents a single given answer.
    /// </summary>
    public class Answer
    {
        /// <summary>
        /// Gets or sets the answer identifier.
        /// </summary>
        /// <value>
        /// The answer identifier.
        /// </value>
        [Key]
        public int AnswerId { get; set; }

        /// <summary>
        /// Gets or sets the result.
        /// </summary>
        /// <value>
        /// The result.
        /// </value>
        public virtual Result Result { get; set; }

        /// <summary>
        /// Gets or sets the left story.
        /// </summary>
        /// <value>
        /// The left story.
        /// </value>
        [Required]
        public virtual Story LeftStory { get; set; }

        /// <summary>
        /// Gets or sets the right story.
        /// </summary>
        /// <value>
        /// The right story.
        /// </value>
        [Required]
        public virtual Story RightStory { get; set; }

        /// <summary>
        /// Gets or sets the relation.
        /// </summary>
        /// <value>
        /// The relation between left and right stories.
        /// </value>
        [Required]
        public StoryRelation Relation { get; set; }
    }
}