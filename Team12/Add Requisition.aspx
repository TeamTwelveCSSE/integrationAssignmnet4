<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Add Requisition.aspx.cs" Inherits="Team12.Add_Requisition" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <meta name="description" content="">
    <meta name="author" content="">
    <title>Add Requisition</title>
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
                    <%--<li><a href="contact.htm" runat="server">Contact</a></li>--%>
                    <li>
                        <!-- add search form -->
                        <div class="navbar-form" role="search">
                            <%--<div class="input-group">
                                <input type="text" ID="txtsearch" placeholder="Search this site" class="form-control"/>
                                <span class="input-group-btn">
                                    <input type="button"  ID="lbsearch" class="btn btn-default"
                                        Text='<i class="glyphicon glyphicon-search"></i>' />
                                </span>
                            </div>--%>
                        </div>
                    </li>
                </ul>
            </div>
        </div>
    </div>
         

        <%-- ///////////////////////////////////////////////////////////////////////////////////////////////////--%>


        <form id="main"  method="post" runat="server">
            <main id="content">
                <div class="container">
                    <div class="row">
                        <ul class="nav nav-tabs">
                            <li class="active"><a data-toggle="tab" href="Account.aspx" id="#">Add Expenses</a></li>
                            <li><a data-toggle="tab" href="OutPatientCharges.aspx">Calculate Cannelling Charges</a></li>
                            <li><a data-toggle="tab" href="ProfitCalculation.aspx">Profit Calculation</a></li>
                            
                        </ul>

                        <div class="tab-content">
                            <div id="Expenses" class="tab-pane fade in active">
                                <h3>Create Requisition</h3>
                               
                             
        <div class="container">
            <div class="col-md-2"> </div>
            <div class="row">
                <div class="col-md-6">
                    <div id="main-contact-form" class="contact-form">


                        <!-- form -->
                  <%--<form role="form"  method="post">--%>

                        <div class="form-group">
                           <div class="col-md-4">Requisition ID</div>
                           <div class="col-md-6">
                                <asp:TextBox ID="tb_reqid" runat="server" CssClass="form-control"/>
                           </div>
                        </div>

                        <br /><br /> <br />

                        <div class="form-group">
                           <div class="col-md-4">Created By</div>
                           <div class="col-md-6">
                                <asp:DropDownList ID="list_createdby" runat="server" class="form-control" AutoPostBack="false" Visible="True">
                                    <%--<asp:ListItem>Salary Payments</asp:ListItem>
                                    <asp:ListItem>Maintenance</asp:ListItem>
                                    <asp:ListItem>Utility Payments</asp:ListItem>
                                    <asp:ListItem>Other</asp:ListItem>--%>
                                </asp:DropDownList>
                           </div>
                        </div>
                            <br /><br /> 

                        <div class="form-group">
                           <div class="col-md-4">Requisition Date</div>
                           <div class="col-md-6">
                               <asp:TextBox ID="tb_reqdate" runat="server" class="form-control" ></asp:TextBox>
                               <asp:Label ID="hidden_reddate" runat="server" Visible="false"></asp:Label>
                           </div>
                            <%--<div class="col-md-2">
                               <asp:Button ID="btn_date" runat="server" Text="Submission Date" OnClick="btn_date_Click" CssClass="btn btn-default"/> 
                            </div>--%>
                        </div>

                      <div class="form-group">
                           <div class="col-md-4"></div>
                           <%--<div class="col-md-6">
                               <asp:Calendar ID="Calendar1" OnSelectionChanged="Calendar1_SelectionChanged" runat="server" Height="187px" Visible="false" Width="208px"> </asp:Calendar>
                                            
                           </div>--%>
                      </div>

                         <br /> <br />

                        <div class="form-group">
                           <div class="col-md-4">State</div>
                           <div class="col-md-6">
                                <asp:DropDownList ID="lst_state" runat="server" class="form-control" AutoPostBack="false" Visible="True">
                                    <asp:ListItem>State A</asp:ListItem>
                                    <asp:ListItem>State B</asp:ListItem>
                                    <asp:ListItem>State C</asp:ListItem>
                                </asp:DropDownList>
                           </div>
                        </div>

                             <br /> <br />

                        <div class="form-group">
                           <div class="col-md-4">Prority</div>
                           <div class="col-md-6">
                                <asp:DropDownList ID="list_priority" runat="server" class="form-control" AutoPostBack="false" Visible="True">
                                    <asp:ListItem>Very Low</asp:ListItem>
                                    <asp:ListItem>Low</asp:ListItem>
                                    <asp:ListItem>Medium</asp:ListItem>
                                    <asp:ListItem>High</asp:ListItem>
                                    <asp:ListItem>Very High</asp:ListItem>
                                </asp:DropDownList>
                           </div>
                        </div>
                             <br /><br />

                        

                      <div class="form-group">
                            <div class="col-md-4">Add Items</div>
                           <div class="col-md-6">
                               <asp:ImageButton ImageUrl="~/2.png" runat="server" Width="90" Height="90" ImageAlign="Middle" OnClick="Unnamed1_Click" />
                               <br /><br />
                               <asp:TextBox ID="tb_addedItems" TextMode="multiline" class="form-control"  runat="server" Visible="false" AutoPostBack="true"></asp:TextBox> 
                               <br />
                           </div>
                          <div class="col-md-2">
                               <asp:Button ID="btn_addedItems" runat="server" Text="Show Added Items" CssClass="btn btn-default" Visible="false" OnClick="btn_addedItems_Click" /> 
                          </div>
                        </div>
                            <br /><br /> <br /><br /><br />

                        <div class="form-group">
                            <div class="col-md-4">Assigned to</div>
                           <div class="col-md-6">
                               <asp:ImageButton ImageUrl="~/1.png" ID="imgbtn_assignedto" runat="server" Width="90" Height="90" ImageAlign="Middle" OnClick="Unnamed2_Click"/>
                               <br /> <br />
                               <asp:TextBox ID="tb_assignedto" TextMode="multiline" class="form-control"  runat="server" Visible="false" AutoPostBack="true"></asp:TextBox> 
                               <br />
                           </div>
                            <div class="col-md-2">
                               <asp:Button ID="btn_show" runat="server" Text="Show Assigned Supervisors" CssClass="btn btn-default" Visible="false" OnClick="btn_show_Click"/> 
                            </div>
                        </div>
                            <br /><br /> <br /><br /> 

                        <div class="form-group">
                            <div class="col-md-4">Remarks</div>
                            <div class="col-md-6">
                                <asp:TextBox id="TextArea1" TextMode="multiline" Columns="50" Rows="5" runat="server" />
                           </div>
                        </div>
                            <br /><br /><br /><br /><br /><br />

                      <div class="form-group">
                          <div class="col-md-4"></div>
                          <div class="col-md-7">
                                <asp:Button ID="btn_printreq" Text="Print" CssClass="btn btn-primary" runat="server" OnClick="btn_printreq_Click" />
                                <asp:Button ID="btn_addreq" Text="Place Requisition" CssClass="btn btn-success" runat="server" OnClick="btn_addreq_Click"/>
                                <asp:Button ID="btn_calcelreq" Text="Cancel" CssClass="btn btn-danger" runat="server" OnClick="btn_calcelreq_Click"/>
                          </div>
                      </div>
                       


                <%-- </form>--%>
                        


                    </div>
                </div>
                <div class="col-md-4">
                </div>
            </div>
        </div>

                                
                           

                                
                        </div>
                    </div>
                </div>
              </div>
            </main>
   
        </form>

  
        


                        


    
        <!-- footer -->
        <div style="height: 100px; width: 759px; margin-right: 540px">
            <div class="footer">

            </div>
        </div>








        <%--///////////////////////////////////////////////////////////////////////////////////////////////////--%>
        <section id="services" class="padding50">
            <div class="container">
                <div class="row">
                   
                </div>
                <div>

                </div>
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

</body>
</html>
