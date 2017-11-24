<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddItems.aspx.cs" Inherits="Team12.AddItems" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
     <title>Select Items</title>
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <meta name="description" content="">
    <meta name="author" content="">
    <!-- Bootstrap Core CSS -->
    <link href="Resources/css/bootstrap.min.css" rel="stylesheet"/>
    <!-- SmartMenus jQuery Bootstrap Addon CSS -->
    <link href="Resources/css/jquery.smartmenus.bootstrap.css" rel="stylesheet"/>
    <link href="Resources/css/owl/owl.carousel.css" rel="stylesheet" type="text/css" />
    <link href="Resources/css/owl/owl.theme.css" rel="stylesheet" type="text/css" />
    <link href="Resources/css/owl/owl.transitions.css" rel="stylesheet" type="text/css" />
    <!-- Custom CSS -->
    <link href="Resources/css/1-col-portfolio.css" rel="stylesheet"/>
    <link href='https://fonts.googleapis.com/css?family=Ubuntu:300,400,700' rel='stylesheet'
        type='text/css'/>
    <link href="http://fonts.googleapis.com/css?family=Open+Sans:300,400italic,700italic,400,700"
        rel="stylesheet" type="text/css" />
    <!-- Required plugin - Animate.css -->
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/animate.css/3.4.0/animate.min.css"/>
    <link href="Resources/fonts/font-awesome.min.css" rel="stylesheet" type="text/css" />
    <link href="Resources/fonts/font-awesome.css" rel="stylesheet" type="text/css" />
    <!-- HTML5 Shim and Respond.js IE8 support of HTML5 elements and media queries -->
    <!-- WARNING: Respond.js doesn't work if you view the page via file:// -->
    <!--[if lt IE 9]>
        <script src="https://oss.maxcdn.com/libs/html5shiv/3.7.0/html5shiv.js"></script>
        <script src="https://oss.maxcdn.com/libs/respond.js/1.4.2/respond.min.js"></script>
    <![endif]-->
</head>


<body>
    
          <%-- ///////////////////////////////////////////////////////////////////////////////////////////////////--%>


        <form id="main"  method="post" runat="server">
            <main id="content">
                <div class="container">
                    <div class="row">
                        

                        <div class="tab-content">
                            <div id="Expenses" class="tab-pane fade in active">
                                <h1 style="text-align:center; font-family:Calibri">Add Items</h1>
                               
                             
        <div class="container">
            <div class="col-md-2"> </div>
            <div class="row">
                <div class="col-md-6">
                    <div id="main-contact-form" class="contact-form">
 
<%--///////////////////////////////////////////////////////Content Starts///////////////////////////////////////////////////////////////////////////////////////////////////////--%>
                        <div class="form-group">
                            <div class="col-md-4">Requisition ID</div>
                           <div class="col-md-6">
                               <asp:TextBox ID="tb_reqid" runat="server" CssClass="form-control"/>
                           </div>
                        </div>
                        <br /><br /> 

                        <div class="form-group">
                           <div class="col-md-3" style="text-align:center;">Search By</div>
                           <div class="col-md-4" style="text-align:center;">
                                <asp:DropDownList ID="list_search" runat="server" class="form-control" AutoPostBack="false" Visible="True">
                                    <asp:ListItem >Item ID</asp:ListItem>
                                    <asp:ListItem Selected="True">Item Name</asp:ListItem>
                                    
                                </asp:DropDownList>
                               <br />
                           </div>
                           <div class="col-md-2">
                               <asp:TextBox ID="tb_SearchId" runat="server" CssClass="form-control" ></asp:TextBox>
                           </div>
                            <br />
                            <div class="col-md-2" style="text-align:center">
                              <asp:Button ID="btn_search" CssClass="btn btn-default" Text="Search" runat="server" OnClick="btn_search_Click" />
                            </div>
                        </div>
                            <br /><br /> 

                        <asp:GridView ID="GridView1" runat="server" onselectedindexchanged="GridView1_SelectedIndexChanged"  CellPadding="8" CellSpacing="2" ForeColor="#333333" Width="900px"  GridLines="None" SelectedRowStyle-Height="10px" HorizontalAlign="Center" AutoGenerateSelectButton="True">
                                        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                        <EditRowStyle BackColor="#999999" Height="40px" />
                                        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" HorizontalAlign="Center" />
                                        <HeaderStyle BackColor="#5cb85c" Font-Bold="True" ForeColor="White" HorizontalAlign="Center" Height="40px"  />
                                        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                                        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" Height="40px" HorizontalAlign="Center"  />
                                        <SelectedRowStyle BackColor="#f4f142" Font-Bold="True" ForeColor="#333333" Height="40px" />
                                        <SortedAscendingCellStyle BackColor="#E9E7E2" />
                                        <SortedAscendingHeaderStyle BackColor="#506C8C" />
                                        <SortedDescendingCellStyle BackColor="#FFFDF8" />
                                        <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
                                        <Columns>
                                            <asp:BoundField  />
                                            <asp:TemplateField ShowHeader="False" >
                                                <ItemTemplate>
                                                    <asp:Button ID="btn_CancelSelection" runat="server" CausesValidation="false" Text="Cancel Selection" OnClick="btn_CancelSelection_Click"  />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField ShowHeader="False" HeaderText="Quantity">
                                                <ItemTemplate>
                                                    <asp:TextBox ID="tb_quantity" runat="server" CausesValidation="false"  Width="90px" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                         </Columns>
                         </asp:GridView>

<%--////////////////////////////////////////////////////////////Content Ends/////////////////////////////////////////////////////////////////////////////////////////////////////////--%>      
              <br /><br />
                           <div class="col-md-3" style="text-align:center;">Add Items with Quantity </div>
                           <div class="col-md-4" style="text-align:center;">
                               <asp:TextBox ID="tb_items_withqty" CssClass="form-control" runat="server"></asp:TextBox>
                               <br />
                           </div>
                        <br /><br />
                           <div class="col-md-3" style="text-align:center;"></div>
                           <div class="col-md-4" style="text-align:center;">
                               <asp:Button ID="btn_Assign" Text="Assign" CssClass="btn btn-success" runat="server" OnClick="btn_Assign_Click" ></asp:Button>
                               <asp:Button ID="btn_close" Text="Close" CssClass="btn btn-danger" runat="server" OnClick="btn_close_Click" ></asp:Button>
                           </div>
                           
                        <asp:TextBox ID="hiiden_description" runat="server" Visible="false"></asp:TextBox>
                        <asp:TextBox ID="hidden_uom" runat="server" Visible="false"></asp:TextBox>
                        <asp:TextBox ID="hidden_itemprice" runat="server" Visible="false"></asp:TextBox>
                        <asp:TextBox ID="hidden_supplier" runat="server" Visible="false"></asp:TextBox>
                         <asp:TextBox ID="hidden_sup_email" runat="server" Visible="false"></asp:TextBox>
                    </div>
                </div>
                <br /> <br />
                <div class="col-md-4">
                   <h4>Total Item Price : </h4> 
                </div>
                <div class="col-md-4">
                    <asp:TextBox ID="tb_itemPrice" runat="server" CssClass="form-control"> </asp:TextBox>
                </div>
                <br /> <br /> 
                <div style="margin-left: auto; margin-right: auto; text-align: center;">
                    <asp:Label Text="Cost for the items exceeds the policy amount.! Supervisor approval is needed.!!!" runat="server" ID="lbl_warning" CssClass="label label-warning" Visible="false" Font-Size="Large"></asp:Label>
                    <asp:Label Text="Cost for the items is lower than the policy amount.! No need of Supervisor Approval.!!!" ID="lbl_done" runat="server" Visible="false" CssClass="label label-success" Font-Size="Large"></asp:Label>
                </div>
            </div>
        </div>
          <br /> <br />
                        </div>
                    </div>
                </div>
              </div>
            </main>
   
        </form>


        <%--///////////////////////////////////////////////////////////////////////////////////////////////////--%>
   
  
    <!-- jQuery -->
    <script src="Resources/scripts/jquery.js"></script>
    <!-- Bootstrap Core JavaScript -->
    <script src="Resources/scripts/bootstrap.min.js"></script>
    <script src="Resources/scripts/wow.min.js" type="text/javascript"></script>
    <script src="Resources/scripts/tutorial.js"></script>
    <script src="Resources/css/owl/owl.carousel.js" type="text/javascript"></script>
    <!-- SmartMenus jQuery plugin -->
    <script type="text/javascript" src="Resources/scripts/jquery.smartmenus.js"></script>
    <!-- SmartMenus jQuery Bootstrap Addon -->
    <script type="text/javascript" src="Resources/scripts/jquery.smartmenus.bootstrap.js"></script>
</body>

</html>
