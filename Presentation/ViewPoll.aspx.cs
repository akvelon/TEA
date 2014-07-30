using System.Web.Management;

namespace Presentation
{
    using DAL;
    using DAL.Models;
    using System;
    using System.Web.UI.WebControls;

    /// <summary>
    /// Represents page for viewing polls.
    /// </summary>
    public partial class ViewPoll : System.Web.UI.Page
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
                PollView.DataSource = poll.Stories;
                TotalVoted.Text = poll.Results.Count.ToString();
            }
            else
            {
                PollView.DataSource = null;
                BottomPanel.Visible = false;
            }

            PollView.DataBind();
        }
    }
}