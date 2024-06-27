using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MyMedicos
{
    public partial class addItem : System.Web.UI.Page
    {
        int count = 1;
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }
        protected void SubmitButton_Click(object sender, EventArgs e)
        {
                string item_name = TextBox_name.Text;
                string category = TextBox_category.Text;
                string price = TextBox_price.Text;
                string quant = TextBox_quant.Text;
                string address = TextBox_add.Text;

                string connectionString = "Data Source=LAPTOP-UIDHBTUM;Initial Catalog=electronics_item;Integrated Security=True;Encrypt=False";
                string query = "insert into items values(@item_name, @category, @price, @quant, @address)";
                //string query = "SELECT COUNT(*) FROM loginAdmin WHERE username = @username AND pass = @pass";

                try
                {
                    using (SqlConnection con = new SqlConnection(connectionString))
                    {
                        using (SqlCommand cmd = new SqlCommand(query, con))
                        {
                            con.Open();
                            cmd.Parameters.AddWithValue("@item_name", item_name);
                            cmd.Parameters.AddWithValue("@category", category);
                            cmd.Parameters.AddWithValue("@price", price);
                            cmd.Parameters.AddWithValue("@quant", quant);
                            cmd.Parameters.AddWithValue("@address", address);

                            cmd.ExecuteNonQuery();
                            con.Close();
                        //TextBox_name.Text = "Inserted..";

                        TextBox_name.Text = ""; // Clear TextBox_name
                        TextBox_category.Text = ""; // Clear TextBox_category
                        TextBox_price.Text = "";
                        TextBox_quant.Text = "";
                        TextBox_add.Text = "";
                        label_success.Text = "<p>Item Added Successfully!!<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"30px\" height=\"\" color=\"Green\" fill=\"currentColor\" class=\"bi bi-check\" viewBox=\"0 0 16 16\">\r\n  <path d=\"M10.97 4.97a.75.75 0 0 1 1.07 1.05l-3.99 4.99a.75.75 0 0 1-1.08.02L4.324 8.384a.75.75 0 1 1 1.06-1.06l2.094 2.093 3.473-4.425z\"/>\r\n</svg></p>";
                    }
                    }
                }
                catch (Exception ex)
                {
                    Label2.Text = "An error occurred: " + ex.Message;
                }
                
        }
        protected void AddMoreButton_Click(object sender, EventArgs e)
        {
                if (textbox1.Visible == false)
                {
                    textbox1.Visible = true;
                }
                else if (textbox2.Visible == false)
                {
                    textbox2.Visible = true;
                }
                else if (textbox3.Visible == false)
                {
                    textbox3.Visible = true;
                }
                else if (textbox4.Visible == false)
                {
                    textbox4.Visible = true;
                }
            
        }
    }
}