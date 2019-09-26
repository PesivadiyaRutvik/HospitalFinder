<%@ Page Title="" Language="C#" MasterPageFile="~/Contant/MasterPage/MasterPage.master" AutoEventWireup="true" CodeFile="StateList.aspx.cs" Inherits="AdminPanel_State_StateList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphContent" runat="Server">
    <div class="container">
        <div class="row">
            <div class="col-md-12">
                <h1>
                    <asp:Label ID="lblHeader" runat="server" Text="State List"></asp:Label>
                </h1>
                <asp:Label runat="server" ID="lblMsg"></asp:Label>
            </div>
            <div class="col-md-12">
                <asp:HyperLink ID="hlAddState" runat="server" NavigateUrl="~/AdminPanel/State/StateAddEdit.aspx" Text="Add State" CssClass="btn btn-outline-primary m-3"></asp:HyperLink>
            </div>
            <div class="col-md-12 mt-5">
                <div style="overflow-x: auto;">
                    <asp:GridView ID="gvStateList" runat="server" AutoGenerateColumns="false" CssClass="table table-bordered table-hover" OnRowCommand="gvStateList_RowCommand">
                        <Columns>
                            <asp:BoundField DataField="StateName" HeaderText="State Name" />
                            <asp:BoundField DataField="CreationDate" HeaderText="CreationDate And Time" />
                            <asp:TemplateField HeaderText="Edit">
                                <ItemTemplate>
                                    <asp:HyperLink ID="hlEdit" runat="server" Text="Edit" CssClass="btn btn-outline-warning ml-3" NavigateUrl='<%# "~/AdminPanel/State/StateAddEdit.aspx?StateID=" + Eval("StateID") %>'></asp:HyperLink>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Delete">
                                <ItemTemplate>
                                    <asp:Button ID="btnDelete" runat="server" Text="Delete" CssClass="btn btn-outline-danger ml-3" CommandName="DeleteRecord" CommandArgument='<%# Eval("StateID") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

