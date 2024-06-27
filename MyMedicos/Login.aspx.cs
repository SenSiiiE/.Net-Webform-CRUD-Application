using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MyMedicos
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                TextBox1.Focus(); // blink cursor in TextBox1  
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            string username = TextBox1.Text;
            string password = TextBox2.Text;
            string connectionString = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString.ToString();
            Session["cs"] = connectionString;
            string query = "SELECT COUNT(*) FROM loginAdmin WHERE username = @username AND pass = @pass";

            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        con.Open();
                        cmd.Parameters.AddWithValue("@username", username);
                        cmd.Parameters.AddWithValue("@pass", password);
                        int count = (int)cmd.ExecuteScalar();

                        if (count > 0)
                        {
                            Response.Redirect("HomePage.aspx");
                        }
                        else
                        {
                            Label2.Text = "Username or Password is invalid...";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Label2.Text = "An error occurred: " + ex.Message;
            }
        }
    }
}