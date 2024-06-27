using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection.Emit;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MyMedicos
{
    public partial class editItemPage : System.Web.UI.Page
    {
        string cs = "Data Source=LAPTOP-UIDHBTUM;Initial Catalog=electronics_item;Integrated Security=True;Encrypt=False";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["item_edit"] != null)
                {
                    string item_edit = Session["item_edit"].ToString();

                    try
                    {
                        SqlConnection con = new SqlConnection(cs);
                        string query = "select * from items where item_name = @item_edit";
                        using (con)
                        {
                            using(SqlCommand cmd = new SqlCommand(query, con))
                            {
                                cmd.Parameters.AddWithValue("@item_edit", item_edit);
                                con.Open();
                                SqlDataReader dr = cmd.ExecuteReader();
                                while (dr.Read())
                                {
                                    TextBox_name_update.Text = (string)dr[0];
                                    TextBox_category_update.Text = (string)dr[1];
                                    TextBox_price_update.Text = (string)dr[2];
                                    TextBox_quant_update.Text = (string)dr[3];
                                    TextBox_add_update.Text = (string)dr[4];
                                }
                            }
                        }
                    }
                    catch(Exception ex)
                    {
                        label_success.Text = ex.Message;
                    }
                }
                else
                {
                    Response.Redirect("Item_List.aspx");
                }
            }
        }

        protected void SubmitButton_Click(object sender, EventArgs e)
        {
            string item_name = TextBox_name_update.Text;
            string category = TextBox_category_update.Text;
            string price = TextBox_price_update.Text;
            string quant = TextBox_quant_update.Text;
            string address = TextBox_add_update.Text;

            string connectionString = "Data Source=LAPTOP-UIDHBTUM;Initial Catalog=electronics_item;Integrated Security=True;Encrypt=False";
            string query = "update items set category = @category, price = @price, quant = @quant, addr = @address where item_name = @item_name";

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

                        TextBox_name_update.Text = ""; 
                        TextBox_category_update.Text = ""; 
                        TextBox_price_update.Text = "";
                        TextBox_quant_update.Text = "";
                        TextBox_add_update.Text = "";
                        label_success.Text = "<p>Item Updated Successfully!!<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"30px\" height=\"\" color=\"Green\" fill=\"currentColor\" class=\"bi bi-check\" viewBox=\"0 0 16 16\">\r\n  <path d=\"M10.97 4.97a.75.75 0 0 1 1.07 1.05l-3.99 4.99a.75.75 0 0 1-1.08.02L4.324 8.384a.75.75 0 1 1 1.06-1.06l2.094 2.093 3.473-4.425z\"/>\r\n</svg></p>";
                    }
                }
            }
            catch (Exception ex)
            {
                label_success.Text = "An error occurred: " + ex.Message;
            }
        }
    }
}