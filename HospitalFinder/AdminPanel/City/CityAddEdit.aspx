<%@ Page Title="" Language="C#" MasterPageFile="~/Contant/MasterPage/MasterPage.master" AutoEventWireup="true" CodeFile="CityAddEdit.aspx.cs" Inherits="AdminPanel_City_CityAddEdit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphContent" runat="Server">
    <div class="container">
        <div class="row">
            <div class="col-md-12">
                <h1>
                    <asp:Label ID="lblPageHeader" runat="server"></asp:Label>
                </h1>
                <asp:Label ID="lblMessage" runat="server" CssClass="badge badge-success"></asp:Label>
            </div>
            <div class="col-md-12 m-3">
                <div class="form-group row">
                    <label for="name" class="col-sm-2 col-form-label">City Name :</label>
                    <div class="col-sm-10">
                        <asp:TextBox runat="server" ID="txtCityName" CssClass="form-control"></asp:TextBox>
                        <small id="passwordHelpBlock" class="form-text text-muted ">
                            <asp:RequiredFieldValidator ID="rfvCityName" runat="server" ErrorMessage="Enter City Name" ControlToValidate="txtCityName" Display="Dynamic" ValidationGroup="CityAddEdit" ForeColor="#FF3300"></asp:RequiredFieldValidator>
                        </small>
                    </div>
                </div>
                <div class="form-group row">
                    <label for="name" class="col-sm-2 col-form-label">Pin Code :</label>
                    <div class="col-sm-10">
                        <asp:TextBox runat="server" ID="txtPinCode" CssClass="form-control"></asp:TextBox>
                        <small id="Small1" class="form-text text-muted ">
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Enter PinCode" ControlToValidate="txtPinCode" Display="Dynamic" ValidationGroup="CityAddEdit" ForeColor="#FF3300"></asp:RequiredFieldValidator>
                        </small>
                    </div>
                </div>
                <div class="form-group row">
                    <label for="name" class="col-sm-2 col-form-label">STD Code :</label>
                    <div class="col-sm-10">
                        <asp:TextBox runat="server" ID="txtSTDCode" CssClass="form-control"></asp:TextBox>
                        <small id="Small3" class="form-text text-muted ">
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Enter STDCode" ControlToValidate="txtSTDCode" Display="Dynamic" ValidationGroup="CityAddEdit" ForeColor="#FF3300"></asp:RequiredFieldValidator>
                        </small>
                    </div>
                </div>

                <div class="form-group row">
                    <label for="inputPassword3" class="col-sm-2 col-form-label">Select State :</label>
                    <div class="col-sm-10">
                        <asp:DropDownList ID="ddlState" CssClass="form-control" runat="server"></asp:DropDownList>
                        <small id="Small2" class="form-text text-muted">
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Select State Name" ControlToValidate="ddlState" Display="Dynamic" ValidationGroup="CityAddEdit" ForeColor="#FF3300" InitialValue="-1"></asp:RequiredFieldValidator>
                        </small>
                    </div>
                </div>
            </div>
            <div class="col-md-12 offset-10">
                <asp:Button ID="btnAdd" runat="server" Text="Add" CssClass="btn btn-outline-success" ValidationGroup="CityAddEdit" OnClick="btnSave_Click" />
                <asp:HyperLink ID="hlCancel" runat="server" NavigateUrl="~/AdminPanel/City/CityList.aspx" Text="Cancel" CssClass="btn btn-outline-danger"></asp:HyperLink>
            </div>
        </div>
    </div>
</asp:Content>

