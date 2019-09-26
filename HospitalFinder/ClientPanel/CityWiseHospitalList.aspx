<%@ Page Title="" Language="C#" MasterPageFile="~/Contant/MasterPage/ClientMasterPage.master" AutoEventWireup="true" CodeFile="CityWiseHospitalList.aspx.cs" Inherits="ClientPanel_CityWiseHospitalList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphContent" runat="Server">
    <div class="container">

        <div class="row">
            <asp:Label ID="lblMsg" runat="server" CssClass="badge badge-danger m-3"></asp:Label>
        </div>

        <div class="container" id="services">
            <section class="services pt-2">

                <header class="section-header">
                    <h3>City Wise Hospital</h3>
                    <br />
                </header>

                <div class="row">
                    <asp:Repeater ID="rpHospitalListByStateName" runat="server">
                        <ItemTemplate>
                            <div class="col-md-6 wow bounceInUp" data-wow-duration="1.4s">
                                <div class="box">
                                    <asp:HyperLink ID="hlShow" runat="server" NavigateUrl='<%# "~/HospitalFinder/HospitalDetails/" + Eval("HospitalID") %>'>
                                        <div class="icon" style="background: #fceef3;">
                                            <i class="ion-ios-medkit" style="color: #ff689b;"></i>
                                        </div>
                                        <h4 class="mt-3"><%#Eval("HospitalName") %></h4>
                                        <p class="mt-3"><%#Eval("CityName") %></p>
                                    </asp:HyperLink>
                                </div>
                            </div>
                        </ItemTemplate>
                    </asp:Repeater>
                </div>

            </section>
        </div>

        <%--<asp:GridView ID="gvHospitalListByCityName" runat="server" EmptyDataText="No Records Found!"
            AutoGenerateColumns="false" CssClass="table table-hover table-bordered mt-5 shadow-lg"
            BackColor="#ccccff" AlternatingRowStyle-BackColor="#ffccff" HeaderStyle-BackColor="#ff66cc">
            <Columns>
                <asp:BoundField DataField="SrNo" HeaderText="Sr.No." />
                <asp:BoundField DataField="HospitalName" HeaderText="HospitalName" />
                <asp:BoundField DataField="CityName" HeaderText="CityName" />

                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:HyperLink ID="hlShow" runat="server" CssClass="btn btn-outline-success" Text="Show Details" NavigateUrl='<%# "~/ClientPanel/HospitalDetails.aspx?HospitalID=" + Eval("HospitalID") %>'></asp:HyperLink>
                    </ItemTemplate>
                </asp:TemplateField>

            </Columns>
        </asp:GridView>--%>
    </div>
</asp:Content>

