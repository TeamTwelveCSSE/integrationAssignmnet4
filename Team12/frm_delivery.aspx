<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frm_delivery.aspx.cs" Inherits="Team12.frm_delivery" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <script type="text/javascript">
        function Confirm() {
            var confirm_value = document.createElement("INPUT");
            confirm_value.type = "hidden";
            confirm_value.name = "confirm_value";
            if (confirm("Do you want to save data?")) {
                confirm_value.value = "Yes";
            }
            else {
                confirm_value.value = "No";
            }
            document.forms[0].appendChild(confirm_value);
        }
    </script>
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <meta name="description" content="">
    <meta name="author" content="">
    <title>Delivery Page</title>
    <!-- Bootstrap Core CSS -->
    <link href="Resources/css/bootstrap.min.css" rel="stylesheet">
    <!-- SmartMenus jQuery Bootstrap Addon CSS -->
    <link href="Resources/css/jquery.smartmenus.bootstrap.css" rel="stylesheet">
    <link href="Resources/css/owl/owl.carousel.css" rel="stylesheet" type="text/css" />
    <link href="Resources/css/owl/owl.theme.css" rel="stylesheet" type="text/css" />
    <link href="Resources/css/owl/owl.transitions.css" rel="stylesheet" type="text/css" />
    <!-- Custom CSS -->
    <link href="Resources/css/1-col-portfolio.css" rel="stylesheet">
    <link href='https://fonts.googleapis.com/css?family=Ubuntu:300,400,700' rel='stylesheet'
        type='text/css'>
    <link href="http://fonts.googleapis.com/css?family=Open+Sans:300,400italic,700italic,400,700"
        rel="stylesheet" type="text/css" />
    <!-- Required plugin - Animate.css -->
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/animate.css/3.4.0/animate.min.css">
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

    <div class="navbar navbar-inverse navbar-fixed-top" role="navigation">
        <div class="container">
            <div class="navbar-header">
                <button type="button" class="navbar-toggle" data-toggle="collapse" data-target=".navbar-collapse">
                    <span class="sr-only">Toggle navigation</span> <span class="icon-bar"></span><span
                        class="icon-bar"></span><span class="icon-bar"></span>
                </button>
                <a class="navbar-brand" href="#"><i class="fa fa-diamond"></i>TATA DiamonD</a>
            </div>
        </div>
    </div>

    <br />
    <br />
    <br />

    <form id="form1" runat="server">
        <main id="content">
            <div class="container">
                <div class="row">
                    <h3>Delivery Orders</h3>
                    <br />
                    <div class="container">
                        <div class="divRow">

                            <asp:GridView ID="dtg_dataGrid" DataKeyNames="deliveryID" runat="server" AutoGenerateColumns="false" CssClass="Gridview"
                                HeaderStyle-BackColor="#61A6F8" ShowFooter="false" HeaderStyle-Font-Bold="true" HeaderStyle-ForeColor="White" Width="100%">

                                <Columns>

                                    <asp:BoundField DataField="orderID" HeaderText="Order ID" ItemStyle-Width="150" />
                                    <asp:BoundField DataField="supplier" HeaderText="Supplier" ItemStyle-Width="150" />

                                    <asp:TemplateField HeaderText="Delivery Status ">
                                        <ItemTemplate>
                                            <asp:ImageButton ID="imb_delivery" CommandName="Delivery" runat="server" ImageUrl="~/Resources/images/DeliveryImg.png"
                                                ToolTip="Hit Delivery" Height="40px" Width="60px" OnClick="imb_delivery_Click" OnClientClick="Confirm()" />
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Check Quality ">
                                        <ItemTemplate>
                                            <asp:ImageButton ID="imb_okay" CommandName="goodQuality" runat="server" ImageUrl="~/Resources/images/correct.png"
                                                ToolTip="Good in quality" Height="30px" Width="30px" OnClick="imb_okay_Click" OnClientClick="Confirm()" />
                                            <asp:ImageButton ID="imb_notOkay" CommandName="badQuality" runat="server" ImageUrl="~/Resources/images/wrong.png"
                                                ToolTip="Bad in quality" Height="30px" Width="30px" OnClick="imb_notOkay_Click" OnClientClick="Confirm()" />
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Quality Status ">
                                        <ItemTemplate>
                                            <asp:ImageButton ID="imb_goodQuality" CommandName="GoodQuality" runat="server" ImageUrl="~/Resources/images/Best-Quality.png"
                                                ToolTip="Good Quality" Height="60px" Width="60px" />
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <asp:ImageButton ID="imb_badQuality" CommandName="BadQuality" runat="server" ImageUrl="~/Resources/images/Low-Quality.jpg"
                                                ToolTip="Bad Quality" Height="60px" Width="60px" />
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <asp:ImageButton ID="imb_enquery" CommandName="Enquery" runat="server" ImageUrl="~/Resources/images/EnquiryButton.png"
                                                ToolTip="Make Enquery" Height="40px" Width="80px" data-toggle="modal" data-target="#myModal" OnClick="imb_enquery_Click" />
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <asp:ImageButton ID="imb_save" CommandName="Save" runat="server" ImageUrl="~/Resources/images/save.ico"
                                                ToolTip="Save" Height="40px" Width="40px" OnClick="imb_save_Click" />
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                </Columns>

                            </asp:GridView>
                        </div>
                    </div>
                </div>
            </div>
        </main>

    </form>

</body>
</html>
