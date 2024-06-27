<%@ Page Title="" Language="C#" MasterPageFile="~/Navbar.Master" AutoEventWireup="true" CodeBehind="Item_List.aspx.cs" Inherits="MyMedicos.Item_List" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js"></script>
    <script src="https://cdn.datatables.net/2.0.3/js/dataTables.min.js"></script>
    <link href="https://cdn.datatables.net/2.0.3/css/dataTables.dataTables.min.css" rel="stylesheet" />


</asp:Content>
<asp:Content CssClass="Custom-body" ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container-fluid item-heading">
        <div class="row">
            <div class="col-md-1">

                <button class="hamburgur" type="button" data-bs-toggle="offcanvas" data-bs-target="#offcanvasExample" aria-controls="offcanvasExample"><span class="glyphicon ">&#9776;</span></button>

                <div class="drawer">
                    <div class="offcanvas offcanvas-start" tabindex="-1" id="offcanvasExample" aria-labelledby="offcanvasExampleLabel">
                        <div class="offcanvas-header">
                            <h5 class="offcanvas-title" id="offcanvasExampleLabel">Shop Items</h5>
                            <button type="button" class="btn-close text-reset" data-bs-dismiss="offcanvas" aria-label="Close"></button>
                        </div>
                        <div class="offcanvas-body ">
                            <div>
                                <h1>List of Items</h1>
                            </div>
                            <div class="dropdown mt-3 text-center" runat="server" id="offcanvasBody"></div>
                        </div>
                    </div>
                </div>
            </div>
            <div class="col-md-10">
                <h3>
                    <u>Items Available
                    </u>
                </h3>
            </div>
            <div class="col-md-1">
                   <asp:Button CssClass="btn btn-outline-primary download-btn" ID="DownloadButton" runat="server" OnClick="DownloadButton_Click" Text="Download Data" />

            </div>

        </div>
    </div>

        <asp:Table CssClass="table container-fluid table-bordered table-hover Custom-table " ID="dataTable" runat="server">
        </asp:Table>

<center>
    <br />
    <asp:Label CssClass="no-data-label" ID="label_response" runat="server"></asp:Label>
    
</center>



<script type="text/javascript">
    $(document).ready(function () {
        $('#<%= dataTable.ClientID %>').DataTable();
    });

    $(document).ready(function () {
        $('#<%= dataTable.ClientID %>').DataTable();
        $('.searchTextBox').on('input', function () {
            var columnIndex = $(this).closest('td').index();
            var searchValue = $(this).val().toLowerCase();
            console.log("Search value entered for column " + columnIndex + ": " + searchValue);
            var table = $('#<%= dataTable.ClientID %>').DataTable();
        table.column(columnIndex).search(searchValue).draw();
    });
    });

    $(document).ready(function () {
        //$('.item-button').on("click", function () {
        //    console.log("Hamburger Click....");
        //})
        // Function to open subcategory
        function openSubcategory(itemName, category, button) {
            // Create HTML for subcategory information
            var subcategoryHtml = `<div class="subcategory-info">Item: ${itemName}, Category: ${category}</div>`;

            // Append subcategory information below the button that was clicked
            $(button).after(subcategoryHtml);
        }

        $(document).ready(function () {
            // Event handler for item buttons
            $('.item-button').click(function () {
                var itemName = $(this).data('item');
                var category = $(this).data('category');
                // Pass the reference of the clicked button to the openSubcategory function
                openSubcategory(itemName, category, this);
            });
        });


    })

</script>
   <script type="text/javascript">
       window.onload = function () {
           // Get the "Select All" checkbox and all row checkboxes
           var selectAllCheckbox = document.getElementById('<%= DownloadButton.ClientID %>');
           var rowCheckboxes = document.querySelectorAll('.rowCheckbox');

           // Add click event listener to "Select All" checkbox
           selectAllCheckbox.addEventListener('click', function () {
               for (var i = 0; i < rowCheckboxes.length; i++) {
                   rowCheckboxes[i].checked = selectAllCheckbox.checked;
               }
           });

           // Add click event listener to each row checkbox
           for (var i = 0; i < rowCheckboxes.length; i++) {
               rowCheckboxes[i].addEventListener('click', function () {
                   // Check if any row checkbox is unchecked
                   var anyUnchecked = false;
                   for (var j = 0; j < rowCheckboxes.length; j++) {
                       if (!rowCheckboxes[j].checked) {
                           anyUnchecked = true;
                           break;
                       }
                   }
                   // Update "Select All" checkbox state
                   selectAllCheckbox.checked = !anyUnchecked;
               });
           }
       };
   </script>




</asp:Content>


