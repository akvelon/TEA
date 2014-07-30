namespace DAL.Models
{
    /// <summary>
    /// Relation between two stories.
    /// </summary>
    public enum StoryRelation
    {
        /// <summary>
        /// relation wasn't set
        /// </summary>
        NotSet = 0,

        /// <summary>
        /// the first one if much easier to implement than another one
        /// </summary>
        Trivial = 1,

        /// <summary>
        /// the first one is just easier than another one
        /// </summary>
        Easy = 2,

        /// <summary>
        /// the first one is of the same complexity as another one
        /// </summary>
        Equal = 3,

        /// <summary>
        /// the first one is just more difficult than another one
        /// </summary>
        Difficult = 4,

        /// <summary>
        /// the first one if much more difficult to implement than another one
        /// </summary>
        Impossible = 5
    }
}