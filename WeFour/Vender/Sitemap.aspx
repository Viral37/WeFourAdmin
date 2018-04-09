<%@ Page Title="" Language="C#" MasterPageFile="~/Vender/MasterPage.master" AutoEventWireup="true" CodeFile="Sitemap.aspx.cs" Inherits="Vender_Sitemap" EnableEventValidation="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div role="main" class="main">

				<div class="container">

					<div class="row">

						<div class="col-md-4">
							<ul class="nav nav-list mb-xl">
								<li><a href="index.html">Home</a></li>
								<li>
									<a href="View_Product.aspx">Listings</a>
									<ul>
										<li><a href="View_Product.aspx">My Listings</a></li>
										<li><a href="Track_Approvel.aspx">Track Approvel request</a></li>
                                        <li><a href="pricing.aspx">Priceing Calculator</a></li>
									</ul>
								</li>
                                <li>
									<a href="Cancel_Order.aspx">Orders</a>
									<ul>
										<li><a href="Active_Order.aspx">Active Order</a></li>
										<li><a href="Cancel_Order.aspx">Cancelled Orders</a></li>
                                        
									</ul>
								</li>
                                <li>
									<a href="Return_Order.aspx">Return</a>
									<ul>
										<li><a href="Return_Order.aspx">Return Order</a></li>
                                    </ul>
								</li>
                                <li>
									<a href="Payment.aspx">Payments</a>
									<ul>
										<li><a href="Payment.aspx">Overview</a></li>
                                        <li><a href="invoice2.aspx">Invoice</a></li>
                                        <li><a href="statement.aspx">Statements</a></li>
                                    </ul>
								</li>
							</ul>
						</div>

						<div class="col-md-6 col-md-offset-2 hidden-xs">
							<h2 class="mb-lg">Who <strong>We Are</strong></h2>
							<p class="lead">Curabitur pellentesque neque eget diam posuere porta. Quisque ut nulla at nunc vehicula lacinia. Proin adipiscing porta tellus, ut feugiat nibh adipiscing sit amet.</p>
							<ul class="list list-icons mt-xl">
								<li><i class="fa fa-check"></i>Fusce sit amet orci quis arcu vestibulum vestibulum sed ut felis. Phasellus in risus quis lectus iaculis vulputate id quis nisl.</li>
								<li><i class="fa fa-check"></i>Phasellus in risus quis lectus iaculis vulputate id quis nisl.</li>
								<li><i class="fa fa-check"></i>Fusce sit amet orci quis arcu vestibulum vestibulum sed ut felis. </li>
								<li><i class="fa fa-check"></i>Phasellus in risus quis lectus iaculis vulputate id quis nisl.</li>
								<li><i class="fa fa-check"></i>Phasellus in risus quis lectus iaculis vulputate id quis nisl.</li>
								<li><i class="fa fa-check"></i>Fusce sit amet orci quis arcu vestibulum vestibulum sed ut felis. </li>
								<li><i class="fa fa-check"></i>Phasellus in risus quis lectus iaculis vulputate id quis nisl.</li>
							</ul>
						</div>

					</div>

				</div>

			</div>

		
</asp:Content>

