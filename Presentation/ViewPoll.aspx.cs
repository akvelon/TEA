namespace Presentation
{
    using DAL;
    using DAL.Models;
    using System;

    public partial class ViewPoll : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string value = Request.Params["id"];
            int id;
            Poll poll;

            if (value != null && Int32.TryParse(value, out id) && (poll = Storage.GetPoll(p => p.PollId == id)) != null)
            {
                PollView.DataSource = poll.Stories;
                PollView.DataBind();
            }
            else
            {
                PollView.DataSource = null;
                PollView.DataBind();
            }
        }
    }
}