<%@ Page Title="" EnableEventValidation="false" Language="C#" MasterPageFile="~/Contant/MasterPage/MasterPage.master" AutoEventWireup="true" CodeFile="CategoryList.aspx.cs" Inherits="AdminPanel_Category_CategoryList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphContent" runat="Server">
    <div class="container">
        <div class="row">
            <div class="col-md-12">
                <h1>
                    <asp:Label ID="lblHeader" runat="server" Text="Hospital Category List"></asp:Label></h1>
                <br />
                <asp:Label ID="lblMsg" runat="server"></asp:Label>
            </div>
            <div>
                <asp:HyperLink ID="hlCancel" runat="server" NavigateUrl="~/AdminPanel/Category/CategoryAddEdit.aspx" Text="Add Hospital Category" CssClass="btn btn-outline-primary m-3"></asp:HyperLink>
            </div>
            <div class="col-md-12">
                <asp:GridView ID="gvHospitalCategoryList" runat="server" AutoGenerateColumns="false" CssClass="table table-bordered table-hover mt-5" OnRowCommand="gvHospitalCategoryList_RowCommand">
                    <Columns>
                        <asp:BoundField DataField="CategoryID" HeaderText="ID" />
                        <asp:BoundField DataField="CategoryName" HeaderText="Name" />
                        <asp:BoundField DataField="CreationDate" HeaderText="CreationDate And Time" />

                        <asp:TemplateField HeaderText="Edit">
                            <ItemTemplate>
                                <asp:HyperLink ID="hlEdit" runat="server" Text="Edit" CssClass="btn btn-outline-warning" NavigateUrl='<%# "~/AdminPanel/Category/CategoryAddEdit.aspx?CategoryID=" + Eval("CategoryID").ToString().Trim() %>'></asp:HyperLink>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Delete">
                            <ItemTemplate>
                                <asp:Button ID="btnDelete" runat="server" Text="Delete" CssClass="btn btn-outline-danger ml-3" CommandName="DeleteRecord" CommandArgument='<%# Eval("CategoryID") %>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>
        </div>
    </div>
</asp:Content>

