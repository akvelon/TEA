using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Models
{
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// Represents a user story in the poll.
    /// </summary>
    public class Story
    {
        /// <summary>
        /// Gets or sets the story identifier.
        /// </summary>
        /// <value>
        /// The story identifier.
        /// </value>
        [Key]
        public int StoryId { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>
        /// User story description.
        /// </value>
        [Required]
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the poll.
        /// </summary>
        /// <value>
        /// The poll.
        /// </value>
        [Required]
        public virtual Poll Poll { get; set; }
    }
}