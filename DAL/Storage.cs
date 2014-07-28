namespace DAL
{
    using Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Provides access to database.
    /// </summary>
    public static class Storage
    {
        #region Stories
        /// <summary>
        /// Gets the stories.
        /// </summary>
        /// <returns>Story array</returns>
        public static Story[] GetStories(Func<Story, bool> pred)
        {
            using (var db = new TeaContext())
            {
                return db.Stories.Where(pred).ToArray();
            }
        }
        #endregion

        #region Polls
        /// <summary>
        /// Gets the polls.
        /// </summary>
        /// <returns>Poll array</returns>
        public static Poll[] GetPolls(Func<Poll, bool> pred)
        {
            using (var db = new TeaContext())
            {
                return db.Polls.Where(pred).ToArray();
            }
        }

        /// <summary>
        /// Gets the poll matching the predicate.
        /// </summary>
        /// <param name="pred">The pred.</param>
        /// <returns>New poll or null if not found</returns>
        public static Poll GetPoll(Func<Poll, bool> pred)
        {
            using (var db = new TeaContext())
            {
                var poll = db.Polls.FirstOrDefault(pred);

                if (poll != null)
                {
                    db.Entry(poll).Collection("Stories").Load();
                    db.Entry(poll).Collection("Results").Load();
                }

                return poll;
            }
        }

        /// <summary>
        /// Adds the poll.
        /// </summary>
        /// <param name="stories">The stories.</param>
        /// <returns>New poll Id</returns>
        public static int AddPoll(string[] stories)
        {
            if (stories == null)
                return 0;

            using (var db = new TeaContext())
            {
                var poll = db.Polls.Create<Poll>();
                poll.Stories = new List<Story>();
                poll.Results = new List<Result>();

                foreach (string story in stories)
                {
                    poll.Stories.Add(new Story() { Description = story });
                }

                db.Polls.Add(poll);
                db.SaveChanges();
                
                return poll.PollId;
            }
        }
        #endregion

        #region Results
        /// <summary>
        /// Gets the results.
        /// </summary>
        /// <returns>Result array</returns>
        public static Result[] GetResults(Func<Result, bool> pred)
        {
            using (var db = new TeaContext())
            {
                return db.Results.Where(pred).ToArray();
            }
        }
        #endregion
    }
}