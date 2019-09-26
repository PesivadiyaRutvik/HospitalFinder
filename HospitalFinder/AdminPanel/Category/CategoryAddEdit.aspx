<%@ Page Title="" Language="C#" MasterPageFile="~/Contant/MasterPage/MasterPage.master" AutoEventWireup="true" CodeFile="CategoryAddEdit.aspx.cs" Inherits="AdminPanel_Category_CategoryAddEdit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphContent" runat="Server">
    <div class="container">
        <div class="row">
            <div class="col-md-12">
                <h1>
                    <asp:label id="lblPageHeader" runat="server"></asp:label>
                </h1>
                <asp:label id="lblMessage" runat="server" cssclass="badge badge-success"></asp:label>
            </div>
            <div class="col-md-12 m-3">
                <div class="form-group row">
                    <label for="name" class="col-sm-3 col-form-label">Category Name :</label>
                    <div class="col-sm-9">
                        <asp:textbox runat="server" id="txtCategoryName" cssclass="form-control"></asp:textbox>
                        <small id="passwordHelpBlock" class="form-text text-muted ">
                            <asp:RequiredFieldValidator ID="rfvCategoryName"  runat="server" Display="Dynamic" ErrorMessage="Enter Category Name" ControlToValidate="txtCategoryName"></asp:RequiredFieldValidator>
                        </small>
                    </div>
                </div>
            </div>
            <div class="col-md-12 offset-10">
                <asp:button id="btnAdd" runat="server" text="Add" cssclass="btn btn-outline-success" validationgroup="CategoryAddEdit" onclick="btnAdd_Click" />
                <asp:hyperlink id="hlCancel" runat="server" navigateurl="~/AdminPanel/Category/CategoryList.aspx" text="Cancel" cssclass="btn btn-outline-danger"></asp:hyperlink>
            </div>
        </div>
    </div>
</asp:Content>

