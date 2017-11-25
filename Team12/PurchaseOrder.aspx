﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PurchaseOrder.aspx.cs" Inherits="Team12.PurchaseOrder" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
   <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <meta name="description" content="">
    <meta name="author" content="">
    <title>Purchase Order</title>
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
    <form id="form1" runat="server">
        <!-- Navbar fixed top -->
    <div class="navbar navbar-inverse navbar-fixed-top" role="navigation">
        <div class="container">
            <div class="navbar-header">
                <button type="button" class="navbar-toggle" data-toggle="collapse" data-target=".navbar-collapse">
                    <span class="sr-only">Toggle navigation</span> <span class="icon-bar"></span><span
                        class="icon-bar"></span><span class="icon-bar"></span>
                </button>
                <a class="navbar-brand" href="#"><i class="fa fa-diamond"></i>TATA DiamonD</a>
            </div>
            <div class="navbar-collapse collapse">
                <!-- Left nav -->
                <ul class="nav navbar-nav navbar-right">
                    <li class="active"><a href="index.aspx" runat="server">Home</a></li>
                    <li><a href="services.aspx" runat="server">Services</a></li>
                    <li><a href="portfolio.aspx" runat="server">Portfolio</a></li>
                    <li class="dropdown"><a href="blog.aspx" class="dropdown-toggle" data-toggle="dropdown"
                        role="button" aria-haspopup="true" aria-expanded="false" runat="server">Blog<span class="caret"
                            runat="server"></span></a>
                        <ul class="dropdown-menu" data-dropdown-in="fadeInUp" data-dropdown-out="fadeOutDown">
                            <li><a href="#">blog-1</a></li>
                            <li><a href="#">Another action</a></li>
                            <li><a href="#">Something else here</a></li>
                            <li><a href="#">Separated link</a></li>
                        </ul>
                    </li>
                    <li><a href="contact.htm" runat="server">Contact</a></li>
                    <li>
                        <!-- add search form -->
                        <div class="navbar-form" role="search">
                            <div class="input-group">
                                <asp:TextBox ID="txtsearch" runat="server" placeholder="Search this site" class="form-control"></asp:TextBox>
                                <span class="input-group-btn">
                                    <asp:LinkButton runat="server" ID="lbsearch" ToolTip="Search" CssClass="btn btn-default"
                                        Text='<i class="glyphicon glyphicon-search"></i>' />
                                </span>
                            </div>
                        </div>
                    </li>
                </ul>
            </div>
        </div>
    </div>
        <section id="services" class="padding50">
            <div class="container">
                <div class="row">
                    <%--<h2 class="background double animated wow fadeInUp" data-wow-delay="0.2s"><span><strong>F</strong>eatures</span></h2>--%>
                </div>
             <div>
             </div>
                <%--<form id="main" runat="server" method="post">--%>
            <main id="content">
                <div class="container">
                    <div class="row">
                         <ul class="nav nav-tabs">
                           <li><a href="ApproveRequisitions.aspx" runat="server">Approve Requisitions</a></li>
                            <li ><a href="PendingRequisitions.aspx" runat="server">Pending Requisitions</a></li>
                            <li><a href="Accepted Requisitions.aspx" runat="server">Accepted Requisitions</a></li>
                            <li><a href="DenyRequisitions.aspx" runat="server">Deny Requisitions</a></li>
                             <li class="active"><a href="ViewPurchaseOrders.aspx" runat="server">Purchase Order</a></li>
                        </ul>
                        <div class="tab-content">
                            <div id="Approve" class="tab-pane fade in active">
                                <h3>Purchase order</h3>
                                <div class="container">
                                    
                                    <div class="row top-buffer">
                                        <div class="col-md-3">
                                        </div>
                                        <div class="col-md-6">
                                            <div class="col-md-4">Requisition Id</div>
                                            <div class="col-md-8"><asp:TextBox ID="txtReqId" runat="server" class="form-control" ></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="col-md-3">
                                        </div>
                                    </div>
                                    <div class="row top-buffer">
                                        <div class="col-md-3">
                                        </div>
                                        <div class="col-md-6">
                                            <div class="col-md-4">Request Date</div>
                                            <div class="col-md-8"><asp:TextBox ID="txtReqDate" runat="server" class="form-control" ></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="col-md-3">
                                        </div>
                                    </div>

                     
                                    <div class="row top-buffer">
                                        <div class="col-md-3">
                                        </div>
                                        <div class="col-md-6">
                                            <div class="col-md-4">Approve By</div>
                                            <div class="col-md-8"><asp:TextBox ID="txtapprove" runat="server" class="form-control" ></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="col-md-3">
                                        </div>
                                    </div>

                                    <div class="row top-buffer">
                                        <div class="col-md-3">
                                        </div>
                                        <div class="col-md-6">
                                            <div class="col-md-4">Item List</div>
                                            <div class="col-md-8">
                                                <asp:ListBox ID="ListBox1" runat="server" class="form-control"></asp:ListBox>
                                            </div>
                                        </div>
                                        <div class="col-md-3">
                                        </div>
                                    </div>
                                    <br/>
                                    <div class="row top-buffer">
                                        <div class="col-md-3">
                                        </div>
                                        <div class="col-md-6">
                                            <div class="col-md-4">Required Date</div>
                                            <div class="col-md-8">
                                                <asp:TextBox ID="txtOrderDate" runat="server" class="form-control" TextMode="Date" ></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="col-md-3">
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidatorDate" runat="server" ErrorMessage="*Date is Required" ControlToValidate="txtOrderDate" ForeColor="Red" ValidationGroup="Add"></asp:RequiredFieldValidator>
                                        </div>
                                        <asp:CompareValidator ID="cmpVal1" ControlToCompare="TextBox1" 
                                        ControlToValidate="txtOrderDate" Type="Date" Operator="GreaterThanEqual"   
                                        ErrorMessage="*Required Date Must Be Greater Than Todays'date" runat="server" ForeColor="Red" ValidationGroup="Add"></asp:CompareValidator>
                                    </div>

                                    

                                    <div class="row top-buffer">
                                        <div class="col-md-6">
                                        </div>
                                        <div class="col-md-6">
                                            <asp:Button ID="Button1" runat="server" Text=" Create Purchase Order " class=" btn btn-info" ValidationGroup="Add" OnClick="Button1_Click" />
                                              <asp:Button ID="Button2" runat="server" Text=" Send Mail To Supplier " class=" btn btn-danger" ValidationGroup="Add" OnClick="Button2_Click" />
                                            
                                        </div>
                                        <div class="col-md-3">
                                        </div>
                                    </div>
                                    <div class="hidden">
                                        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                                        <asp:Label ID="lbl_emailValidation" runat="server" Text="Label"></asp:Label>
                                        <asp:TextBox ID="hidden_mail" runat="server" Text="ashanikulasinghe@gmail.com"></asp:TextBox>
                                        <asp:TextBox ID="txtItemName" runat="server" Text="cement"></asp:TextBox>
                                        <asp:TextBox ID="txtQuntity" runat="server" Text="100"></asp:TextBox>
                                        <asp:TextBox ID="txtumo" runat="server" Text="50kg"></asp:TextBox>
                                        
                                    </div>
                                    
                                

                                    
                            </div>
                        </div>
                    </div>
                </div>
            </main>
           <%--</form>--%>
                    </div>
        </section>
    <footer id="fh5co-footer" class="padding100">
			
			<div class="fh5co-footer-content">
				<div class="container">
					<div class="row">
						<div class="col-md-3 col-sm-4 col-md-push-3 animated wow fadeInLeft" data-wow-delay="0.2s">
							<h3 class="fh5co-lead">About</h3>
							<ul>
								<li><a href="#">Tour</a></li>
								<li><a href="#">Company</a></li>
								<li><a href="#">Jobs</a></li>
								<li><a href="#">Blog</a></li>
								<li><a href="#">New Features</a></li>
								<li><a href="#">Contact Us</a></li>
							</ul>
						</div>
						<div class="col-md-3 col-sm-4 col-md-push-3 animated wow fadeInLeft" data-wow-delay="0.4s">
							<h3 class="fh5co-lead">Support</h3>
							<ul>
								<li><a href="#">Help Center</a></li>
								<li><a href="#">Terms of Service</a></li>
								<li><a href="#">Security</a></li>
								<li><a href="#">Privacy Policy</a></li>
								<li><a href="#">Careers</a></li>
								<li><a href="#">More Apps</a></li>
							</ul>
						</div>
						<div class="col-md-3 col-sm-4 col-md-push-3 animated wow fadeInLeft" data-wow-delay="0.6s">
							<h3 class="fh5co-lead">More Links</h3>
							<ul>
								<li><a href="#">Feedback</a></li>
								<li><a href="#">Frequently Ask Questions</a></li>
								<li><a href="#">Terms of Service</a></li>
								<li><a href="#">Privacy Policy</a></li>
								<li><a href="#">Careers</a></li>
								<li><a href="#">More Apps</a></li>
							</ul>
						</div>

						<div class="col-md-3 col-sm-12 col-md-pull-9 animated wow fadeInLeft" data-wow-delay="0.8s">
							<div class="fh5co-footer-logo"><a href="index.html">TATA DiamonD</a></div>
							<p class="fh5co-copyright"><small>&copy; 2015. All Rights Reserved. <br>	by <a href="http://aboostrap.com/" target="_blank">aspxtemplates.com</a> Images: <a href="http://aspxtemplates.com/" target="_blank">Pexels</a></small></p>
							<p class="fh5co-social-icons">
								<a href="#"><i class="fa fa-twitter"></i></a>
								<a href="#"><i class="fa fa-facebook"></i></a>
								<a href="#"><i class="fa fa-instagram"></i></a>
								<a href="#"><i class="fa fa-dribbble"></i></a>
								<a href="#"><i class="fa fa-youtube"></i></a>
							</p>
						</div>
						
					</div>
				</div>
			</div>
		</footer>
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
    </form>
</body>    
</html>