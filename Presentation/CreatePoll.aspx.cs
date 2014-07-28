namespace Presentation
{
    using DAL;
    using System;
    using System.Web.UI;

    public partial class CreatePoll : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void ButtonCreate_Click(object sender, EventArgs e)
        {
            string[] descriptions = Request.Form.GetValues("dsc");
            int pollId = Storage.AddPoll(descriptions);
            Response.Redirect("ViewPoll.aspx?id=" + pollId);
        }
    }
}