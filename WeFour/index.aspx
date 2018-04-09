<%@ Page Language="C#" AutoEventWireup="true" CodeFile="index.aspx.cs" Inherits="Vender_Login" %>

<!DOCTYPE html>

<!DOCTYPE html>
<html>
<head>

    <!-- Basic -->
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">

    <title>Login</title>

    <!-- Favicon -->
    <link rel="shortcut icon" href="img/favicon.ico" type="image/x-icon" />
    <link rel="apple-touch-icon" href="img/apple-touch-icon.png">

    <!-- Mobile Metas -->
    <meta name="viewport" content="width=device-width, minimum-scale=1.0, maximum-scale=1.0, user-scalable=no">

    <!-- Web Fonts  -->
    <link href="https://fonts.googleapis.com/css?family=Open+Sans:300,400,600,700,800%7CShadows+Into+Light" rel="stylesheet" type="text/css">

    <!-- Vendor CSS -->
    <link rel="stylesheet" href="vendor/bootstrap/css/bootstrap.min.css">
    <link rel="stylesheet" href="vendor/font-awesome/css/font-awesome.min.css">
    <link rel="stylesheet" href="vendor/animate/animate.min.css">
    <link rel="stylesheet" href="vendor/simple-line-icons/css/simple-line-icons.min.css">
    <link rel="stylesheet" href="vendor/owl.carousel/assets/owl.carousel.min.css">
    <link rel="stylesheet" href="vendor/owl.carousel/assets/owl.theme.default.min.css">
    <link rel="stylesheet" href="vendor/magnific-popup/magnific-popup.min.css">

    <!-- Theme CSS -->
    <link rel="stylesheet" href="css/theme.css">
    <link rel="stylesheet" href="css/theme-elements.css">
    <link rel="stylesheet" href="css/theme-blog.css">
    <link rel="stylesheet" href="css/theme-shop.css">

    <!-- Skin CSS -->
    <link rel="stylesheet" href="css/skins/default.css">

    <!-- Theme Custom CSS -->
    <link rel="stylesheet" href="css/custom.css">

    <!-- Head Libs -->
    <script src="vendor/modernizr/modernizr.min.js"></script>

</head>
<body>
    <form>
    </form>
    <div class="body">


        <div role="main" class="main">

            <section class="page-header">
                <div class="container">
                    <div class="row">
                        <div class="col-md-12">
                            <ul class="breadcrumb">
                                <li><a href="#">Home</a></li>
                                <li class="active">Login</li>
                            </ul>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-12">
                            <h1>Login</h1>
                        </div>
                    </div>
                </div>
            </section>

            <div class="container">

                <div class="row">
                    <div class="col-md-12">
 <%--login box--%>
                        <div class="featured-boxes">
                            <div class="row">
                                <div class="col-sm-3">
                                </div>
                                <div class="col-sm-6">
                                    <div class="featured-box featured-box-primary align-left mt-xlg">
                                        <div class="box-content">
                                            <h4 class="heading-primary text-uppercase mb-md">Login Here..</h4>
                                            <form runat="server">
                                                <div class="row">
                                                    <div class="form-group">
                                                        <div class="col-md-12">
                                                            <label>Username or E-mail Address</label>
                                                            <%--<input type="text" value="" class="form-control input-lg">--%>
                                                            <asp:TextBox runat="server" ID="txtemail" CssClass="form-control input-lg"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="row">
                                                    <div class="form-group">
                                                        <div class="col-md-12">
                                                            <a class="pull-right" href="#">(Lost Password?)</a>
                                                            <label>Password</label>
                                                            <%--<input type="password" value="" class="form-control input-lg">--%>
                                                            <asp:TextBox runat="server" ID="txtpwd" CssClass="form-control input-lg" TextMode="Password"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="row">
                                                    <div class="col-md-6">
                                                        <span class="remember-box checkbox">
                                                            <label for="rememberme">
                                                                <input type="checkbox" id="rememberme" name="rememberme">Remember Me
                                                            </label>
                                                        </span>
                                                    </div>
                                                    <div class="col-md-6">
                                                        <asp:Button runat="server" CssClass="btn btn-primary pull-right mb-xl" data-loading-text="Loading..." OnClick="btnlogin_Click" ID="btnlogin" Text="Login" />
                                                    </div>
                                                </div>
                                            </form>
                                        </div>
                                    </div>
                                </div>

                            </div>

                        </div>
                    </div>
                </div>

            </div>

        </div>

        <footer id="footer">
            <div class="footer-copyright">
                <div class="container">
                    <div class="row">
                        <div class="col-md-1">
                            <a href="index.html" class="logo">
                                <img alt="Shreeman" class="img-responsive" src="img/shreeman_logo.png">
                            </a>
                        </div>
                        <div class="col-md-7">
                            <p>© Copyright 2018. All Rights Reserved.</p>
                        </div>
                        <div class="col-md-4">
                            <nav id="sub-menu">
                                <ul>
                                    <%--<li><a href="page-faq.html">FAQ's</a></li>
										<li><a href="sitemap.html">Sitemap</a></li>
										<li><a href="contact-us.html">Contact</a></li>--%>
                                </ul>
                            </nav>
                        </div>
                    </div>
                </div>
            </div>
        </footer>
    </div>

    <!-- Vendor -->
    <script src="vendor/jquery/jquery.min.js"></script>
    <script src="vendor/jquery.appear/jquery.appear.min.js"></script>
    <script src="vendor/jquery.easing/jquery.easing.min.js"></script>
    <script src="vendor/jquery-cookie/jquery-cookie.min.js"></script>
    <script src="vendor/bootstrap/js/bootstrap.min.js"></script>
    <script src="vendor/common/common.min.js"></script>
    <script src="vendor/jquery.validation/jquery.validation.min.js"></script>
    <script src="vendor/jquery.easy-pie-chart/jquery.easy-pie-chart.min.js"></script>
    <script src="vendor/jquery.gmap/jquery.gmap.min.js"></script>
    <script src="vendor/jquery.lazyload/jquery.lazyload.min.js"></script>
    <script src="vendor/isotope/jquery.isotope.min.js"></script>
    <script src="vendor/owl.carousel/owl.carousel.min.js"></script>
    <script src="vendor/magnific-popup/jquery.magnific-popup.min.js"></script>
    <script src="vendor/vide/vide.min.js"></script>

    <!-- Theme Base, Components and Settings -->
    <script src="js/theme.js"></script>

    <!-- Theme Custom -->
    <script src="js/custom.js"></script>

    <!-- Theme Initialization Files -->
    <script src="js/theme.init.js"></script>

    <!-- Google Analytics: Change UA-XXXXX-X to be your site's ID. Go to http://www.google.com/analytics/ for more information.
		<script>
			(function(i,s,o,g,r,a,m){i['GoogleAnalyticsObject']=r;i[r]=i[r]||function(){
			(i[r].q=i[r].q||[]).push(arguments)},i[r].l=1*new Date();a=s.createElement(o),
			m=s.getElementsByTagName(o)[0];a.async=1;a.src=g;m.parentNode.insertBefore(a,m)
			})(window,document,'script','//www.google-analytics.com/analytics.js','ga');
		
			ga('create', 'UA-12345678-1', 'auto');
			ga('send', 'pageview');
		</script>
		 -->

</body>
</html>

