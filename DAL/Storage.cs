using System.ComponentModel.DataAnnotations;
using System.Data.Entity.Validation;

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
        public static Story[] GetStories()
        {
            using (var db = new TeaContext())
            {
                return db.Stories.ToArray();
            }
        }
        #endregion

        #region Polls
        /// <summary>
        /// Gets the polls.
        /// </summary>
        /// <returns>Poll array</returns>
        public static Poll[] GetPolls()
        {
            using (var db = new TeaContext())
            {
                return db.Polls.ToArray();
            }
        }

        /// <summary>
        /// Gets the poll matching the predicate.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>
        /// New poll or null if not found
        /// </returns>
        public static Poll GetPollById(int id)
        {
            using (var db = new TeaContext())
            {
                return db.Polls.Include("Results").Include("Stories").FirstOrDefault(p => p.PollId == id);
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
        public static Result[] GetResults()
        {
            using (var db = new TeaContext())
            {
                return db.Results.ToArray();
            }
        }

        public static int AddResult(int pollId, List<Answer> data)
        {
            using (var db = new TeaContext())
            {
                var poll = db.Polls.Find(pollId);
                if (poll == null)
                    return 0;

                var result = new Result() { Answers = data };
                poll.Results.Add(result);

                try
                {
                    db.SaveChanges();
                }
                catch (DbEntityValidationException ex)
                {
                    
                }

                return result.ResultId;
            }
        }
        #endregion
    }
}