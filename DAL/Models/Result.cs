using System.Collections.Generic;

namespace DAL.Models
{
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// Represents result of the poll.
    /// </summary>
    public class Result
    {
        /// <summary>
        /// Gets or sets the result identifier.
        /// </summary>
        /// <value>
        /// The result identifier.
        /// </value>
        [Key]
        public int ResultId { get; set; }

        /// <summary>
        /// Gets or sets the answers.
        /// </summary>
        /// <value>
        /// The answers.
        /// </value>
        [Required]
        public virtual ICollection<Answer> Answers { get; set; }

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