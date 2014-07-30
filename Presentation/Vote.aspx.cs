namespace Presentation
{
    using DAL;
    using DAL.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Represents class for voting.
    /// </summary>
    public partial class Vote : System.Web.UI.Page
    {
        /// <summary>
        /// Handles the Load event of the Page control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        protected void Page_Load(object sender, EventArgs e)
        {
            string value = Request.Params["id"];
            int id;
            Poll poll;

            if (!String.IsNullOrEmpty(value)
                && Int32.TryParse(value, out id)
                && (poll = Storage.GetPollById(id)) != null)
            {
                Story[] stories = poll.Stories.ToArray();
                var answers = new List<Answer>();

                for (int i = 0; i < stories.Length; ++i)
                {
                    for (int j = i + 1; j < stories.Length; ++j)
                    {
                        answers.Add(new Answer() { LeftStory = stories[i], RightStory = stories[j], AnswerId = answers.Count + 1 });
                    }
                }

                VoteView.DataSource = answers;
            }
            else
            {
                VoteView.DataSource = null;
                ButtonVote.Visible = false;
            }

            VoteView.DataBind();
        }

        /// <summary>
        /// Handles the Click event of the ButtonVote control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        protected void ButtonVote_Click(object sender, EventArgs e)
        {
            string value = Request.Params["id"];
            int id;
            Poll poll;

            if (!String.IsNullOrEmpty(value)
                && Int32.TryParse(value, out id)
                && (poll = Storage.GetPollById(id)) != null)
            {
                Story[] stories = poll.Stories.ToArray();
                var answers = new List<Answer>();

                int count = 1;
                for (int i = 0; i < stories.Length; ++i)
                {
                    for (int j = i + 1; j < stories.Length; ++j, ++count)
                    {
                        string text = Request.Form[count.ToString()];

                        if (String.IsNullOrEmpty(text))
                            continue;

                        StoryRelation relation;
                        switch (text)
                        {
                            case "trivial":
                                relation = StoryRelation.Trivial;
                                break;

                            case "easy":
                                relation = StoryRelation.Easy;
                                break;

                            case "equal":
                                relation = StoryRelation.Equal;
                                break;

                            case "difficult":
                                relation = StoryRelation.Difficult;
                                break;

                            case "impossible":
                                relation = StoryRelation.Impossible;
                                break;

                            default:
                                relation = StoryRelation.NotSet;
                                break;
                        }

                        answers.Add(new Answer() { LeftStory = stories[i], RightStory = stories[j], Relation = relation });
                    }
                }

                Storage.AddResult(id, answers);
            }
        }
    }
}