using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// Represents the poll entity.
    /// </summary>
    public class Poll
    {
        /// <summary>
        /// Gets or sets the poll identifier.
        /// </summary>
        /// <value>
        /// The poll identifier.
        /// </value>
        [Key]
        public int PollId { get; set; }

        /// <summary>
        /// Gets or sets the stories.
        /// </summary>
        /// <value>
        /// The stories.
        /// </value>
        public virtual ICollection<Story> Stories { get; set; }

        /// <summary>
        /// Gets or sets the results.
        /// </summary>
        /// <value>
        /// The results of the poll.
        /// </value>
        public virtual ICollection<Result> Results { get; set; }
    }
}