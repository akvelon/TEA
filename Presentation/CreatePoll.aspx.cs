namespace Presentation
{
    using DAL;
    using System;
    using System.Web.UI;

    /// <summary>
    /// Represents page for creating polls.
    /// </summary>
    public partial class CreatePoll : Page
    {
        /// <summary>
        /// Handles the Load event of the Page control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        /// <summary>
        /// Handles the Click event of the ButtonCreate control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        protected void ButtonCreate_Click(object sender, EventArgs e)
        {
            string[] descriptions = Request.Form.GetValues("dsc");
            int pollId = Storage.AddPoll(descriptions);
            Response.Redirect("ViewPoll.aspx?id=" + pollId);
        }
    }
}