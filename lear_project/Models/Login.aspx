using System;

namespace lear_project.Models
{
    public class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            // Ellenőrizd a jelszót
            if (txtPassword.Text == "jelszo") // Itt "jelszo" helyett a valódi jelszót kell ellenőrizned
            {
                // Ha a jelszó helyes, átirányítsd a felhasználót az oldalra
                Response.Redirect("FoodEditor.cshtml");
            }
            else
            {
                // Ha a jelszó helytelen, írj ki egy hibaüzenetet
                lblMessage.Text = "Hibás jelszó!";
            }
        }
    }
}
