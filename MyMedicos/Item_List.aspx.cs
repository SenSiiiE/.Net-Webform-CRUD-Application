using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;

namespace MyMedicos
{
    public partial class Item_List : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("Page_Load event fired.");

            
                PopulateDataTable();
                LoadNames();    
            
        }

        string cs = "Data Source=LAPTOP-UIDHBTUM;Initial Catalog=electronics_item;Integrated Security=True;Encrypt=False";
        private void PopulateDataTable()
        {
            using (SqlConnection connection = new SqlConnection(cs))
            {
                connection.Open();
                string query = "SELECT item_name, category, price, quant, addr FROM items";
                SqlCommand command = new SqlCommand(query, connection);
                SqlDataReader reader = command.ExecuteReader();

                TableHeaderRow headerRow = new TableHeaderRow();
                headerRow.CssClass = "thead-dark table-dark";
                headerRow.TableSection = TableRowSection.TableHeader;

                // Add header cells to the header row
                TableHeaderCell itemHeader = new TableHeaderCell();
                itemHeader.Text = "Item";
                headerRow.Cells.Add(itemHeader);
                itemHeader.CssClass = "theading";
                itemHeader.Style["text-align"] = "center";

                TableHeaderCell categoryHeader = new TableHeaderCell();
                categoryHeader.Text = "Category";
                headerRow.Cells.Add(categoryHeader);
                categoryHeader.CssClass = "theading";
                categoryHeader.Style["text-align"] = "center";

                TableHeaderCell priceHeader = new TableHeaderCell();
                priceHeader.Text = "Price";
                headerRow.Cells.Add(priceHeader);
                priceHeader.CssClass = "theading";
                priceHeader.Style["text-align"] = "center";

                TableHeaderCell quantHeader = new TableHeaderCell();
                quantHeader.Text = "Quantity";
                headerRow.Cells.Add(quantHeader);
                quantHeader.CssClass = "theading";
                quantHeader.Style["text-align"] = "center";

                TableHeaderCell addrHeader = new TableHeaderCell();
                addrHeader.Text = "Address";
                headerRow.Cells.Add(addrHeader);
                addrHeader.CssClass = "theading";
                addrHeader.Style["text-align"] = "center";

                TableHeaderCell actionHeader = new TableHeaderCell();
                actionHeader.Text = "Action";
                headerRow.Cells.Add(actionHeader);
                actionHeader.CssClass = "theading";
                actionHeader.Style["width"] = "50px";
                actionHeader.Style["text-align"] = "center";

                TableHeaderCell checkBoxHeader = new TableHeaderCell();
                Panel check = new Panel();

                CheckBox checkBox = new CheckBox();
                checkBox.ID = "checkBoxHeaderID";

                Label checkLabel = new Label();
                checkLabel.Text = "Select All";

                check.Controls.Add(checkBox);
                check.Controls.Add(checkLabel);
                checkBoxHeader.Controls.Add(check);

                headerRow.Controls.Add(checkBoxHeader);
                // Add the <thead> to the table
                dataTable.Rows.Add(headerRow);

                while (reader.Read())
                {
                    TableRow row = new TableRow();

                    TableCell itemCell = new TableCell();
                    itemCell.Text = reader["item_name"].ToString();
                    row.Cells.Add(itemCell);
                    itemCell.Style["text-align"] = "center";

                    TableCell categoryCell = new TableCell();
                    categoryCell.Text = reader["category"].ToString();
                    row.Cells.Add(categoryCell);
                    categoryHeader.Style["text-align"] = "center";

                    TableCell priceCell = new TableCell();
                    priceCell.Text = reader["price"].ToString();
                    row.Cells.Add(priceCell);
                    priceCell.Style["text-align"] = "center";

                    TableCell quantCell = new TableCell();
                    quantCell.Text = reader["quant"].ToString();
                    row.Cells.Add(quantCell);
                    quantCell.Style["text-align"] = "center";

                    TableCell addrCell = new TableCell();
                    addrCell.Text = reader["addr"].ToString();
                    row.Cells.Add(addrCell);
                    addrCell.Style["text-align"] = "center";

                    TableCell buttonCell = new TableCell();
                    Panel buttonPanel = new Panel();

                    Button editBtn = new Button();
                    editBtn.Text = "Edit";
                    buttonPanel.Controls.Add(editBtn);
                    editBtn.CommandArgument = reader["item_name"].ToString();
                    editBtn.CommandName = "Edit";
                    editBtn.Click += EditButton_Click;
                    editBtn.CssClass = "btn btn-success"; // Apply Bootstrap button class
                    editBtn.Style["margin-right"] = "10px"; // Apply margin-right using inline style

                    Button deleteBtn = new Button();
                    deleteBtn.Text = "Delete";
                    buttonPanel.Controls.Add(deleteBtn);
                    deleteBtn.CommandArgument = reader["item_name"].ToString();
                    deleteBtn.CommandName = "Delete";
                    deleteBtn.Click += DeleteButton_Click;
                    deleteBtn.CssClass = "btn btn-danger"; // Apply Bootstrap button class


                    buttonCell.Controls.Add(buttonPanel);
                    row.Cells.Add(buttonCell);

                    TableCell checkBoxCell = new TableCell();
                    CheckBox localCheckBox = new CheckBox();
                    localCheckBox.CssClass = "rowCheckbox"; // Add a common class for row checkboxes

                    checkBoxCell.Controls.Add(localCheckBox);
                    checkBoxCell.Style["text-align"] = "center";
                    row.Cells.Add(checkBoxCell);

                    dataTable.Rows.Add(row);

                    

                }
                List<string> columnsToDisplay = new List<string> { "Item", "Category", "Price", "Quantity", "Address", "Action"};
                TableFooterRow footerRow = new TableFooterRow();
                for (int i = 0; i < 5; i++)
                {
                    TableCell footerCell = new TableCell();
                    TextBox textBox = new TextBox();
                    textBox.ID = "searchBox" + i;
                    textBox.CssClass = "searchTextBox";
                    textBox.Attributes["placeholder"] = "Search " + columnsToDisplay[i];
                    textBox.Attributes["onkeyup"] = "searchTable(" + i + ")";
                    footerCell.Controls.Add(textBox);
                    footerRow.Cells.Add(footerCell);
                    //textBox.Style["width"] = "0px";
                }
                footerRow.TableSection = TableRowSection.TableFooter;

                dataTable.Rows.Add(footerRow);


                reader.Close();
            }
        }
        public void LoadNames()
        {
            try
            {
                SqlConnection conn = new SqlConnection(cs);
                conn.Open();
                string query = "SELECT item_name, category FROM items;";

                SqlCommand cmd = new SqlCommand(query, conn);

                SqlDataReader reader = cmd.ExecuteReader();

                offcanvasBody.InnerHtml = "";

                while (reader.Read())
                {
                    string name = reader["item_name"].ToString();
                    string category = reader["category"].ToString();

                    offcanvasBody.InnerHtml += $"<button type='button' style='border:0;' class='item-button' data-item='{name}' data-category='{category}'>{name.ToUpper()}</button><br/><br/>";
                }
                conn.Close();



            }
            catch (Exception ex)
            {

                
            }
        }
        protected void EditButton_Click(object sender, EventArgs e)
        {
            Button editBtn = (Button)sender;
            string item = editBtn.CommandArgument;

            Session["item_edit"] = item;
            Session["cs"] = cs;
            Response.Redirect("editItemPage.aspx");

        }

        protected void DeleteButton_Click(object sender, EventArgs e)
        {

            Button deleteBtn = (Button)sender;
            string item = deleteBtn.CommandArgument;
           
            string dltQuery = "Delete from items where item_name = @item";
            using (SqlConnection con = new SqlConnection(cs))
            {
                using(SqlCommand cmd = new SqlCommand(dltQuery, con))
                {
                    cmd.Parameters.AddWithValue("@item", item.ToString());
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }   
            Response.Redirect(Request.RawUrl);
        }

        protected void DownloadButton_Click(object sender, EventArgs e)
        {
            try
            {
                string query = "SELECT * FROM items";
                using (SqlConnection conn = new SqlConnection(cs))
                {
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        conn.Open();
                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();
                            da.Fill(dt);

                            if (dt.Rows.Count > 0)
                            {
                                Response.Clear();
                                Response.Buffer = true;
                                Response.AddHeader("content-disposition", "attachment;filename=itemdetails.csv");
                                Response.Charset = "";
                                Response.ContentType = "application/text";

                                string columnNames = string.Join(",", dt.Columns.Cast<DataColumn>().Select(column => column.ColumnName));
                                Response.Output.Write(columnNames + "\n");

                                foreach (DataRow row in dt.Rows)
                                {
                                    List<string> rowDataList = new List<string>();
                                    foreach (var field in row.ItemArray)
                                    {
                                        // Enclose all values in double quotes
                                        rowDataList.Add("\"" + field.ToString() + "\"");
                                    }
                                    string rowData = string.Join(",", rowDataList);
                                    Response.Output.Write(rowData + "\n");
                                }

                                Response.Flush();
                                Response.End();
                            }
                            else
                            {
                                label_response.Text = "No data to download!!";
                                label_response.Style["Color"] = "red";
                                label_response.Style["font-family"] = "'Gill Sans', 'Gill Sans MT', Calibri, 'Trebuchet MS', sans-serif";
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                label_response.Text = "Error: " + ex.Message;
            }
        }

        protected void SearchButton_Click(object sender, EventArgs e)
        {

        }
    }
}