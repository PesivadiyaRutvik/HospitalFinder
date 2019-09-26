<%@ Page Title="" Language="C#" MasterPageFile="~/Contant/MasterPage/MasterPage.master" AutoEventWireup="true" CodeFile="CategoryTypeList.aspx.cs" Inherits="AdminPanel_CategoryType_CategoryTypeList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphContent" Runat="Server">
    <div class="container">
        <div class="row">
            <div class="col-md-12">
                <h1>
                    <asp:Label ID="lblHeader" runat="server" Text="Hospital Category Type List"></asp:Label></h1>
                <br />
                <asp:Label ID="lblMsg" runat="server"></asp:Label>
            </div>
            <div>
                <asp:HyperLink ID="hlCancel" runat="server" NavigateUrl="~/AdminPanel/CategoryType/CategoryTypeAddEdit.aspx" Text="Add Hospital Category Type" CssClass="btn btn-outline-primary m-3"></asp:HyperLink>
            </div>
            <div class="col-md-12">
                <asp:GridView ID="gvHospitalCategoryTypeList" runat="server" AutoGenerateColumns="false" CssClass="table table-bordered table-hover mt-5" OnRowCommand="gvHospitalCategoryTypeList_RowCommand">
                    <Columns>
                        <asp:BoundField DataField="CategoryTypeID" HeaderText="ID" />
                        <asp:BoundField DataField="CategoryType" HeaderText="Type" />
                        <asp:BoundField DataField="CreationDate" HeaderText="CreationDate And Time" />

                        <asp:TemplateField HeaderText="Edit">
                            <ItemTemplate>
                                <asp:HyperLink ID="hlEdit" runat="server" Text="Edit" CssClass="btn btn-outline-warning" NavigateUrl='<%# "~/AdminPanel/CategoryType/CategoryTypeAddEdit.aspx?CategoryTypeID=" + Eval("CategoryTypeID").ToString().Trim() %>'></asp:HyperLink>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Delete">
                            <ItemTemplate>
                                <asp:Button ID="btnDelete" runat="server" Text="Delete" CssClass="btn btn-outline-danger ml-3" CommandName="DeleteRecord" CommandArgument='<%# Eval("CategoryTypeID") %>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>
        </div>
    </div>
</asp:Content>

