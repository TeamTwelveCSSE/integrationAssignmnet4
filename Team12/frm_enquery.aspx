<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frm_enquery.aspx.cs" Inherits="Team12.frm_enquery" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
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
                    <h3>Make Enquery</h3>
                    <br />
                    <div class="container">
                        <div class="divRow">

                            <div class="row top-buffer">
                                <div class="col-md-3"></div>
                                <div class="col-md-6">
                                    <div class="col-md-4">Enquery ID</div>
                                    <div class="col-md-8">
                                        <asp:TextBox ID="txt_enqueryID" ReadOnly="true" runat="server" class="form-control"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                            <br />

                            <div class="row top-buffer">
                                <div class="col-md-3"></div>
                                <div class="col-md-6">
                                    <div class="col-md-4">Delivery ID</div>
                                    <div class="col-md-8">
                                        <asp:TextBox ID="txt_deliveryID" ReadOnly="true" runat="server" class="form-control"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                            <br />

                            <div class="row top-buffer">
                                <div class="col-md-3"></div>
                                <div class="col-md-6">
                                    <div class="col-md-4">Order ID</div>
                                    <div class="col-md-8">
                                        <asp:TextBox ID="txt_orderID" ReadOnly="true" runat="server" class="form-control"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                            .                
                            <br />

                            <div class="row top-buffer">
                                <div class="col-md-3"></div>
                                <div class="col-md-6">
                                    <div class="col-md-4">Supplier</div>
                                    <div class="col-md-8">
                                        <asp:TextBox ID="txt_supplier" ReadOnly="true" runat="server" class="form-control"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                            <br />

                            <div class="row top-buffer">
                                <div class="col-md-3"></div>
                                <div class="col-md-6">
                                    <div class="col-md-4">Enquery Type</div>
                                    <div class="col-md-8">
                                        <asp:DropDownList ID="ddl_enqueryType" runat="server" Style="width: 335px; height: 30px;">
                                            <asp:ListItem>Late due date</asp:ListItem>
                                            <asp:ListItem>Low quality</asp:ListItem>
                                            <asp:ListItem>Quantity problem</asp:ListItem>
                                            <asp:ListItem>Problem in payments</asp:ListItem>
                                            <asp:ListItem>Other</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                </div>
                            </div>
                            <br />

                            <div class="row top-buffer">
                                <div class="col-md-3"></div>
                                <div class="col-md-6">
                                    <div class="col-md-4">Description</div>
                                    <div class="col-md-8">
                                        <asp:TextBox ID="txt_description" TextMode="multiline" Columns="50" Rows="5" runat="server" class="form-control"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                            <br />

                            <asp:TextBox ID="txt_email" Visible="false" runat="server"></asp:TextBox>
                            <asp:TextBox ID="txt_deliveryStatus" Visible="false" runat="server"></asp:TextBox>
                            <asp:TextBox ID="txt_qualityStatus" Visible="false" runat="server"></asp:TextBox>

                            <div class="col-sm-4"></div>
                            <div class="col-sm-4"></div>
                            <div class="col-sm-4">
                                <asp:Button ID="btn_save" type="button" class="btn btn-success" Width="25%" runat="server" Text="Save" OnClick="btn_save_Click" />
                                <asp:Button ID="btn_cancle" type="button" class="btn btn-danger" Width="25%" runat="server" Text="Cancle" OnClick="btn_cancle_Click" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </main>
    </form>
</body>
</html>
