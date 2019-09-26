<%@ Page Title="" Language="C#" MasterPageFile="~/Contant/MasterPage/MasterPage.master" AutoEventWireup="true" CodeFile="StateAddEdit.aspx.cs" Inherits="AdminPanel_State_StateAddEdit" %>

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
                    <label for="name" class="col-md-2 col-form-label">State Name :</label>
                    <div class="col-md-10">
                        <asp:textbox runat="server" id="txtStateName" cssclass="form-control"></asp:textbox>
                        <small id="passwordHelpBlock" class="form-text text-muted ">
                            <asp:requiredfieldvalidator id="rfvStateName" runat="server" errormessage="Enter State Name" controltovalidate="txtStateName" display="Dynamic" validationgroup="StateAddEdit" forecolor="#FF3300"></asp:requiredfieldvalidator>
                        </small>
                    </div>
                </div>
            </div>
            <div class="col-md-12 offset-10">
                <asp:button id="btnAdd" runat="server" text="Add" cssclass="btn btn-outline-success" validationgroup="StateAddEdit" onclick="btnSave_Click" />
                <asp:hyperlink id="hlCancel" runat="server" navigateurl="~/AdminPanel/State/StateList.aspx" text="Cancel" cssclass="btn btn-outline-danger"></asp:hyperlink>
            </div>
        </div>
    </div>
</asp:Content>

