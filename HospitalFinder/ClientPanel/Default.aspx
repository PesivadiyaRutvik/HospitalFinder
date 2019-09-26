<%@ Page Title="" Language="C#" MasterPageFile="~/Contant/MasterPage/ClientMasterPage.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="ClientPanel_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphContent" runat="Server">
    <div class="container">
        <div class="shadow-lg p-2 mb-5 bg-info rounded text-xl-center font-weight-bold">HOSPITAL SEARCH <i class="fa fa-search"></i></div>
        <asp:Label ID="lblMsg" runat="server" CssClass="badge badge-danger m-3"></asp:Label>
        <%--<div class="shadow-lg card btn btn-outline-danger ">--%>
        <div class="shadow-lg card">
            <div class="card bg-warning">
                <div class="card-body text-center">
                    <div class="shadow-lg p-3 mb-3 bg-light text-white rounded">
                        <div class="row">
                            <div class="col-md-12">
                                <asp:TextBox ID="txtsearch" runat="server" CssClass="Search form-control" placeholder="Search Hospital"></asp:TextBox>
                            </div>
                        </div>
                    </div>

                    <div class="form-group row">
                        <label for="inputPassword3" class="col-sm-2 col-form-label">State :</label>
                        <div class="col-sm-4">
                            <asp:DropDownList ID="ddlState" CssClass="form-control" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlState_SelectedIndexChanged"></asp:DropDownList>
                        </div>

                        <label for="inputPassword3" class="col-sm-2 col-form-label">City :</label>
                        <div class="col-sm-4">
                            <asp:DropDownList ID="ddlCity" CssClass="form-control" runat="server" AutoPostBack="true"></asp:DropDownList>
                        </div>
                    </div>

                    <div class="form-group row">
                        <label for="inputPassword3" class="col-sm-2 col-form-label">Category :</label>
                        <div class="col-sm-4">
                            <asp:DropDownList ID="ddlCategory" CssClass="form-control" runat="server" AutoPostBack="true"></asp:DropDownList>
                        </div>

                        <label for="inputPassword3" class="col-sm-2 col-form-label">Hospital Type :</label>
                        <div class="col-sm-4">
                            <asp:DropDownList ID="ddlCategoryType" CssClass="form-control" runat="server" AutoPostBack="true"></asp:DropDownList>
                        </div>
                    </div>

                    <div class="col-md-4 ml-auto">
                        <asp:Button runat="server" ID="btnSearch" Text="Search" CssClass="btn btn-success" ValidationGroup="Search" OnClick="btnSearch_Click" />
                        <asp:Button runat="server" ID="btnClear" Text="Clear" CssClass="btn btn-danger" ValidationGroup="Search" OnClick="btnClear_Click" />
                    </div>

                </div>
            </div>
        </div>
        <br />
        <br />
        <asp:Panel ID="pnlSearch" runat="server" Visible="false">
            <div class="shadow-lg p-3 mb-5 bg-primary text-white rounded">
                <div class="row">
                    <div class="col-md-10">
                        <asp:TextBox ID="txtSecondSearch" runat="server" CssClass="form-control" placeholder="Search Hospital From Below"></asp:TextBox>
                    </div>
                    <div class="col-md-2">
                        <asp:Button runat="server" ID="btnSecondSearch" Text="Search" CssClass="btn btn-dark" ValidationGroup="SecondSearch" OnClick="btnSecondSearch_Click" />
                    </div>
                </div>
            </div>
        </asp:Panel>

        <div class="col-md-12">
            <asp:GridView ID="gvHospitalListByStateName" runat="server" EmptyDataText="No Records Found!"
                AutoGenerateColumns="false" CssClass="table table-hover table-bordered mt-5 shadow-lg"
                BackColor="#ccccff" AlternatingRowStyle-BackColor="#ffccff" HeaderStyle-BackColor="#ff66cc">
                <Columns>
                    <asp:BoundField DataField="SrNo" HeaderText="Sr.No." />
                    <asp:BoundField DataField="HospitalName" HeaderText="HospitalName" />
                    <asp:BoundField DataField="CityName" HeaderText="CityName" />
                    <asp:BoundField DataField="StateName" HeaderText="StateName" />
                    <asp:BoundField DataField="CategoryName" HeaderText="CategoryName" />
                    <asp:BoundField DataField="CategoryType" HeaderText="HospitalType" />

                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:HyperLink ID="hlShow" runat="server" CssClass="btn btn-outline-success" Text="Show Details" NavigateUrl='<%# "~/HospitalFinder/HospitalDetails/" + Eval("HospitalID") %>'></asp:HyperLink>
                        </ItemTemplate>
                    </asp:TemplateField>

                </Columns>
            </asp:GridView>
        </div>

    </div>
</asp:Content>

