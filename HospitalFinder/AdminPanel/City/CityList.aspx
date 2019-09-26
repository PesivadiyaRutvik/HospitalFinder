<%@ Page Title="" EnableEventValidation="false" Language="C#" MasterPageFile="~/Contant/MasterPage/MasterPage.master" AutoEventWireup="true" CodeFile="CityList.aspx.cs" Inherits="AdminPanel_City_CityList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphContent" runat="Server">
    <div class="container">
        <div class="row">
            <div class="col-md-12">
                <h1>
                    <asp:Label ID="lblHeader" runat="server" EnableViewState="false" Text="City List"></asp:Label></h1>
                <br />
                <asp:Label ID="lblMsg" runat="server"></asp:Label>
            </div>
            <div class="col-md-12">
                <asp:HyperLink ID="hlAddCity" runat="server" NavigateUrl="~/AdminPanel/City/CityAddEdit.aspx" Text="Add City" CssClass="btn btn-outline-primary m-3"></asp:HyperLink>
            </div>
            <div class="col-md-12">
                <asp:GridView ID="gvCityList" runat="server" AutoGenerateColumns="false" CssClass="table table-bordered table-hover mt-5" OnRowCommand="gvCityList_RowCommand">
                    <Columns>
                        <asp:BoundField DataField="CityName" HeaderText="City" />
                        <asp:BoundField DataField="PinCode" HeaderText="PinCode" />
                        <asp:BoundField DataField="STDCode" HeaderText="STDCode" />
                        <asp:BoundField DataField="StateName" HeaderText="State" />
                        <asp:BoundField DataField="CreationDate" HeaderText="CreationDate And Time" />
                        <asp:TemplateField HeaderText="Edit">
                            <ItemTemplate>
                                <asp:HyperLink ID="hlEdit" runat="server" CssClass="btn btn-outline-warning ml-3" Text="Edit" NavigateUrl='<%# "~/AdminPanel/City/CityAddEdit.aspx?CityID=" + Eval("CityID") %>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Delete">
                            <ItemTemplate>
                                <asp:Button ID="btnDelete" runat="server" Text="Delete" CssClass="btn btn-outline-danger ml-3" CommandName="DeleteRecord" CommandArgument='<%# Eval("CityID") %>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>
        </div>
    </div>
</asp:Content>

